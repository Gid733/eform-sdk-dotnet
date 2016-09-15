﻿using eFormCommunicator;
using eFormRequest;
using eFormResponse;
using eFormSubscriber;
using eFormSqlController;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using MiniTrols;
using System.Net;
using System.Security.Cryptography;

namespace Microting
{
    class Controller
    {
        #region var
        List<Communicator> communicators;
        SqlController sqlController;
        Subscriber subscriber;
        Tools tool = new Tools();
        object _lockMain = new object();
        object _lockEvent = new object();
        object _lockEventReply = new object();
        bool updateIsRunningFiles = true;
        bool updateIsRunningNotifications = true;
        string fileLocation = "";
        #endregion

        #region con
        public Controller()
        {
            Start();
        }
        #endregion

        #region public
        public void CreateEform(int templatId, string pushMessageTitle, string pushMessageBody, string numberplate, string roadData, string roadNumber) //Michael
        {
            Thread subscriberThread = new Thread(() => CreateEformAllSitesThread(templatId, numberplate, roadData, roadNumber, pushMessageTitle, pushMessageBody));
            subscriberThread.Start();
        }

        public void CreateEform(int templatId, string pushMessageTitle, string pushMessageBody, string siteId)
        {
            Thread subscriberThread = new Thread(() => CreateEformOneSiteThread(templatId, siteId, pushMessageTitle, pushMessageBody));
            subscriberThread.Start();
        }

        public void Close()
        {
            lock (_lockMain)
            {
                try
                {
                    subscriber.Close(true);
                }
                catch { }

                subscriber.EventMsgClient -= HandleEvent;
                subscriber.EventMsgServer -= HandleEventReply;
                subscriber = null;

                HandleEvent("Subscriber no longer triggers events", null);
                HandleEvent("Controller closed", null);
                HandleEvent("", null);

                communicators = null;
                sqlController = null;
            }
        }

        public void Test()
        {
            sqlController.Test();
        }
        #endregion

        #region private
        private void Start()
        {
            try
            {
                HandleEvent("Controller started", null);

                #region DOMAP - read settings
                //DOMAP - Change to your needs
                string[] lines = File.ReadAllLines("Input.txt");

                string comToken = lines[0];
                string comAddress = lines[1];

                string subscriberToken = lines[3];
                string subscriberAddress = lines[4];
                string subscriberName = lines[5];

                string serverConnectionString = lines[7];
                int userId = int.Parse(lines[8]);

                fileLocation = lines[10];

                //DOMAP - Change to your needs
                #endregion


                //sqlController
                sqlController = new SqlController(serverConnectionString, userId);
                HandleEvent("SqlEformController started", null);


                //communicators
                communicators = new List<Communicator>();
                foreach (string str in sqlController.SitesList())
                {
                    communicators.Add(new Communicator(str, comToken, comAddress));
                }
                HandleEvent("Communicators started", null);


                //subscriber
                subscriber = new Subscriber(subscriberToken, subscriberAddress, subscriberName);
                HandleEvent("Subscriber started", null);
                subscriber.EventMsgClient += HandleEvent;
                subscriber.EventMsgServer += HandleEventReply;
                HandleEvent("Subscriber now triggers events", null);
                subscriber.Start();
            }
            catch (Exception ex)
            {
                // PANIC !!!

                //DOMAP - Change to your needs
                throw new Exception("FATAL EXPECTION", ex);
                //DOMAP - Change to your needs
            }
        }

        private void CreateEformOneSiteThread(int templatId, string siteId, string pushMessageTitle, string pushMessageBody)
        {
            lock (_lockMain)
            {
                try
                {
                    bool found = false;

                    //getting mainElement
                    MainElement mainElement = sqlController.EformRead(templatId);

                    // pushMessageTitle // pushMessageBody
                    mainElement.PushMessageTitle = pushMessageTitle;
                    mainElement.PushMessageBody = pushMessageBody;

                    //sending and getting a reply
                    foreach (Communicator com in communicators)
                    {
                        if (com.ApiId() == siteId)
                        {
                            string muuId = SendXml(mainElement, com);

                            int caseId = sqlController.CaseCreate(muuId, int.Parse(mainElement.Id), int.Parse(com.ApiId()), "", "", "unique");

                            found = true;
                        }
                    }

                    if (!found)
                        throw new Exception("SiteId:'" + siteId + "' not found. No eForm created");

                    HandleEvent("eForm created", null);
                }
                catch (Exception ex)
                {
                    HandleExpection(ex);
                }
            }
        }

        private void CreateEformAllSitesThread(int templatId, string numberPlate, string roadData, string roadNumber, string pushMessageTitle, string pushMessageBody)
        {
            lock (_lockMain)
            {
                try
                {
                    //getting mainElement
                    MainElement mainElement = sqlController.EformRead(templatId);

                    #region numberplate // vejData 
                    mainElement.Label = numberPlate;
                    DataElement dE = (DataElement)mainElement.ElementList[0];
                    dE.Label = numberPlate;

                    dE = (DataElement)mainElement.ElementList[0];
                    dE.DataItemList[0].Label = roadData + " // " + roadNumber;
                    #endregion

                    // pushMessageTitle // pushMessageBody
                    mainElement.PushMessageTitle = pushMessageTitle;
                    mainElement.PushMessageBody = pushMessageBody;

                    //sending and getting a reply
                    foreach (Communicator com in communicators)
                    {
                        string muuId = SendXml(mainElement, com);

                        int caseId = sqlController.CaseCreate(muuId, int.Parse(mainElement.Id), int.Parse(com.ApiId()), "WasteControlCase", numberPlate, roadNumber);
                    }
                    HandleEvent("eForms created", null);
                }
                catch (Exception ex)
                {
                    HandleExpection(ex);
                }
            }
        }

        private string SendXml(MainElement mainElement, Communicator communicator)
        {
            string reply = communicator.PostXml(mainElement.ClassToXml());

            Response response = new Response();
            response = response.XmlToClass(reply);

            //trace msg HandleEvent(reply);
            //if reply is "success", it's created
            if (response.Type.ToString().ToLower() == "success")
            {
                HandleEvent(response.Value + " on " + communicator.ApiId() + " has been created", null);
                return response.Value;
            }

            throw new NotImplementedException(communicator.ApiId() + " // failed to create eForm at Microting // Response :" + reply);
        }

        private void HandleUpdateFiles()
        {
            if (updateIsRunningFiles)
            {
                updateIsRunningFiles = false;
                try
                {
                    #region update files
                    string urlStr = "";
                    bool oneFound = true;
                    while (oneFound)
                    {
                        urlStr = sqlController.FileRead();
                        if (urlStr == "")
                        {
                            oneFound = false;
                            break;
                        }

                        #region finding file name and creating folder if needed
                        FileInfo file = new FileInfo(fileLocation);
                        file.Directory.Create(); // If the directory already exists, this method does nothing.

                        int index = urlStr.LastIndexOf("/") + 1;
                        string fileName = urlStr.Remove(0, index);
                        #endregion

                        #region download file
                        using (var client = new WebClient())
                        {
                            client.DownloadFile(urlStr, fileLocation + fileName);
                        }
                        #endregion

                        #region finding checkSum
                        string chechSum = "";
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(fileLocation + fileName))
                            {
                                byte[] grr = md5.ComputeHash(stream);
                                chechSum = BitConverter.ToString(grr).Replace("-","").ToLower();
                            }
                        }
                        #endregion

                        #region checks checkSum
                        if (chechSum != fileName.Substring(0, 32))
                            throw new InvalidDataException("Download of '" + urlStr + "' failed. Check sum did not match");
                        #endregion

                        sqlController.FileProcessed(urlStr, chechSum, fileLocation, fileName);
                        HandleEvent("Processed file '" + urlStr + "'.", null);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    HandleExpection(ex);
                }
                updateIsRunningFiles = true;
            }
        }

        private void HandleUpdateNotifications()
        {
            if (updateIsRunningNotifications)
            {
                updateIsRunningNotifications = false;
                try
                {
                    #region update notifications
                    string notificationStr, muuId, typeStr = "";
                    bool oneFound = true;
                    while (oneFound)
                    {
                        notificationStr = sqlController.NotificationRead();
                        if (notificationStr == "")
                        {
                            oneFound = false;
                            break;
                        }

                        muuId = tool.Locate(notificationStr, "microting_uuid\\\":\\\"", "\\");
                        typeStr = tool.Locate(notificationStr, "text\\\":\\\"", "\\\"");

                        switch (typeStr)
                        {
                            #region check_status / checklist updated by tablet
                            case "check_status":
                                {
                                    List<string> lst = sqlController.CaseFindMatchs(muuId);

                                    MainElement mainElement = new MainElement();
                                    foreach (string str in lst)
                                    {
                                        string siteId = tool.Locate(str, "{", "}");
                                        string msgId = tool.Locate(str, "[", "]");

                                        foreach (Communicator com in communicators)
                                        {
                                            if (siteId == com.ApiId())
                                            {
                                                if (msgId == muuId)
                                                {
                                                    //get response's data and update DB with data

                                                    string xml = com.Retrieve(msgId);
                                                    Response resp = new Response();
                                                    resp = resp.XmlToClass(xml);

                                                    if (resp.Type == Response.ResponseTypes.Success)
                                                    {
                                                        sqlController.EformCheckCreate(resp, xml);
                                                        sqlController.CaseUpdate(msgId, DateTime.Parse(resp.Checks[0].Date), int.Parse(resp.Checks[0].WorkerId), resp.Checks[0].Id, int.Parse(resp.Checks[0].UnitId));
                                                    }
                                                    else
                                                        throw new Exception("Failed to retrive eForm " + msgId + " from site " + siteId);

                                                    HandleEvent(msgId + " on " + siteId + " has been completed", null);
                                                }
                                                else
                                                {
                                                    //delete eForm on other tablets and update DB to "deleted"

                                                    string respXml = com.Delete(msgId);
                                                    Response resp = new Response();
                                                    resp = resp.XmlToClass(respXml);

                                                    if (resp.Type == Response.ResponseTypes.Success)
                                                        sqlController.CaseDelete(msgId);
                                                    else
                                                        throw new Exception("Failed to delete eForm " + msgId + " from site " + siteId);
                                                    HandleEvent(msgId + " on " + siteId + " has been removed", null);
                                                }
                                                break;
                                            }
                                        }
                                    }

                                    sqlController.NotificationProcessed(notificationStr);
                                    HandleEvent("Processed notification '" + muuId + "'/'check_status'.", null);
                                    break;
                                }
                            #endregion

                            #region unit fetch / checklist retrieve by tablet
                            case "unit_fetch":
                                {
                                    sqlController.NotificationProcessed(notificationStr);
                                    HandleEvent("Processed notification '" + muuId + "'/'unit_fetch'.", null);
                                    break;
                                }
                            #endregion

                            #region unit_activate / tablet added
                            case "unit_activate":
                                {
                                    sqlController.NotificationProcessed(notificationStr);
                                    HandleEvent("Processed notification '" + muuId + "'/'unit_activate'.", null);
                                    break;
                                }
                            #endregion

                            default:
                                throw new IndexOutOfRangeException("Notification type '" + typeStr + "' is not known or mapped");
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    HandleExpection(ex);
                }
                updateIsRunningNotifications = true;
            }
        }
        #endregion

        #region events
        public void HandleEvent(object sender, EventArgs args)
        {
            lock (_lockEvent)
            {
                try
                {
                    //DOMAP - Change to your needs
                    Console.WriteLine("Client # " + sender.ToString());
                    //DOMAP - Change to your needs
                }
                catch (Exception ex)
                {
                    HandleExpection(ex);
                }
            }
        }

        public void HandleEventReply(object sender, EventArgs args)
        {
            lock (_lockEventReply)
            {
                try
                {
                    Console.WriteLine("Server # " + sender.ToString());

                    string reply = sender.ToString();

                    if (reply.Contains("-update\",\"data"))
                    {
                        if (reply.Contains("\"id\\\":"))
                        {
                            string muuId = tool.Locate(reply, "microting_uuid\\\":\\\"", "\\");
                            string nfId = tool.Locate(reply, "\"id\\\":", ",");

                            sqlController.NotificationCreate(muuId, reply);
                            subscriber.ConfirmId(nfId);
                        }
                    }

                    //notifications //checks if there already are unprocessed files and notifications in the system
                    TriggerDbUpdates();
                }
                catch (Exception ex)
                {
                    HandleExpection(ex);
                }
            }
        }

        public void HandleExpection(Exception ex)
        {
            //DOMAP - Change to your needs
            Console.WriteLine("");
            Console.WriteLine("###### # EXCEPTION FOUND");
            Console.WriteLine("Message:" + ex.Message);
            Console.WriteLine("Source:" + ex.Source);
            Console.WriteLine("StackTrace:" + ex.StackTrace);
            Console.WriteLine("InnerException:" + ex.InnerException);
            Console.WriteLine("###### # EXCEPTION FOUND");
            Console.WriteLine("");
            //DOMAP - Change to your needs

            Close();
            Thread.Sleep(1000);
            Start();
        }

        public void TriggerDbUpdates()
        {
            Thread updateFilesThread         = new Thread(() => HandleUpdateFiles());
            updateFilesThread.Start();

            Thread updateNotificationsThread = new Thread(() => HandleUpdateNotifications());
            updateNotificationsThread.Start();
        }
        #endregion
    }
}
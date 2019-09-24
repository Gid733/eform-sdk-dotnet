﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microting.eForm;
using Microting.eForm.Dto;
using Microting.eForm.Helpers;
using Microting.eForm.Infrastructure;
using Microting.eForm.Infrastructure.Constants;
using Microting.eForm.Infrastructure.Data.Entities;

namespace eFormSDK.Integration.Tests
{
    [TestFixture]
    public class SqlControllerTest : DbTestFixture
    {
        private SqlController sut;
        private TestHelpers testHelpers;
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "");
        //path = System.IO.Path.GetDirectoryName(path).Replace(@"file:\", "");



        public override void DoSetup()
        {
            sut = new SqlController(ConnectionString);
            sut.StartLog(new CoreBase());
            testHelpers = new TestHelpers();
            sut.SettingUpdate(Settings.fileLocationPicture, path + @"\output\dataFolder\picture\");
            sut.SettingUpdate(Settings.fileLocationPdf, path + @"\output\dataFolder\pdf\");
            sut.SettingUpdate(Settings.fileLocationJasper, path + @"\output\dataFolder\reports\");
        }

        



        #region public "reply"

        #region check
        
        [Test]
        public void SQL_Check_ChecksCreate_IsCreated()
        {


            // Arrance
            #region Template1
            /* check_lists cl1 = new check_lists();
             cl1.created_at = DateTime.Now;
             cl1.updated_at = DateTime.Now;
             cl1.label = "A";
             cl1.description = "D";
             cl1.workflow_state = Constants.WorkflowStates.Created;
             cl1.case_type = "CheckList";
             cl1.folder_name = "Template1FolderName";
             cl1.display_index = 1;
             cl1.repeated = 1;

             DbContext.check_lists.Add(cl1);
             DbContext.SaveChanges();
             */
            #endregion

            #region SubTemplate1
            /*check_lists cl2 = new check_lists();
            cl2.created_at = DateTime.Now;
            cl2.updated_at = DateTime.Now;
            cl2.label = "A.1";
            cl2.description = "D.1";
            cl2.workflow_state = Constants.WorkflowStates.Created;
            cl2.case_type = "CheckList";
            cl2.display_index = 1;
            cl2.repeated = 1;
            cl2.parent_id = cl1.Id;

            DbContext.check_lists.Add(cl2);
            DbContext.SaveChanges();
            */
            #endregion

            #region Fields
            /*
            field_types ft = DbContext.field_types.Where(x => x.Id == 9).First();

            fields f1 = new fields();
            f1.field_type = ft;
            f1.label = "Comment field";
            f1.description = "";
            f1.check_list_id = cl2.Id;

            DbContext.fields.Add(f1);
            DbContext.SaveChanges();
            */
            #endregion

            #region Worker
            /*
            workers worker = new workers();
            worker.first_name = "Arne";
            worker.last_name = "Jensen";
            worker.email = "aa@tak.dk";
            worker.created_at = DateTime.Now;
            worker.updated_at = DateTime.Now;
            worker.microting_uid = 21;
            worker.workflow_state = Constants.WorkflowStates.Created;
            worker.version = 69;
            DbContext.workers.Add(worker);
            DbContext.SaveChanges();
            */
            #endregion

            #region site
            /*
            sites site = new sites();
            site.name = "SiteName";
            site.microting_uid = 88;
            site.updated_at = DateTime.Now;
            site.created_at = DateTime.Now;
            site.version = 64;
            site.workflow_state = Constants.WorkflowStates.Created;
            DbContext.sites.Add(site);
            DbContext.SaveChanges();
            */
            #endregion

            #region units

            /*units unit = new units();
            unit.microting_uid = 48;
            unit.otp_code = 49;
            unit.site = site;
            unit.site_id = site.Id;
            unit.created_at = DateTime.Now;
            unit.customer_no = 348;
            unit.updated_at = DateTime.Now;
            unit.version = 9;
            unit.workflow_state = Constants.WorkflowStates.Created;

            DbContext.units.Add(unit);
            DbContext.SaveChanges();
            */
            #endregion

            #region site_workers
            /* site_workers site_workers = new site_workers();
             site_workers.created_at = DateTime.Now;
             site_workers.microting_uid = 55;
             site_workers.updated_at = DateTime.Now;
             site_workers.version = 63;
             site_workers.site = site;
             site_workers.site_id = site.Id;
             site_workers.worker = worker;
             site_workers.worker_id = worker.Id;
             site_workers.workflow_state = Constants.WorkflowStates.Created;
             DbContext.site_workers.Add(site_workers);
             DbContext.SaveChanges();
             */
            #endregion

            #region Case1
            /*
            sites site = new sites();
            site.name = "SiteName";
            DbContext.sites.Add(site);
            DbContext.SaveChanges();

            check_lists cl = new check_lists();
            cl.label = "label";

            DbContext.check_lists.Add(cl);
            DbContext.SaveChanges();



            string caseType = "AAKKAA";
            DateTime createdAt = DateTime.Now;
            int checkListId = 1;
            string microtingUId = "microting_UId";
            string microtingCheckId = "microting_Check_Id";
            string caseUId = "caseUId";
            string custom = "custom";
            cases aCase = new cases();
            aCase.status = 66;
            aCase.type = caseType;
            aCase.created_at = createdAt;
            aCase.updated_at = createdAt;
            aCase.check_list_id = checkListId;
            aCase.microting_uid = microtingUId;
            aCase.microting_check_uid = microtingCheckId;
            aCase.case_uid = caseUId;
            aCase.workflow_state = Constants.WorkflowStates.Created;
            aCase.version = 1;
            aCase.site_id = site.Id;

            aCase.custom = custom;

            DbContext.cases.Add(aCase);
            DbContext.SaveChanges();
            */
            #endregion

            #region Check List Values
            /*
            check_list_values check_List_Values = new check_list_values();

            check_List_Values.case_id = aCase.Id;
            check_List_Values.check_list_id = cl2.Id;
            check_List_Values.created_at = DateTime.Now;
            check_List_Values.status = "completed";
            check_List_Values.updated_at = DateTime.Now;
            check_List_Values.user_id = null;
            check_List_Values.version = 865;
            check_List_Values.workflow_state = Constants.WorkflowStates.Created;

            DbContext.check_list_values.Add(check_List_Values);
            DbContext.SaveChanges();
            */
            #endregion

            #region Field Values
            /*
            field_values field_Values1 = new field_values();
            field_Values1.case_id = aCase.Id;
            field_Values1.check_list = cl2;
            field_Values1.check_list_id = cl2.Id;
            field_Values1.created_at = DateTime.Now;
            field_Values1.date = DateTime.Now;
            field_Values1.done_at = DateTime.Now;
            field_Values1.field = f1;
            field_Values1.field_id = f1.Id;
            field_Values1.updated_at = DateTime.Now;
            field_Values1.user_id = null;
            field_Values1.value = "tomt1";
            field_Values1.version = 61234;
            field_Values1.worker = worker;
            field_Values1.workflow_state = Constants.WorkflowStates.Created;

            DbContext.field_values.Add(field_Values1);
            DbContext.SaveChanges();

            field_values field_Values2 = new field_values();
            field_Values2.case_id = aCase.Id;
            field_Values2.check_list = cl2;
            field_Values2.check_list_id = cl2.Id;
            field_Values2.created_at = DateTime.Now;
            field_Values2.date = DateTime.Now;
            field_Values2.done_at = DateTime.Now;
            field_Values2.field = f2;
            field_Values2.field_id = f2.Id;
            field_Values2.updated_at = DateTime.Now;
            field_Values2.user_id = null;
            field_Values2.value = "tomt2";
            field_Values2.version = 61234;
            field_Values2.worker = worker;
            field_Values2.workflow_state = Constants.WorkflowStates.Created;

            DbContext.field_values.Add(field_Values2);
            DbContext.SaveChanges();

            field_values field_Values3 = new field_values();
            field_Values3.case_id = aCase.Id;
            field_Values3.check_list = cl2;
            field_Values3.check_list_id = cl2.Id;
            field_Values3.created_at = DateTime.Now;
            field_Values3.date = DateTime.Now;
            field_Values3.done_at = DateTime.Now;
            field_Values3.field = f3;
            field_Values3.field_id = f3.Id;
            field_Values3.updated_at = DateTime.Now;
            field_Values3.user_id = null;
            field_Values3.value = "tomt3";
            field_Values3.version = 61234;
            field_Values3.worker = worker;
            field_Values3.workflow_state = Constants.WorkflowStates.Created;

            DbContext.field_values.Add(field_Values3);
            DbContext.SaveChanges();

            field_values field_Values4 = new field_values();
            field_Values4.case_id = aCase.Id;
            field_Values4.check_list = cl2;
            field_Values4.check_list_id = cl2.Id;
            field_Values4.created_at = DateTime.Now;
            field_Values4.date = DateTime.Now;
            field_Values4.done_at = DateTime.Now;
            field_Values4.field = f4;
            field_Values4.field_id = f4.Id;
            field_Values4.updated_at = DateTime.Now;
            field_Values4.user_id = null;
            field_Values4.value = "tomt4";
            field_Values4.version = 61234;
            field_Values4.worker = worker;
            field_Values4.workflow_state = Constants.WorkflowStates.Created;

            DbContext.field_values.Add(field_Values4);
            DbContext.SaveChanges();

            field_values field_Values5 = new field_values();
            field_Values5.case_id = aCase.Id;
            field_Values5.check_list = cl2;
            field_Values5.check_list_id = cl2.Id;
            field_Values5.created_at = DateTime.Now;
            field_Values5.date = DateTime.Now;
            field_Values5.done_at = DateTime.Now;
            field_Values5.field = f5;
            field_Values5.field_id = f5.Id;
            field_Values5.updated_at = DateTime.Now;
            field_Values5.user_id = null;
            field_Values5.value = "tomt5";
            field_Values5.version = 61234;
            field_Values5.worker = worker;
            field_Values5.workflow_state = Constants.WorkflowStates.Created;

            DbContext.field_values.Add(field_Values5);
            DbContext.SaveChanges();
            */
            #endregion


            // Act



            // Assert

        }


        #endregion


        //[Test]
        //public void SQL_Check_SubChecks_ReturnsCheckListValue()
        //{
        //    // Arrance
        //    #region Template1
        //    check_lists cl1 = new check_lists();
        //    cl1.created_at = DateTime.Now;
        //    cl1.updated_at = DateTime.Now;
        //    cl1.label = "A";
        //    cl1.description = "D";
        //    cl1.workflow_state = Constants.WorkflowStates.Created;
        //    cl1.case_type = "CheckList";
        //    cl1.folder_name = "Template1FolderName";
        //    cl1.display_index = 1;
        //    cl1.repeated = 1;

        //    DbContext.check_lists.Add(cl1);
        //    DbContext.SaveChanges();
        //    #endregion

        //    #region SubTemplate1
        //    check_lists cl2 = new check_lists();
        //    cl2.created_at = DateTime.Now;
        //    cl2.updated_at = DateTime.Now;
        //    cl2.label = "A.1";
        //    cl2.description = "D.1";
        //    cl2.workflow_state = Constants.WorkflowStates.Created;
        //    cl2.case_type = "CheckList";
        //    cl2.display_index = 1;
        //    cl2.repeated = 1;
        //    cl2.parent_id = cl1.Id;

        //    DbContext.check_lists.Add(cl2);
        //    DbContext.SaveChanges();

        //    #endregion

        //    #region Fields
        //    #region field1


        //    fields f1 = CreateField(1, "barcode", cl2, "e2f4fb", "custom", null, "", "Comment field description",
        //        5, 1, DbContext.field_types.Where(x => x.field_type == "comment").First(), 0, 0, 1, 0, "Comment field", 1, 55, "55", "0", 0, 0, null, 1, 0,
        //        0, 0, "", 49);
        //    //    new fields();
        //    //field_types ft1 = DbContext.field_types.Where(x => x.field_type == "comment").First();
        //    //f1.field_type = ft1;

        //    //f1.barcode_enabled = 1;
        //    //f1.barcode_type = "barcode";
        //    //f1.check_list_id = cl2.Id;
        //    //f1.color = "e2f4fb";
        //    //f1.created_at = DateTime.Now;
        //    //f1.custom = "custom";
        //    //f1.decimal_count = null;
        //    //f1.default_value = "";
        //    //f1.description = "Comment field Description";
        //    //f1.display_index = 5;
        //    //f1.dummy = 1;
        //    //f1.geolocation_enabled = 0;
        //    //f1.geolocation_forced = 0;
        //    //f1.geolocation_hidden = 1;
        //    //f1.is_num = 0;
        //    //f1.label = "Comment field";
        //    //f1.mandatory = 1;
        //    //f1.max_length = 55;
        //    //f1.max_value = "55";
        //    //f1.min_value = "0";
        //    //f1.multi = 0;
        //    //f1.optional = 0;
        //    //f1.query_type = null;
        //    //f1.read_only = 1;
        //    //f1.selected = 0;
        //    //f1.split_screen = 0;
        //    //f1.stop_on_save = 0;
        //    //f1.unit_name = "";
        //    //f1.updated_at = DateTime.Now;
        //    //f1.version = 49;
        //    //f1.workflow_state = Constants.WorkflowStates.Created;

        //    //DbContext.fields.Add(f1);
        //    //DbContext.SaveChanges();
        //    //Thread.Sleep(2000);
        //    #endregion

        //    #region field2


        //    fields f2 = CreateField(1, "barcode", cl2, "f5eafa", "custom", null, "", "showPDf Description",
        //        45, 1, DbContext.field_types.Where(x => x.field_type == "comment").First(), 0, 1, 0, 0,
        //        "ShowPdf", 0, 5, "5", "0", 0, 0, null, 0, 0, 0, 0, "", 9);
        //    //    new fields();
        //    //field_types ft2 = DbContext.field_types.Where(x => x.field_type == "comment").First();
        //    //f2.field_type = ft2;

        //    //f2.barcode_enabled = 1;
        //    //f2.barcode_type = "barcode";
        //    //f2.check_list_id = cl2.Id;
        //    //f2.color = "f5eafa";
        //    //f2.default_value = "";
        //    //f2.description = "showPDf Description";
        //    //f2.display_index = 45;
        //    //f2.dummy = 1;
        //    //f2.geolocation_enabled = 0;
        //    //f2.geolocation_forced = 1;
        //    //f2.geolocation_hidden = 0;
        //    //f2.is_num = 0;
        //    //f2.label = "ShowPdf";
        //    //f2.mandatory = 0;
        //    //f2.max_length = 5;
        //    //f2.max_value = "5";
        //    //f2.min_value = "0";
        //    //f2.multi = 0;
        //    //f2.optional = 0;
        //    //f2.query_type = null;
        //    //f2.read_only = 0;
        //    //f2.selected = 0;
        //    //f2.split_screen = 0;
        //    //f2.stop_on_save = 0;
        //    //f2.unit_name = "";
        //    //f2.updated_at = DateTime.Now;
        //    //f2.version = 9;
        //    //f2.workflow_state = Constants.WorkflowStates.Created;

        //    //DbContext.fields.Add(f2);
        //    //DbContext.SaveChanges();
        //    //Thread.Sleep(2000);

        //    #endregion

        //    #region field3

        //    fields f3 = CreateField(0, "barcode", cl2, "f0f8db", "custom", 3, "", "Number Field Description",
        //        83, 0, DbContext.field_types.Where(x => x.field_type == "number").First(), 0, 0, 1, 0,
        //        "Numberfield", 1, 8, "4865", "0", 0, 1, null, 1, 0, 0, 0, "", 1);
        //    //    new fields();
        //    //field_types ft3 = DbContext.field_types.Where(x => x.field_type == "number").First();

        //    //f3.field_type = ft3;

        //    //f3.barcode_enabled = 0;
        //    //f3.barcode_type = "barcode";
        //    //f3.check_list_id = cl2.Id;
        //    //f3.color = "f0f8db";
        //    //f3.created_at = DateTime.Now;
        //    //f3.custom = "custom";
        //    //f3.decimal_count = 3;
        //    //f3.default_value = "";
        //    //f3.description = "Number Field Description";
        //    //f3.display_index = 83;
        //    //f3.dummy = 0;
        //    //f3.geolocation_enabled = 0;
        //    //f3.geolocation_forced = 0;
        //    //f3.geolocation_hidden = 1;
        //    //f3.is_num = 0;
        //    //f3.label = "Numberfield";
        //    //f3.mandatory = 1;
        //    //f3.max_length = 8;
        //    //f3.max_value = "4865";
        //    //f3.min_value = "0";
        //    //f3.multi = 0;
        //    //f3.optional = 1;
        //    //f3.query_type = null;
        //    //f3.read_only = 1;
        //    //f3.selected = 0;
        //    //f3.split_screen = 0;
        //    //f3.stop_on_save = 0;
        //    //f3.unit_name = "";
        //    //f3.updated_at = DateTime.Now;
        //    //f3.version = 1;
        //    //f3.workflow_state = Constants.WorkflowStates.Created;



        //    //DbContext.fields.Add(f3);
        //    //DbContext.SaveChanges();
        //    //Thread.Sleep(2000);

        //    #endregion

        //    #region field4


        //    fields f4 = CreateField(1, "barcode", cl2, "fff6df", "custom", null, "", "date Description",
        //        84, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 0, 0, 1, 0,
        //        "Date", 1, 666, "41153", "0", 0, 1, null, 0, 1, 0, 0, "", 1);
        //    //    new fields();
        //    //field_types ft4 = DbContext.field_types.Where(x => x.field_type == "comment").First();
        //    //f4.field_type = ft4;

        //    //f4.barcode_enabled = 1;
        //    //f4.barcode_type = "barcode";
        //    //f4.check_list_id = cl2.Id;
        //    //f4.color = "fff6df";
        //    //f4.created_at = DateTime.Now;
        //    //f4.custom = "custom";
        //    //f4.decimal_count = null;
        //    //f4.default_value = "";
        //    //f4.description = "date Description";
        //    //f4.display_index = 84;
        //    //f4.dummy = 0;
        //    //f4.geolocation_enabled = 0;
        //    //f4.geolocation_forced = 0;
        //    //f4.geolocation_hidden = 1;
        //    //f4.is_num = 0;
        //    //f4.label = "Date";
        //    //f4.mandatory = 1;
        //    //f4.max_length = 666;
        //    //f4.max_value = "41153";
        //    //f4.min_value = "0";
        //    //f4.multi = 0;
        //    //f4.optional = 1;
        //    //f4.query_type = null;
        //    //f4.read_only = 0;
        //    //f4.selected = 1;
        //    //f4.split_screen = 0;
        //    //f4.stop_on_save = 0;
        //    //f4.unit_name = "";
        //    //f4.updated_at = DateTime.Now;
        //    //f4.version = 1;
        //    //f4.workflow_state = Constants.WorkflowStates.Created;


        //    //DbContext.fields.Add(f4);
        //    //DbContext.SaveChanges();
        //    //Thread.Sleep(2000);

        //    #endregion

        //    #region field5

        //    fields f5 = CreateField(0, "barcode", cl2, "ffe4e4", "custom", null, "", "picture Description",
        //        85, 0, DbContext.field_types.Where(x => x.field_type == "comment").First(), 1, 0, 1, 0,
        //        "Picture", 1, 69, "69", "1", 0, 1, null, 0, 1, 0, 0, "", 1);
        //    //    new fields();
        //    //field_types ft5 = DbContext.field_types.Where(x => x.field_type == "comment").First();

        //    //f5.field_type = ft5;
        //    //f5.barcode_enabled = 0;
        //    //f5.barcode_type = "barcode";
        //    //f5.check_list_id = cl2.Id;
        //    //f5.color = "ffe4e4";
        //    //f5.created_at = DateTime.Now;
        //    //f5.custom = "custom";
        //    //f5.decimal_count = null;
        //    //f5.default_value = "";
        //    //f5.description = "picture Description";
        //    //f5.display_index = 85;
        //    //f5.dummy = 0;
        //    //f5.geolocation_enabled = 1;
        //    //f5.geolocation_forced = 0;
        //    //f5.geolocation_hidden = 1;
        //    //f5.is_num = 0;
        //    //f5.label = "Picture";
        //    //f5.mandatory = 1;
        //    //f5.max_length = 69;
        //    //f5.max_value = "69";
        //    //f5.min_value = "1";
        //    //f5.multi = 0;
        //    //f5.optional = 1;
        //    //f5.query_type = null;
        //    //f5.read_only = 0;
        //    //f5.selected = 1;
        //    //f5.split_screen = 0;
        //    //f5.stop_on_save = 0;
        //    //f5.unit_name = "";
        //    //f5.updated_at = DateTime.Now;
        //    //f5.version = 1;
        //    //f5.workflow_state = Constants.WorkflowStates.Created;

        //    //DbContext.fields.Add(f5);
        //    //DbContext.SaveChanges();
        //    //Thread.Sleep(2000);

        //    #endregion


        //    #endregion


        //    // Act



        //    // Assert
        //} //private method


        #endregion

        #region (post) case
        

        

        #endregion

        //TODOS in here, Migration required
        #region Public WriteLog TODO
        [Test]
        public void SQL_WriteLog_StartLog_ReturnsLog()
        {
            // Arrance

            // Act

            // Assert
        }

        [Test]
        public void SQL_WriteLog_WriteLogEntry()
        {
            // Arrance

            // Act

            // Assert
        }


        [Test]
        public void SQL_WriteLog_WriteLogExceptionEntry()
        {
            // Arrance

            // Act

            // Assert
        }


        [Test] 
        public void SQL_WriteLog_WriteIfFailed()
        {
            // Arrance

            // Act

            // Assert
        }



        #endregion

        // Arrance

        // Act

        // Assert

        #region helperMethods
        public workers CreateWorker(string email, string firstName, string lastName, int microtingUId)
        {
            workers worker = new workers();
            worker.FirstName = firstName;
            worker.LastName = lastName;
            worker.Email = email;
            worker.CreatedAt = DateTime.Now;
            worker.UpdatedAt = DateTime.Now;
            worker.MicrotingUid = microtingUId;
            worker.WorkflowState = Constants.WorkflowStates.Created;
            worker.Version = 69;
            DbContext.workers.Add(worker);
            DbContext.SaveChanges();

            return worker;
        }
        public sites CreateSite(string name, int microtingUId)
        {

            sites site = new sites();
            site.Name = name;
            site.MicrotingUid = microtingUId;
            site.UpdatedAt = DateTime.Now;
            site.CreatedAt = DateTime.Now;
            site.Version = 64;
            site.WorkflowState = Constants.WorkflowStates.Created;
            DbContext.sites.Add(site);
            DbContext.SaveChanges();

            return site;
        }
        public units CreateUnit(int microtingUId, int otpCode, sites site, int customerNo)
        {

            units unit = new units();
            unit.MicrotingUid = microtingUId;
            unit.OtpCode = otpCode;
            unit.Site = site;
            unit.SiteId = site.Id;
            unit.CreatedAt = DateTime.Now;
            unit.CustomerNo = customerNo;
            unit.UpdatedAt = DateTime.Now;
            unit.Version = 9;
            unit.WorkflowState = Constants.WorkflowStates.Created;

            DbContext.units.Add(unit);
            DbContext.SaveChanges();

            return unit;
        }
        public site_workers CreateSiteWorker(int microtingUId, sites site, workers worker)
        {
            site_workers site_workers = new site_workers();
            site_workers.CreatedAt = DateTime.Now;
            site_workers.MicrotingUid = microtingUId;
            site_workers.UpdatedAt = DateTime.Now;
            site_workers.Version = 63;
            site_workers.Site = site;
            site_workers.SiteId = site.Id;
            site_workers.Worker = worker;
            site_workers.WorkerId = worker.Id;
            site_workers.WorkflowState = Constants.WorkflowStates.Created;
            DbContext.site_workers.Add(site_workers);
            DbContext.SaveChanges();
            return site_workers;
        }
        public check_lists CreateTemplate(string label, string description, string caseType, string folderName, int displayIndex, int repeated)
        {
            check_lists cl1 = new check_lists();
            cl1.CreatedAt = DateTime.Now;
            cl1.UpdatedAt = DateTime.Now;
            cl1.Label = label;
            cl1.Description = description;
            cl1.WorkflowState = Constants.WorkflowStates.Created;
            cl1.CaseType = caseType;
            cl1.FolderName = folderName;
            cl1.DisplayIndex = displayIndex;
            cl1.Repeated = repeated;

            DbContext.check_lists.Add(cl1);
            DbContext.SaveChanges();
            return cl1;
        }
        public check_lists CreateSubTemplate(string label, string description, string caseType, int displayIndex, int repeated, check_lists parentId)
        {
            check_lists cl2 = new check_lists();
            cl2.CreatedAt = DateTime.Now;
            cl2.UpdatedAt = DateTime.Now;
            cl2.Label = label;
            cl2.Description = description;
            cl2.WorkflowState = Constants.WorkflowStates.Created;
            cl2.CaseType = caseType;
            cl2.DisplayIndex = displayIndex;
            cl2.Repeated = repeated;
            cl2.ParentId = parentId.Id;

            DbContext.check_lists.Add(cl2);
            DbContext.SaveChanges();
            return cl2;
        }
        public fields CreateField(short? barcodeEnabled, string barcodeType, check_lists checkList, string color, string custom, int? decimalCount, string defaultValue, string description, int? displayIndex, short? dummy, field_types ft, short? geolocationEnabled, short? geolocationForced, short? geolocationHidden, short? isNum, string label, short? mandatory, int maxLength, string maxValue, string minValue, short? multi, short? optional, string queryType, short? readOnly, short? selected, short? splitScreen, short? stopOnSave, string unitName, int version)
        {

            fields f = new fields();
            f.FieldType = ft;

            f.BarcodeEnabled = barcodeEnabled;
            f.BarcodeType = barcodeType;
            f.CheckListId = checkList.Id;
            f.Color = color;
            f.CreatedAt = DateTime.Now;
            f.Custom = custom;
            f.DecimalCount = decimalCount;
            f.DefaultValue = defaultValue;
            f.Description = description;
            f.DisplayIndex = displayIndex;
            f.Dummy = dummy;
            f.GeolocationEnabled = geolocationEnabled;
            f.GeolocationForced = geolocationForced;
            f.GeolocationHidden = geolocationHidden;
            f.IsNum = isNum;
            f.Label = label;
            f.Mandatory = mandatory;
            f.MaxLength = maxLength;
            f.MaxValue = maxValue;
            f.MinValue = minValue;
            f.Multi = multi;
            f.Optional = optional;
            f.QueryType = queryType;
            f.ReadOnly = readOnly;
            f.Selected = selected;
            f.SplitScreen = splitScreen;
            f.StopOnSave = stopOnSave;
            f.UnitName = unitName;
            f.UpdatedAt = DateTime.Now;
            f.Version = version;
            f.WorkflowState = Constants.WorkflowStates.Created;

            DbContext.fields.Add(f);
            DbContext.SaveChanges();
            Thread.Sleep(2000);

            return f;
        }
        public cases CreateCase(string caseUId, check_lists checkList, DateTime created_at, string custom, DateTime? done_at, workers doneByUserId, int microtingCheckId, int microtingUId, sites site, int? status, string caseType, units unit, DateTime updated_at, int version, workers worker, string WorkFlowState)
        {

            cases aCase = new cases();

            aCase.CaseUid = caseUId;
            aCase.CheckList = checkList;
            aCase.CheckListId = checkList.Id;
            aCase.CreatedAt = created_at;
            aCase.Custom = custom;
            if (done_at != null)
            {
                aCase.DoneAt = done_at;
            }
            aCase.WorkerId = worker.Id;
            aCase.MicrotingCheckUid = microtingCheckId;
            aCase.MicrotingUid = microtingUId;
            aCase.Site = site;
            aCase.SiteId = site.Id;
            aCase.Status = status;
            aCase.Type = caseType;
            aCase.UnitId = unit.Id;
            aCase.UpdatedAt = updated_at;
            aCase.Version = version;
            aCase.Worker = worker;
            aCase.WorkflowState = WorkFlowState;
            DbContext.cases.Add(aCase);
            DbContext.SaveChanges();

            return aCase;
        }
        public field_values CreateFieldValue(cases aCase, check_lists checkList, fields f, int? ud_id, int? userId, string value, int? version, workers worker)
        {
            field_values fv = new field_values();
            fv.CaseId = aCase.Id;
            fv.CheckList = checkList;
            fv.CheckListId = checkList.Id;
            fv.CreatedAt = DateTime.Now;
            fv.Date = DateTime.Now;
            fv.DoneAt = DateTime.Now;
            fv.Field = f;
            fv.FieldId = f.Id;
            fv.UpdatedAt = DateTime.Now;
            if (ud_id != null)
            {
                fv.UploadedDataId = ud_id;
            }
            fv.WorkerId = userId;
            fv.Value = value;
            fv.Version = version;
            fv.Worker = worker;
            fv.WorkflowState = Constants.WorkflowStates.Created;

            DbContext.field_values.Add(fv);
            DbContext.SaveChanges();
            return fv;
        }
        public check_list_values CreateCheckListValue(cases aCase, check_lists checkList, string status, int? userId, int? version)
        {
            check_list_values CLV = new check_list_values();

            CLV.CaseId = aCase.Id;
            CLV.CheckListId = checkList.Id;
            CLV.CreatedAt = DateTime.Now;
            CLV.Status = status;
            CLV.UpdatedAt = DateTime.Now;
            CLV.UserId = userId;
            CLV.Version = version;
            CLV.WorkflowState = Constants.WorkflowStates.Created;

            DbContext.check_list_values.Add(CLV);
            DbContext.SaveChanges();
            return CLV;

        }
        public uploaded_data CreateUploadedData(string checkSum, string currentFile, string extension, string fileLocation, string fileName, short? local, workers worker, string uploaderType, int version)
        {
            uploaded_data UD = new uploaded_data();

            UD.Checksum = checkSum;
            UD.CreatedAt = DateTime.Now;
            UD.CurrentFile = currentFile;
            UD.ExpirationDate = DateTime.Now.AddYears(1);
            UD.Extension = extension;
            UD.FileLocation = fileLocation;
            UD.FileName = fileName;
            UD.Local = local;
            UD.UpdatedAt = DateTime.Now;
            UD.UploaderId = worker.Id;
            UD.UploaderType = uploaderType;
            UD.Version = version;
            UD.WorkflowState = Constants.WorkflowStates.Created;

            DbContext.uploaded_data.Add(UD);
            DbContext.SaveChanges();
            return UD;
        }

        public check_list_sites CreateCheckListSite(int checkListId, int siteId, int microtingUId, string workflowState, int lastCheckUid)
        {
            check_list_sites cls = new check_list_sites();
            cls.SiteId = siteId;
            cls.CheckListId = checkListId;
            cls.MicrotingUid = microtingUId;
            cls.LastCheckId = lastCheckUid;
            cls.CreatedAt = DateTime.Now;
            cls.UpdatedAt = DateTime.Now;
            cls.WorkflowState = workflowState;

            DbContext.check_list_sites.Add(cls);
            DbContext.SaveChanges();
            return cls;
        }


        #endregion

    }     
}



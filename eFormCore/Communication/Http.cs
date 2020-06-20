﻿/*
The MIT License (MIT)

Copyright (c) 2007 - 2020 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microting.eForm.Communication
{
    public class Http : IHttp
    {
        #region var
        private string protocolXml = "6";
        private string protocolEntitySearch = "1";
        private string protocolEntitySelect = "4";

        private string token;
        private string addressApi;
        private string addressBasic;
        private string addressPdfUpload;
        private string addressSpeechToText;
        private string organizationId;

        private string dllVersion;

        Tools t = new Tools();
        object _lock = new object();
        #endregion

        #region con
        public Http(string token, string comAddressBasic, string comAddressApi, string comOrganizationId, string comAddressPdfUpload, string comSpeechToText)
        {
            this.token = token;
            addressBasic = comAddressBasic;
            addressApi = comAddressApi;
            addressPdfUpload = comAddressPdfUpload;
            organizationId = comOrganizationId;
            addressSpeechToText = comSpeechToText;

            dllVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        #endregion

        #region public
        #region public API
        /// <summary>
        /// Posts the element to Microting and returns the XML encoded restponse.
        /// </summary>
        /// <param name="xmlData">Element converted to a xml encoded string.</param>
        public async Task<string> Post(string data, string siteId, string contentType = "application/x-www-form-urlencoded")
        {
            try
            {
                // to do update protocol to json
                WriteDebugConsoleLogEntry("Http.Post", $"called at {DateTime.Now}");
                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/inspection_app/integration/?token={token}&protocol={protocolXml}&site_id={siteId}&sdk_ver={dllVersion}");
                request.Method = "POST";
                byte[] content = Encoding.UTF8.GetBytes(data);
                request.ContentType = contentType;
                request.ContentLength = content.Length;

                return await PostToServer(request, content);
            }
            catch (Exception ex)
            {
                if (contentType == "application/x-www-form-urlencoded")
                {
                    return "<?xml version='1.0' encoding='UTF-8'?>\n\t<Response>\n\t\t<Value type='converterError'>" + ex.Message + "</Value>\n\t</Response>";

                }
                return  @"{
                        Value: {
                            Type: ""success"",
                            Value: """ + ex.Message + @"""
                        }

                    }";
            }
        }

        /// <summary>
        /// Retrieve the XML encoded status from Microting.
        /// </summary>
        /// <param name="elementId">Identifier of the element to retrieve status of.</param>
        public async Task<string> Status(string elementId, string siteId)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/inspection_app/integration/{elementId}?token={token}&protocol={protocolXml}&site_id={siteId}&download=false&delete=false&sdk_ver={dllVersion}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return "<?xml version='1.0' encoding='UTF-8'?>\n\t<Response>\n\t\t<Value type='error'>ConverterError: " + ex.Message + "</Value>\n\t</Response>";
            }
        }

        /// <summary>
        /// Retrieve the XML encoded results from Microting.
        /// </summary>
        /// <param name="microtingUuid">Identifier of the element to retrieve results from.</param>
        /// <param name="microtingCheckUuid">Identifier of the check to begin from.</param>
        public async Task<string> Retrieve(string microtingUuid, string microtingCheckUuid, int siteId)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/inspection_app/integration/{microtingUuid}?token={token}&protocol={protocolXml}&site_id={siteId}&download=true&delete=false&last_check_id={microtingCheckUuid}&sdk_ver={dllVersion}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return "<?xml version='1.0' encoding='UTF-8'?>\n\t<Response>\n\t\t<Value type='converterError'>" + ex.Message + "</Value>\n\t</Response>";
            }
        }

        /// <summary>
        /// Deletes a element and retrieve the XML encoded response from Microting.
        /// </summary>
        /// <param name="elementId">Identifier of the element to delete.</param>
        public async Task<string> Delete(string elementId, string siteId)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/inspection_app/integration/{elementId}?token={token}&protocol={protocolXml}&site_id={siteId}&download=false&delete=true&sdk_ver={dllVersion}");
                request.Method = "GET";

                string result = await PostToServer(request).ConfigureAwait(false);

                if (result.Contains("No database connection information was found"))
                {
                    Thread.Sleep(5000);
                    result = await PostToServer(request).ConfigureAwait(false);
                }

                return result;

            }
            catch (Exception ex)
            {
                return "<?xml version='1.0' encoding='UTF-8'?>\n\t<Response>\n\t\t<Value type='error'>ConverterError: " + ex.Message + "</Value>\n\t</Response>";
            }
        }
        #endregion

        #region public EntitySearch
        public async Task<string> EntitySearchGroupCreate(string name, string id)
        {
            try
            {
                string xmlData = "<EntityTypes><EntityType><Name><![CDATA[" + name + "]]></Name><Id>" + id + "</Id></EntityType></EntityTypes>";

                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/entity_app/entity_types?token={token}&protocol={protocolEntitySearch}&organization_id={organizationId}&sdk_ver={dllVersion}");
                request.Method = "POST";
                byte[] content = Encoding.UTF8.GetBytes(xmlData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = content.Length;

                string responseXml = await PostToServer(request, content);

                if (responseXml.Contains("workflowState=\"created"))
                    return t.Locate(responseXml, "<MicrotingUUId>", "</");
                else
                    return null;
            }
            catch (Exception ex)
            {
                return "<?xml version='1.0' encoding='UTF-8'?>\n\t<Response>\n\t\t<Value type='converterError'>" + ex.Message + "</Value>\n\t</Response>";
            }
        }

        public async Task<bool> EntitySearchGroupUpdate(int id, string name, string entityGroupMUId)
        {
            string xmlData = "<EntityTypes><EntityType><Name><![CDATA[" + name + "]]></Name><Id>" + id + "</Id></EntityType></EntityTypes>";

            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/entity_app/entity_types/{entityGroupMUId}?token={token}&protocol={protocolEntitySearch}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(xmlData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = content.Length;

            string responseXml = await PostToServer(request, content);

            if (responseXml.Contains("workflowState=\"created"))
                return true;
            else
                return false;
        }

        public async Task<bool> EntitySearchGroupDelete(string entityGroupId)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/entity_app/entity_types/{entityGroupId}?token={token}&protocol={protocolEntitySearch}&organization_id={organizationId}&sdk_ver={dllVersion}");
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";  //-- ?

                string responseXml = await PostToServer(request).ConfigureAwait(false);

                if (responseXml.Contains("Value type=\"success"))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("EntitySearchGroupDelete failed", ex);
            }
        }

        public async Task<string> EntitySearchItemCreate(string entitySearchGroupId, string name, string description, string id)
        {
            string xmlData = "<Entities><Entity>" +
                "<EntityTypeId>" + entitySearchGroupId + "</EntityTypeId><Identifier><![CDATA[" + name + "]]></Identifier><Description><![CDATA[" + description + "]]></Description>" +
                "<Km></Km><Colour></Colour><Radiocode></Radiocode>" + //Legacy. To be removed server side
                "<Id>" + id + "</Id>" +
                "</Entity></Entities>";

            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/entity_app/entities?token={token}&protocol={protocolEntitySearch}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "POST";
            byte[] content = Encoding.UTF8.GetBytes(xmlData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = content.Length;

            string responseXml = await PostToServer(request, content);

            if (responseXml.Contains("workflowState=\"created"))
                return t.Locate(responseXml, "<MicrotingUUId>", "</");
            else
                return null;
        }

        public async Task<bool> EntitySearchItemUpdate(string entitySearchGroupId, string entitySearchItemId, string name, string description, string id)
        {
            string xmlData = "<Entities><Entity>" +
                "<EntityTypeId>" + entitySearchGroupId + "</EntityTypeId><Identifier><![CDATA[" + name + "]]></Identifier><Description><![CDATA[" + description + "]]></Description>" +
                "<Km></Km><Colour></Colour><Radiocode></Radiocode>" + //Legacy. To be removed server side
                "<Id>" + id + "</Id>" +
                "</Entity></Entities>";

            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/entity_app/entities/{entitySearchItemId}?token={token}&protocol={protocolEntitySearch}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(xmlData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = content.Length;

            string newUrl = await PostToServer(request, content);

            return true;
        }

        public async Task<bool> EntitySearchItemDelete(string entitySearchItemId)
        {
            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/entity_app/entities/{entitySearchItemId}?token={token}&protocol={protocolEntitySearch}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "DELETE";
            request.ContentType = "application/x-www-form-urlencoded";  //-- ?

            string responseXml = await PostToServer(request).ConfigureAwait(false);

            if (responseXml.Contains("Value type=\"success"))
                return true;
            else
                return false;
        }
        #endregion

        #region public EntitySelect
        public async Task<string> EntitySelectGroupCreate(string name, string id)
        {
            try
            {
                //string xmlData = "{ \"model\" : { \"name\" : \"" + name + "\", \"api_uuid\" : \"" + id + "\" } }";
                JObject content_to_microting = JObject.FromObject(new { model = new { name = name, api_uuid = id } });

                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/inspection_app/searchable_item_groups.json?token={token}&protocol={protocolEntitySelect}&organization_id={organizationId}&sdk_ver={dllVersion}");
                request.Method = "POST";
                byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = content.Length;

                string responseXml = await PostToServer(request, content);

                if (responseXml.Contains("workflow_state\": \"created"))
                    return t.Locate(responseXml, "\"id\": \"", "\"");
                else
                    return null;
            }
            catch (Exception ex)
            {
                return "<?xml version='1.0' encoding='UTF-8'?>\n\t<Response>\n\t\t<Value type='converterError'>" + ex.Message + "</Value>\n\t</Response>";
            }
        }

        public async Task<bool> EntitySelectGroupUpdate(int id, string name, string entityGroupMUId)
        {
            JObject content_to_microting = JObject.FromObject(new { model = new { name = name, api_uuid = id } });

            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/inspection_app/searchable_item_groups/{entityGroupMUId}?token={token}&protocol={protocolEntitySelect}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            request = WebRequest.Create($"{newUrl}?token={token}");
            request.Method = "GET";

            string response = await PostToServer(request).ConfigureAwait(false);
            
            return response.Contains("workflow_state\": \"created");
        }

        public async Task<bool> EntitySelectGroupDelete(string entityGroupId)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/inspection_app/searchable_item_groups/{entityGroupId}.json?token={token}&protocol={protocolEntitySelect}&organization_id={organizationId}&sdk_ver={dllVersion}");
                request.Method = "DELETE";
                request.ContentType = "application/json; charset=utf-8";

                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";

                string responseXml = await PostToServer(request).ConfigureAwait(false);
                
                return responseXml.Contains("workflow_state\": \"removed");
            }
            catch (Exception ex)
            {
                throw new Exception("EntitySearchGroupDelete failed", ex);
            }
        }

        public async Task<string> EntitySelectItemCreate(string entitySelectGroupId, string name, int displayIndex, string id)
        {
            JObject content_to_microting = JObject.FromObject(new { model = new { data = name, api_uuid = id, display_order = displayIndex, searchable_group_id = entitySelectGroupId } });

            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/inspection_app/searchable_items.json?token={token}&protocol={protocolEntitySelect}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "POST";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string responseXml = await PostToServer(request, content);

            if (responseXml.Contains("workflow_state\": \"created"))
                return t.Locate(responseXml, "\"id\": \"", "\"");
            else
                return null;
        }

        public async Task<bool> EntitySelectItemUpdate(string entitySelectGroupId, string entitySelectItemId, string name, int displayIndex, string ownUUID)
        {
            JObject content_to_microting = JObject.FromObject(new { model = new { data = name, api_uuid = ownUUID, display_order = displayIndex, searchable_group_id = entitySelectGroupId } });

            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/inspection_app/searchable_items/{entitySelectItemId}?token={token}&protocol={protocolEntitySelect}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

			string newUrl = await PostToServerGetRedirect(request, content);

			request = WebRequest.Create($"{newUrl}?token={token}");
			request.Method = "GET";

			string responseXml = await PostToServer(request).ConfigureAwait(false);
			if (responseXml.Contains("workflow_state\": \"created"))
				return true;
			else
				return false;
			//         string responseXml = PostToServerNoRedirect(request, content);

			//if (responseXml.Contains("html><body>You are being <a href=") && responseXml.Contains(">redirected</a>.</body></html>"))
			//{
			//	WebRequest request2 = WebRequest.Create(addressApi + "/gwt/inspection_app/searchable_items/" + entitySelectItemId + ".json?token=" + token + "&protocol=" + protocolEntitySelect
			//		+ "&organization_id=" + organizationId + "&sdk_ver=" + dllVersion);
			//	request2.Method = "GET";
			//	string responseXml2 = PostToServer(request2);

			//	if (responseXml2.Contains("workflow_state\": \"created"))
			//		return true;
			//	else
			//		return false;
			//}
			//else
			//	throw new Exception("Unable to update EntitySelect, error was: " + responseXml);
		}

        public async Task<bool> EntitySelectItemDelete(string entitySelectItemId)
        {
            WebRequest request = WebRequest.Create(
                $"{addressApi}/gwt/inspection_app/searchable_items/{entitySelectItemId}.json?token={token}&protocol={protocolEntitySelect}&organization_id={organizationId}&sdk_ver={dllVersion}");
            request.Method = "DELETE";
            request.ContentType = "application/json; charset=utf-8";

            //string responseXml = PostToServerGetRedirect(request).ConfigureAwait(false);

			string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

			request = WebRequest.Create($"{newUrl}?token={token}");
			request.Method = "GET";

			string responseXml = await PostToServer(request).ConfigureAwait(false);
			if (responseXml.Contains("workflow_state\": \"removed"))
				return true;
			else
				return false;

			//if (responseXml.Contains("html><body>You are being <a href=") && responseXml.Contains(">redirected</a>.</body></html>"))
			//{
			//    WebRequest request2 = WebRequest.Create(addressApi + "/gwt/inspection_app/searchable_items/" + entitySelectItemId + ".json?token=" + token + "&protocol=" + protocolEntitySelect +
			//        "&organization_id=" + organizationId + "&sdk_ver=" + dllVersion);
			//    request2.Method = "GET";
			//    string responseXml2 = PostToServer(request2);

			//    if (responseXml2.Contains("workflow_state\": \"removed"))
			//        return true;
			//    else
			//        return false;
			//}
			//else
			//    return false;
		}
		#endregion

		#region public PdfUpload
		public async Task<bool> PdfUpload(string name, string hash)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string url =
                        $"{addressPdfUpload}/data_uploads/upload?token={token}&hash={hash}&extension=pdf&sdk_ver={dllVersion}";
                    await client.UploadFileTaskAsync(url, name);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region public TemplateDisplayIndexChange
        public async Task<string> TemplateDisplayIndexChange(string microtingUId, int siteId, int newDisplayIndex)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressApi}/gwt/inspection_app/integration/{microtingUId}?token={token}&protocol={protocolXml}&site_id={siteId}&download=false&delete=false&update_attributes=true&display_order={newDisplayIndex}&sdk_ver={dllVersion}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return "<?xml version='1.0' encoding='UTF-8'?>\n\t<Response>\n\t\t<Value type='error'>ConverterError: " + ex.Message + "</Value>\n\t</Response>";
                //return false;
            }
        }
        #endregion

        #region public site
        public async Task<string> SiteCreate(string name)
        {
            JObject content_to_microting = JObject.FromObject(new { name = name });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/sites?token={token}&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "POST";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            request = WebRequest.Create($"{newUrl}?token={token}");
            request.Method = "GET";

            string response = await PostToServer(request).ConfigureAwait(false);

            return response;
        }

        public async Task<bool> SiteUpdate(int id, string name)
        {
            JObject content_to_microting = JObject.FromObject(new { name = name });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/sites/{id}?token={token}&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            return true;
        }

        public async Task<string> SiteDelete(int id)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/sites/{id}?token={token}&sdk_ver={dllVersion}");
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";  //-- ?

                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw new Exception("SiteDelete failed", ex);
            }
        }

        public async Task<string> SiteLoadAllFromRemote()
        {
            WebRequest request = WebRequest.Create($"{addressBasic}/v1/sites?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return await PostToServer(request).ConfigureAwait(false);
        }
        #endregion

        #region public Worker
        public async Task<string> WorkerCreate(string firstName, string lastName, string email)
        {
            JObject content_to_microting = JObject.FromObject(new { first_name = firstName, last_name = lastName, email = email });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/users?token={token}&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "POST";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            request = WebRequest.Create($"{newUrl}?token={token}");
            request.Method = "GET";

            string response = await PostToServer(request).ConfigureAwait(false);

            return response;
        }

        public async Task<bool> WorkerUpdate(int id, string firstName, string lastName, string email)
        {
            JObject content_to_microting = JObject.FromObject(new { first_name = firstName, last_name = lastName, email = email });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/users/{id}?token={token}&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            return true;
        }

        public async Task<string> WorkerDelete(int id)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/users/{id}?token={token}&sdk_ver={dllVersion}");
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";  //-- ?

                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw new Exception("WorkerDelete failed", ex);
            }
        }

        public async Task<string> WorkerLoadAllFromRemote()
        {
            WebRequest request = WebRequest.Create($"{addressBasic}/v1/users?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return await PostToServer(request).ConfigureAwait(false);
        }
        #endregion

        #region public SiteWorker
        public async Task<string> SiteWorkerCreate(int siteId, int workerId)
        {
            JObject content_to_microting = JObject.FromObject(new { user_id = workerId, site_id = siteId });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/workers?token={token}&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "POST";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            request = WebRequest.Create($"{newUrl}?token={token}");
            request.Method = "GET";

            string response = await PostToServer(request).ConfigureAwait(false);

            return response;
        }

        public async Task<string> SiteWorkerDelete(int id)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/workers/{id}?token={token}&sdk_ver={dllVersion}");
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";  //-- ?

                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw new Exception("SiteWorkerDelete failed", ex);
            }
        }

        public async Task<string> SiteWorkerLoadAllFromRemote()
        {
            WebRequest request = WebRequest.Create($"{addressBasic}/v1/workers?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return await PostToServer(request).ConfigureAwait(false);
        }

        #endregion
        
        #region folder
        
        

        public async Task<string> FolderLoadAllFromRemote()
        {
            WebRequest request = WebRequest.Create($"{addressBasic}/v1/folders?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return await PostToServer(request).ConfigureAwait(false);
        }
        
        public async Task<string> FolderCreate(string name, string description, int? parent_id)
        {
            JObject content_to_microting = JObject.FromObject(new { name = name, description = description, parent_id = parent_id });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/folders?token={token}&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "POST";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            request = WebRequest.Create($"{newUrl}?token={token}");
            request.Method = "GET";

            string response = await PostToServer(request).ConfigureAwait(false);

            return response;
        }

        public async Task<bool> FolderUpdate(int id, string name, string description, int? parent_id)
        {
            JObject content_to_microting = JObject.FromObject(new { name = name, description = description, parent_id = parent_id });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/folders/{id}?token={token}&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            await PostToServerGetRedirect(request, content);
            return true;
        }

        public async Task<string> FolderDelete(int id)
        {            
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/folders/{id}?token={token}&sdk_ver={dllVersion}");
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";

                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";
                
                return await PostToServer(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("FolderDelete failed", ex);
            }
        }
        #endregion

        #region public Unit
        public async Task<int> UnitRequestOtp(int id)
        {
            JObject content_to_microting = JObject.FromObject(new { model = new { unit_id = id } });
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/units/{id}?token={token}&new_otp=true&model={content_to_microting}&sdk_ver={dllVersion}");
            request.Method = "PUT";
            byte[] content = Encoding.UTF8.GetBytes(content_to_microting.ToString());
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = content.Length;

            string newUrl = await PostToServerGetRedirect(request, content);

            request = WebRequest.Create($"{newUrl}?token={token}");
            request.Method = "GET";

            int response = int.Parse(JRaw.Parse(await PostToServer(request))["otp_code"].ToString());

            return response;
        }

        public async Task<string> UnitLoadAllFromRemote()
        {
            WebRequest request = WebRequest.Create($"{addressBasic}/v1/units?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return await PostToServer(request).ConfigureAwait(false);
        }
        
        public async Task<string> UnitDelete(int id)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/units/{id}?token={token}&sdk_ver={dllVersion}");
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";  //-- ?

                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw new Exception("UnitDelete failed", ex);
            }
        }

        public async Task<string> UnitMove(int unitId, int siteId)
        {
            try
            {
                JObject contentToMicroting = JObject.FromObject(new { site_id = siteId });
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/units/{unitId}?token={token}&sdk_ver={dllVersion}&model={contentToMicroting}");
                request.Method = "PUT";
                request.ContentType = "application/x-www-form-urlencoded";
                
                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("UnitDelete failed", ex);
            }
        }

        public async Task<string> UnitCreate(int siteMicrotingUid)
        {
            try
            {
                JObject contentToMicroting = JObject.FromObject(new { site_id = siteMicrotingUid } );
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v2/units/?token={token}&sdk_ver={dllVersion}&model={contentToMicroting}");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                
                string newUrl = await PostToServerGetRedirect(request).ConfigureAwait(false);

                request = WebRequest.Create($"{newUrl}?token={token}");
                request.Method = "GET";

                return await PostToServer(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception("UnitCreate failed", ex);
            }
        }
        
        #endregion

        #region public Organization
        public async Task<string> OrganizationLoadAllFromRemote()
        {
            WebRequest request = WebRequest.Create(addressBasic + "/v1/organizations?token=" + token + "&sdk_ver=" + dllVersion);
            request.Method = "GET";

            return await PostToServer(request).ConfigureAwait(false);
        }
        #endregion

        #region SpeechToText        
        public async Task<int> SpeechToText(string pathToAudioFile, string language)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string url = $"{addressSpeechToText}/audio/?token={token}&sdk_ver={dllVersion}&lang={language}";
                    byte[] responseArray = await client.UploadFileTaskAsync(url, pathToAudioFile);
                    string result = Encoding.UTF8.GetString(responseArray);
                    var parsedData = JRaw.Parse(result);
                    return int.Parse(parsedData["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to upload the file", ex);
            }
        }

        public async Task<JToken> SpeechToText(int requestId)
        {
            WebRequest request = WebRequest.Create(
                $"{addressSpeechToText}/audio/{requestId}?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            string result = await PostToServer(request).ConfigureAwait(false);
            JToken parsedData = JRaw.Parse(result);
            return parsedData;
        }
        #endregion

        #region InSight
        
        #region SurveyConfiguration

        public async Task<bool> SetSurveyConfiguration(int id, int siteId, bool addSite)
        {
            if (addSite)
            {
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/survey_configurations/{id}?token={token}&add_site=true&site_id={siteId}&sdk_ver={dllVersion}");
                request.Method = "GET";

                await PostToServer(request).ConfigureAwait(false);
            }
            else
            {
                WebRequest request = WebRequest.Create(
                    $"{addressBasic}/v1/survey_configurations/{id}?token={token}&remove_site=true&site_id={siteId}&sdk_ver={dllVersion}");
                request.Method = "GET";

                await PostToServer(request).ConfigureAwait(false);
            }
            
            return true;
        }

        public Task<string> GetAllSurveyConfigurations()
        {
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/survey_configurations?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return PostToServer(request);
        }

        public Task<string> GetSurveyConfiguration(int id)
        {
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/survey_configurations/{id}?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return PostToServer(request);
        }
        
        
        #endregion
        
        #region QuestionSet

        public Task<string> GetAllQuestionSets()
        {
            
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/question_sets?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return PostToServer(request);
        }

        public Task<string> GetQuestionSet(int id)
        {
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/question_sets/{id}?token={token}&sdk_ver={dllVersion}");
            request.Method = "GET";

            return PostToServer(request);
        }
        
        #endregion
        
        #region Answer

        public Task<string> GetLastAnswer(int questionSetId, int lastAnswerId)
        {
            WebRequest request = WebRequest.Create(
                $"{addressBasic}/v1/answers/{questionSetId}?token={token}&sdk_ver={dllVersion}&last_answer_id={lastAnswerId}");
            request.Method = "GET";

            return PostToServer(request);
        }
        
        #endregion
        
        #endregion
        
        #endregion

        #region private
        private async Task<string> PostToServer(WebRequest request, byte[] content)
        {
            Console.WriteLine($"[DBG] Http.PostToServer: Calling {request.RequestUri}");
            
            // Hack for ignoring certificate validation.
            DateTime start = DateTime.Now;
            WriteDebugConsoleLogEntry("Http.PostToServer", $"Called at {start}");
            ServicePointManager.ServerCertificateValidationCallback = Validator;
            Stream dataRequestStream = request.GetRequestStream();
            dataRequestStream.Write(content, 0, content.Length);
            dataRequestStream.Close();

            WebResponse response = request.GetResponse();

            Stream dataResponseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataResponseStream);
            string responseFromServer = await reader.ReadToEndAsync();

            // Clean up the streams.
            try
            {
                reader.Close();
                dataResponseStream.Close();
                response.Close();
            }
            catch
            {

            }

            WriteDebugConsoleLogEntry("Http.PostToServer", $"Finished at {DateTime.Now} - took {(start - DateTime.Now).ToString()}");
            return responseFromServer;
        }

        private async Task<string> PostToServerGetRedirect(WebRequest request, byte[] content)
        {
            Console.WriteLine($"[DBG] Http.PostToServerGetRedirect: Calling {request.RequestUri}");

            // Hack for ignoring certificate validation.
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            Stream dataRequestStream = request.GetRequestStream();
            dataRequestStream.Write(content, 0, content.Length);
            dataRequestStream.Close();

            HttpWebRequest httpRequest = (HttpWebRequest)request;
            httpRequest.CookieContainer = new CookieContainer();
            httpRequest.AllowAutoRedirect = false;

            WebResponse response;
            
            string newUrl = "";
            try
            {
                response = (HttpWebResponse) await httpRequest.GetResponseAsync();
            }
            catch (WebException ex)
            {
                if (ex.Message.Contains("302") || ex.Message.Contains("301"))
                {
                    response = ex.Response;
                    newUrl = response.Headers["Location"];
                }
            }
            return newUrl;
        }

        private async Task<string> PostToServerGetRedirect(WebRequest request)
        {
            Console.WriteLine($"[DBG] Http.PostToServerGetRedirect: Calling {request.RequestUri}");
            
            // Hack for ignoring certificate validation.
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            HttpWebRequest httpRequest = (HttpWebRequest)request;
            httpRequest.CookieContainer = new CookieContainer();
            httpRequest.AllowAutoRedirect = false;

            WebResponse response;
            
            string newUrl = "";
            try
            {
                response = (HttpWebResponse) await httpRequest.GetResponseAsync();
            }
            catch (WebException ex)
            {
                if (ex.Message.Contains("302") || ex.Message.Contains("301"))
                {
                    response = ex.Response;
                    newUrl = response.Headers["Location"];
                }
                else
                {
                    throw;
                }
            }

            return newUrl;
        }

        private async Task<string> PostToServerNoRedirect(WebRequest request, byte[] content)
        {
            Console.WriteLine($"[DBG] Http.PostToServerNoRedirect: Calling {request.RequestUri}");

            // Hack for ignoring certificate validation.
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            Stream dataRequestStream = request.GetRequestStream();
            dataRequestStream.Write(content, 0, content.Length);
            dataRequestStream.Close();

            HttpWebRequest httpRequest = (HttpWebRequest)request;
            httpRequest.CookieContainer = new CookieContainer();
            httpRequest.AllowAutoRedirect = false;

            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            Stream dataResponseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataResponseStream);
            string responseFromServer = await reader.ReadToEndAsync();

            // Clean up the streams.
            try
            {
                reader.Close();
                dataResponseStream.Close();
                response.Close();
            }
            catch
            {

            }

            return responseFromServer;
        }

        private async Task<string> PostToServer(WebRequest request)
        {
            Console.WriteLine($"[DBG] Http.PostToServer: Calling {request.RequestUri}");
            // Hack for ignoring certificate validation.
            
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            WebResponse response = request.GetResponse();
            Stream dataResponseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataResponseStream);
            string responseFromServer = await reader.ReadToEndAsync();

            // Clean up the streams.
            try
            {
                reader.Close();
                dataResponseStream.Close();
                response.Close();
            }
            catch
            {

            }

            return responseFromServer;
        }

        private async Task<string> PostToServerNoRedirect(WebRequest request)
        {
            Console.WriteLine($"[DBG] Http.PostToServerNoRedirect: Calling {request.RequestUri}");

            // Hack for ignoring certificate validation.
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            HttpWebRequest httpRequest = (HttpWebRequest)request;
            httpRequest.CookieContainer = new CookieContainer();
            httpRequest.AllowAutoRedirect = false;

            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            Stream dataResponseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataResponseStream);
            string responseFromServer = await reader.ReadToEndAsync();

            // Clean up the streams.
            try
            {
                reader.Close();
                dataResponseStream.Close();
                response.Close();
            }
            catch
            {

            }

            return responseFromServer;
        }

        /// <summary>
        /// This method is a hack and will allways return true
        /// </summary>
        /// <param name='sender'>
        /// The sender object
        /// </param>
        /// <param name='certificate'>
        /// The certificate object
        /// </param>
        /// <param name='chain'>
        /// The certificate chain
        /// </param>
        /// <param name='sslpolicyErrors'>
        /// SslPolicy Enum
        /// </param>
        private bool Validator(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyErrors)
        {
            return true;
        }

        private void WriteDebugConsoleLogEntry(string classMethodName, string message)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"[DBG] {classMethodName}: {message}");
            Console.ForegroundColor = oldColor;
        }

        private void WriteErrorConsoleLogEntry(string classMethodName, string message)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERR] {classMethodName}: {message}");
            Console.ForegroundColor = oldColor;
        }
        
        #endregion
    }
}
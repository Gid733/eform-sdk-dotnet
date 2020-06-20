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


using eFormCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microting.eForm.Infrastructure;

namespace eFormSDK.Integration.Tests
{
    [TestFixture]
    public abstract class DbTestFixture
    {

        protected MicrotingDbContext dbContext;
        protected string ConnectionString;
        protected bool firstRunDone = false;

        private MicrotingDbContext GetContext(string connectionStr)
        {

            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();

            if (ConnectionString.ToLower().Contains("convert zero datetime"))
            {
                dbContextOptionsBuilder.UseMySql(connectionStr);
            }
            else
            {
                dbContextOptionsBuilder.UseSqlServer(connectionStr);
            }
            dbContextOptionsBuilder.UseLazyLoadingProxies(true);
            return new MicrotingDbContext(dbContextOptionsBuilder.Options);

        }

        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine($"Starting Setup {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");

            ConnectionString = @"Server = localhost; port = 3306; Database = eformsdk-tests; user = root; Convert Zero Datetime = true;";

            dbContext = GetContext(ConnectionString);

            dbContext.Database.SetCommandTimeout(300);

            try
            {
                await ClearDb().ConfigureAwait(false);
            }
            catch
            {
            }

            if (!firstRunDone)
            {
                try
                {
                    AdminTools adminTools = new AdminTools(ConnectionString);
                    await adminTools.DbSetup("abc1234567890abc1234567890abcdef").ConfigureAwait(false);
                } catch
                {
                }

            firstRunDone = true;
            }
            await DoSetup().ConfigureAwait(false);
            Console.WriteLine($"End Setup {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");
        }

        [TearDown]
#pragma warning disable 1998
        public async Task TearDown()
#pragma warning restore 1998
        {
            Console.WriteLine($"Starting TearDown {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");
            await ClearDb().ConfigureAwait(false);

            ClearFile();
            Console.WriteLine($"End TearDown {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");

        }

        private async Task ClearDb()
        {
            Console.WriteLine($"Starting ClearDb {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");

            List<string> modelNames = new List<string>();
            modelNames.Add("case_versions");
            modelNames.Add("cases");
            modelNames.Add("field_value_versions");
            modelNames.Add("field_values");
            modelNames.Add("field_versions");
            modelNames.Add("fields");
            modelNames.Add("folder_versions");
            modelNames.Add("folders");
            modelNames.Add("check_list_site_versions");
            modelNames.Add("check_list_sites");
            modelNames.Add("check_list_value_versions");
            modelNames.Add("check_list_values");
            modelNames.Add("taggings");
            modelNames.Add("tagging_versions");
            modelNames.Add("tags");
            modelNames.Add("tag_versions");
            modelNames.Add("check_list_versions");
            modelNames.Add("check_lists");
            modelNames.Add("entity_group_versions");
            modelNames.Add("entity_groups");
            modelNames.Add("entity_item_versions");
            modelNames.Add("entity_items");
            modelNames.Add("log_exceptions");
            modelNames.Add("logs");
            modelNames.Add("notification_versions");
            modelNames.Add("notifications");
//            modelNames.Add("setting_versions");
//            modelNames.Add("settings");
            modelNames.Add("unit_versions");
            modelNames.Add("units");
            modelNames.Add("site_worker_versions");
            modelNames.Add("site_workers");
            modelNames.Add("worker_versions");
            modelNames.Add("workers");
            modelNames.Add("site_versions");
            modelNames.Add("sites");
            modelNames.Add("uploaded_data");
            modelNames.Add("uploaded_data_versions");
//            modelNames.Add("field_types");
            modelNames.Add("survey_configurations");
            modelNames.Add("survey_configuration_versions");
            modelNames.Add("site_survey_configurations");
            modelNames.Add("site_survey_configuration_versions");
            modelNames.Add("SiteTagVersions");
            modelNames.Add("SiteTags");
            modelNames.Add("languages");
            modelNames.Add("language_versions");
            modelNames.Add("question_sets");
            modelNames.Add("question_set_versions");
            modelNames.Add("questions");
            modelNames.Add("question_versions");
            modelNames.Add("options");
            modelNames.Add("option_versions");
            modelNames.Add("answers");
            modelNames.Add("answer_versions");
            modelNames.Add("answer_values");
            modelNames.Add("answer_value_versions");
            modelNames.Add("QuestionTranslationVersions");
            modelNames.Add("QuestionTranslations");
            modelNames.Add("OptionTranslationVersions");
            modelNames.Add("OptionTranslations");
            modelNames.Add("LanguageQuestionSetVersions");
            modelNames.Add("LanguageQuestionSets");

            foreach (var modelName in modelNames)
            {
                try
                {
                    string sqlCmd = string.Empty;
                    if(dbContext.Database.IsMySql())
                    {
                        sqlCmd = $"SET FOREIGN_KEY_CHECKS = 0;TRUNCATE `eformsdk-tests`.`{modelName}`";
                    }
                    else
                    {
                        sqlCmd = $"DELETE FROM [{modelName}]";
                    }
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
                    await dbContext.Database.ExecuteSqlCommandAsync(sqlCmd).ConfigureAwait(false);
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
                }
                catch (Exception ex)
                {
                    if (!ex.Message.Contains("Unknown database"))
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.WriteLine($"End ClearDb {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");

        }
        private string path;

        private void ClearFile()
        {
            Console.WriteLine($"Starting ClearFile {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");

            path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            path = System.IO.Path.GetDirectoryName(path).Replace(@"file:", "");

            string picturePath;


            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                picturePath = path + @"\output\dataFolder\picture\Deleted";
            }
            else
            {
                picturePath = path + @"/output/dataFolder/picture/Deleted";
            }

            DirectoryInfo diPic = new DirectoryInfo(picturePath);

            try
            {
                foreach (FileInfo file in diPic.GetFiles())
                {
                    file.Delete();
                }
            }
            catch { }

            Console.WriteLine($"End ClearFile {DateTime.Now.ToString(CultureInfo.CurrentCulture)}");

        }
#pragma warning disable 1998
        public virtual async Task DoSetup() { }
#pragma warning restore 1998

    }
}

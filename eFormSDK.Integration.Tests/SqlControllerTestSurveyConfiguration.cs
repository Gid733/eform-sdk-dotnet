/*
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
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microting.eForm;
using Microting.eForm.Dto;
using Microting.eForm.Helpers;
using Microting.eForm.Infrastructure;
using Microting.eForm.Infrastructure.Constants;
using Microting.eForm.Infrastructure.Data.Entities;
using Microting.eForm.Infrastructure.Helpers;

namespace eFormSDK.Integration.Tests 
{
    public class SqlControllerTestSurveyConfiguration : DbTestFixture
    {
        private SqlController sut;
        private TestHelpers testHelpers;

        public override async Task DoSetup()
        {
            #region Setup SettingsTableContent

            DbContextHelper dbContextHelper = new DbContextHelper(ConnectionString);
            SqlController sql = new SqlController(dbContextHelper);
            await sql.SettingUpdate(Settings.token, "abc1234567890abc1234567890abcdef");
            await sql.SettingUpdate(Settings.firstRunDone, "true");
            await sql.SettingUpdate(Settings.knownSitesDone, "true");
            #endregion

            sut = new SqlController(dbContextHelper);
            sut.StartLog(new CoreBase());
            testHelpers = new TestHelpers();
            await sut.SettingUpdate(Settings.fileLocationPicture, @"\output\dataFolder\picture\");
            await sut.SettingUpdate(Settings.fileLocationPdf, @"\output\dataFolder\pdf\");
            await sut.SettingUpdate(Settings.fileLocationJasper, @"\output\dataFolder\reports\");
        }

        [Test]
        public async Task surveyConfiguration_Create_DoesCreate()
        {
            // Arrange
            Random rnd = new Random();
            
            
            question_sets questionSet = new question_sets()
            {
                ParentId = 0
            };
            
            await questionSet.Create(dbContext).ConfigureAwait(false);

            survey_configurations surveyConfigurations = new survey_configurations
            {
                Name = Guid.NewGuid().ToString(),
                Stop = DateTime.UtcNow,
                Start = DateTime.UtcNow,
                TimeOut = rnd.Next(1, 255),
                TimeToLive = rnd.Next(1, 255),
                QuestionSetId = questionSet.Id
            };

            // Act
            await surveyConfigurations.Create(dbContext).ConfigureAwait(false);

            survey_configurations dbSurveyConfigurations = dbContext.survey_configurations.AsNoTracking().First();
            survey_configuration_versions dbSurveyConfigurationVersions =
                dbContext.survey_configuration_versions.AsNoTracking().First();
            // Assert
            Assert.NotNull(dbSurveyConfigurations);
            Assert.NotNull(dbSurveyConfigurationVersions);
            
            Assert.AreEqual(surveyConfigurations.Name, dbSurveyConfigurations.Name);
            Assert.AreEqual(surveyConfigurations.Stop.ToString(), dbSurveyConfigurations.Stop.ToString());
            Assert.AreEqual(surveyConfigurations.Start.ToString(), dbSurveyConfigurations.Start.ToString());
            Assert.AreEqual(surveyConfigurations.TimeOut, dbSurveyConfigurations.TimeOut);
            Assert.AreEqual(surveyConfigurations.TimeToLive, dbSurveyConfigurations.TimeToLive);

        }     
        [Test]
        public async Task surveyConfiguration_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();
            
            question_sets questionSet = new question_sets()
            {
                ParentId = 0
            };
            
            await questionSet.Create(dbContext).ConfigureAwait(false);

            string oldName = Guid.NewGuid().ToString();
            survey_configurations surveyConfiguration = new survey_configurations
            {
                Name = oldName,
                Stop = DateTime.UtcNow,
                Start = DateTime.UtcNow,
                TimeOut = rnd.Next(1, 255),
                TimeToLive = rnd.Next(1, 255),
                QuestionSetId = questionSet.Id
            };
            
            await surveyConfiguration.Create(dbContext).ConfigureAwait(false);
            // Act
            
            string newName = Guid.NewGuid().ToString();
            surveyConfiguration.Name = newName;
            await surveyConfiguration.Update(dbContext).ConfigureAwait(false);

            survey_configurations dbSurveyConfigurations = dbContext.survey_configurations.AsNoTracking().First();
            survey_configuration_versions dbSurveyConfigurationVersions =
                dbContext.survey_configuration_versions.AsNoTracking().First();
            // Assert
            Assert.NotNull(dbSurveyConfigurations);
            Assert.NotNull(dbSurveyConfigurationVersions);
            
            Assert.AreNotEqual(oldName, dbSurveyConfigurations.Name);
            Assert.AreEqual(newName, dbSurveyConfigurations.Name);
            Assert.AreEqual(surveyConfiguration.Stop.ToString(), dbSurveyConfigurations.Stop.ToString());
            Assert.AreEqual(surveyConfiguration.Start.ToString(), dbSurveyConfigurations.Start.ToString());
            Assert.AreEqual(surveyConfiguration.TimeOut, dbSurveyConfigurations.TimeOut);
            Assert.AreEqual(surveyConfiguration.TimeToLive, dbSurveyConfigurations.TimeToLive);

        }
        [Test]
        public async Task surveyConfiguration_Delete_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();
            
            question_sets questionSet = new question_sets()
            {
                ParentId = 0
            };
            
            await questionSet.Create(dbContext).ConfigureAwait(false);

            string oldName = Guid.NewGuid().ToString();
            survey_configurations surveyConfiguration = new survey_configurations
            {
                Name = oldName,
                Stop = DateTime.UtcNow,
                Start = DateTime.UtcNow,
                TimeOut = rnd.Next(1, 255),
                TimeToLive = rnd.Next(1, 255),
                QuestionSetId = questionSet.Id
            };
            
            await surveyConfiguration.Create(dbContext).ConfigureAwait(false);
            // Act

            await surveyConfiguration.Delete(dbContext);

            survey_configurations dbSurveyConfigurations = dbContext.survey_configurations.AsNoTracking().First();
            survey_configuration_versions dbSurveyConfigurationVersions =
                dbContext.survey_configuration_versions.AsNoTracking().First();
            // Assert
            Assert.NotNull(dbSurveyConfigurations);
            Assert.NotNull(dbSurveyConfigurationVersions);
            
            Assert.AreEqual(oldName, dbSurveyConfigurations.Name);
            Assert.AreEqual(surveyConfiguration.Stop.ToString(), dbSurveyConfigurations.Stop.ToString());
            Assert.AreEqual(surveyConfiguration.Start.ToString(), dbSurveyConfigurations.Start.ToString());
            Assert.AreEqual(surveyConfiguration.TimeOut, dbSurveyConfigurations.TimeOut);
            Assert.AreEqual(surveyConfiguration.TimeToLive, dbSurveyConfigurations.TimeToLive);
            Assert.AreEqual(surveyConfiguration.WorkflowState, Constants.WorkflowStates.Removed);

        }   
    }
}
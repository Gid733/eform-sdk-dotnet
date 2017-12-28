﻿using eFormSqlController;
using NUnit.Framework;

namespace eFormSDK.Integration.Tests
{
    [TestFixture]
    public abstract class DbTestFixture
    {
        protected MicrotingDbMs DbContext;

        [SetUp]
        public void Setup()
        {
            const string connnectionString = @"data source=(LocalDb)\SharedInstance;Initial catalog=eformsdk-tests";

            DbContext = new MicrotingDbMs(connnectionString);
            DbContext.Database.CreateIfNotExists();

            DbContext.Database.Initialize(false);

            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {
            DbContext.Database.Delete();
            DbContext.Dispose();
        }

        public virtual void DoSetup() { }
    }

}

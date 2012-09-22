using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JackWeb.Framework.Environment;

namespace JackWeb.Tests.Environment
{
    [TestFixture]
    public class CloudInformationTest
    {
        [Test]
        public void Given_No_Name_Then_Connection_Defaults_To_Default_Value()
        {
            var cloudInfo = new CloudInformation();

            Assert.AreEqual(CloudInformation.DEFAULT_DATABASE_CONNECTION_STRING_AZURE, cloudInfo.InitialDatabaseConnectionString);
        }
    }
}

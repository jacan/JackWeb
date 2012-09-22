using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JackWeb.Framework.Environment.Orm;

namespace JackWeb.Tests.Environment.Orm
{
    [TestFixture]
    public class NConfigurationTest
    {
        [Test]
        public void Given_ConnectionName_And_Not_Testing_When_ConfigureDefault_Then_ISessionFactory_Is_Not_Null()
        {
            var nConfig = new NConfiguration();

            var sessionConfiguration = nConfig.ConfigureDefault(connectionKeyStringKey: "Azure", isTesting: false);

            Assert.IsNotNull(sessionConfiguration);
        }

        [Test]
        public void Given_Invalid_ConnectionString_Then_NullReferenceException_Is_Thrown()
        {
            var nConfig = new NConfiguration();

            Assert.That(
                () => nConfig.ConfigureDefault(connectionKeyStringKey: "NonExistingConnectionString", isTesting: false), 
                Throws.TypeOf<NullReferenceException>()
            );
        }
    }
}

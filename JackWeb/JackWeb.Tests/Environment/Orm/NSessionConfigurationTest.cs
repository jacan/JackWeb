using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JackWeb.Framework.Environment.Orm;

namespace JackWeb.Tests.Environment.Orm
{
    [TestFixture]
    public class NSessionConfigurationTest
    {
        [Test]
        public void Given_ConnectionString_When_Creating_Session_Then_Session_Is_Not_Null()
        {
            var nSessionConfig = new NSessionConfiguration("Azure");

            var session = nSessionConfig.CreateSession();

            Assert.IsNotNull(session);
        }
    }
}

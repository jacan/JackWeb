using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JackWeb.Data;
using JackWeb.Tests.Fakes;

namespace JackWeb.Tests.JackWeb.Data
{
    [TestFixture]
    public class RepositoryTest : TestBase
    {
        [Test]
        public void Given_New_Poco_When_Add_Then_Poco_Is_Saved_As_Expected()
        {
            var repository = new Repository<IPogo>(base.Session);

            repository.Add(FakeFactory.CreateFakePogo());
       
        }
    }
}

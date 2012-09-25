using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JackWeb.Framework.Configuration.Injection;
using StructureMap;
using NHibernate;

namespace JackWeb.Tests.JackWeb.Framework.Injection
{
	[TestFixture]
	public class InjectorTest
	{
		[Test]
		public void Given_Injector_When_Prepare_Then_ISession_Is_Returned_As_Expected()
		{
			var injector = new Injector();

			injector.Prepare();
			var session = ObjectFactory.GetInstance<ISession>();

			Assert.IsNotNull(session);
		}
	}
}

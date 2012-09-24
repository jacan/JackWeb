using JackWeb.Framework.Configuration.Injection;
using NHibernate;

namespace JackWeb.Tests
{
	public class TestBase
	{
		private IInject _injector;

		public TestBase()
		{
			_injector = new Injector();
			_injector.Prepare();
		}

		protected ISession Session
		{
			get
			{
				return _injector.GetInstance<ISession>();
			}
		}
	}
}

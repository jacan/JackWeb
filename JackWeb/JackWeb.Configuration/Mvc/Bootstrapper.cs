using System.Web.Mvc;
using JackWeb.Framework.Configuration.Injection;

namespace JackWeb.Framework.Configuration.Mvc
{
	public class Bootstrapper
	{
		protected readonly IInject _injector;

		public Bootstrapper(IInject injector)
		{
			_injector = injector;
		}

		public void RunIocBootstrapping()
		{
			ControllerBuilder.Current.SetControllerFactory(new ControllerInjector(_injector));
		}
	}
}

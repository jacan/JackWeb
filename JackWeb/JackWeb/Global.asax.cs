using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JackWeb.Framework.Configuration.Injection;
using JackWeb.Framework.Configuration.Mvc;

namespace JackWeb
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterAuth();

			ConfigureIOC();
		}

		protected void ConfigureIOC()
		{
			var iocContainer = new Injector();
			iocContainer.Prepare();

			var mvcControllerBootstrapping = new Bootstrapper(iocContainer);
			mvcControllerBootstrapping.RunIocBootstrapping();
		}
	}
}

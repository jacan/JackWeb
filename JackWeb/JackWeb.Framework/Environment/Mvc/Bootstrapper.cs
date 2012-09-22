using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using JackWeb.Framework.Injection;

namespace JackWeb.Framework.Environment.Mvc
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

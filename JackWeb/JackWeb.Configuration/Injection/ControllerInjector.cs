using System;
using System.Web.Mvc;
using StructureMap;

namespace JackWeb.Framework.Configuration.Injection
{
	public class ControllerInjector : DefaultControllerFactory
	{
		protected readonly IInject _locator;

		public ControllerInjector(IInject locator)
		{
			_locator = locator;
		}


		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			if (requestContext == null || controllerType == null)
			{
				return null;
			}

			try
			{
				return (Controller)_locator.GetInstance(controllerType);
			}
			catch (StructureMapException e)
			{
				throw new Exception(ObjectFactory.WhatDoIHave());
			}
		}
	}
}

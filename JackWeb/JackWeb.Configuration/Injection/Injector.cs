using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using JackWeb.Data;
using JackWeb.Framework.Environment.Orm;
using JackWeb.Framework.Environment.Orm.Codefirst;
using NHibernate;
using StructureMap;
using JackWeb.Configuration;

namespace JackWeb.Framework.Configuration.Injection
{
	public class Injector : IInject
	{
		public void Prepare()
		{
			ObjectFactory.Initialize(x =>
			{
				x.For<ISessionFactory>()
					.Singleton()
					.Use(() => new NSessionConfiguration("Azure").CreateSession());

				x.For<ISession>()
					.HybridHttpOrThreadLocalScoped()
					.Use(() => ObjectFactory.GetInstance<ISessionFactory>().OpenSession());

				x.For<IPersistenceConfiguration>().Use<PersistenceConfiguration>();
				x.For<DefaultAutomappingConfiguration>().Use<NMapAutoConfiguration>();
				x.For<IReferenceConvention>().Use<NCascadeConvention>();

				x.ForConcreteType<NConfiguration>()
					.Configure
					.SetProperty(
					o => o.MapPersistenceModel = new Func<AutoPersistenceModel>(GetInstance<IPersistenceConfiguration>().CreatePersistenceModel));

				x.For<IInject>()
					.Use<Injector>();

				x.Scan(scan =>
				{
					scan.Assembly(typeof(IRepository<>).Assembly);
					scan.WithDefaultConventions();
					x.For(typeof(IRepository<>)).Use(typeof(Repository<>));
				});
			});
		}

		public T GetInstance<T>()
		{
			return ObjectFactory.GetInstance<T>();
		}

		public object GetInstance(Type t)
		{
			return ObjectFactory.GetInstance(t);
		}


		public string VerboseConfiguration()
		{
			return ObjectFactory.WhatDoIHave();
		}
	}
}

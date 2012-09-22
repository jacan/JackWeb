using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using NHibernate;
using JackWeb.Framework.Environment.Orm;
using JackWeb.Data;

namespace JackWeb.Framework.Injection
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

                x.For<IInject>()
                    .Use<Injector>();

                x.Scan(scan =>  {
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
    }
}

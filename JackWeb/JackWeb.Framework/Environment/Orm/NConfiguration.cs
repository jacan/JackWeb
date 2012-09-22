using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace JackWeb.Framework.Environment.Orm
{
    public class NConfiguration
    {
        public Configuration ConfigureDefault(string connectionKeyStringKey, bool isTesting=false)
        {
            var fluentConfig = Fluently.Configure();
            
            var test = System.Configuration.ConfigurationManager.ConnectionStrings["Azure"];

            fluentConfig = isTesting ? 
                fluentConfig.Database(SQLiteConfiguration.Standard.InMemory()) :
                fluentConfig.Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => 
                        c.Is(connectionKeyStringKey)
                    )
                );

            fluentConfig = DoMappingsFromAssembly(fluentConfig);

            return fluentConfig.BuildConfiguration();
        }

        public Configuration ConfigureDefault(NConnection connection)
        {
            var fluentConfig = Fluently.Configure();

            fluentConfig = connection.IsTesting ?
                fluentConfig.Database(SQLiteConfiguration.Standard.InMemory()) :
                fluentConfig.Database(
                    MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => {
                        c.Server(connection.Server);
                        c.Database(connection.Database);
                        c.Username(connection.User);
                        c.Password(connection.Password);

                        if (connection.TrustedConnection)
                        {
                            c.TrustedConnection();
                        }
                    })  
                );

            fluentConfig = DoMappingsFromAssembly(fluentConfig);

            return fluentConfig.BuildConfiguration();
        }

        protected virtual FluentConfiguration DoMappingsFromAssembly(FluentConfiguration fluentConfig)
        {
            return fluentConfig
                .Mappings(x =>
                {
                    x.FluentMappings.AddFromAssemblyOf<JackWeb.Data.Collectors.FacebookCollector>();
                });
        }
    }
}

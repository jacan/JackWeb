using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;

namespace JackWeb.Framework.Environment.Orm
{
	public class NConfiguration
	{
		public NConfiguration()
		{
			MapPersistenceModel = null;
		}

		public Func<AutoPersistenceModel> MapPersistenceModel
		{
			get;
			set;
		}

		public Configuration ConfigureDefault(string connectionKeyStringKey, bool isTesting = false)
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

			DoPostConfiguration(fluentConfig);

			return fluentConfig.BuildConfiguration();
		}

		public Configuration ConfigureDefault(NConnection connection)
		{
			var fluentConfig = Fluently.Configure();

			fluentConfig = connection.IsTesting ?
				fluentConfig.Database(SQLiteConfiguration.Standard.InMemory()) :
				fluentConfig.Database(
					MsSqlConfiguration.MsSql2008
					.ConnectionString(c =>
					{
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

			DoPostConfiguration(fluentConfig);

			return fluentConfig.BuildConfiguration();
		}

		protected virtual void DoPostConfiguration(FluentConfiguration fluentConfig)
		{
			fluentConfig
				.Mappings(x => { x.AutoMappings.Add(MapPersistenceModel.Invoke()); })
				.ExposeConfiguration(ExportSchemaToDb);
		}

		public void CreateSchema(Configuration configuration, string filenameTarget)
		{
			var schemaExport = new SchemaExport(configuration);
			schemaExport.SetOutputFile(filenameTarget);
			schemaExport.Create(false, true);
		}

		public void ExportSchemaToDb(Configuration configuration)
		{
			var schemaExport = new SchemaExport(configuration);
			schemaExport.Execute(false, true, false);
		}
	}
}

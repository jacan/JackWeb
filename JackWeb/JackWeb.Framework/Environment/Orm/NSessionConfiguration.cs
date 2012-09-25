using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Configuration;

namespace JackWeb.Framework.Environment.Orm
{
	public class NSessionConfiguration
	{
		private readonly string _connectionString;
		protected ISessionFactory _sessionFactory;

		public NSessionConfiguration(string connectionKey)
		{
			_connectionString = ConfigurationManager.ConnectionStrings[connectionKey].ConnectionString;
		}

		public ISessionFactory CreateSession()
		{
			if (_sessionFactory == null)
			{
				var nConfig = new NConfiguration();
				var createdConfig = nConfig.ConfigureDefault(_connectionString);

				_sessionFactory = createdConfig.BuildSessionFactory();
			}

			return _sessionFactory;
		}
	}
}

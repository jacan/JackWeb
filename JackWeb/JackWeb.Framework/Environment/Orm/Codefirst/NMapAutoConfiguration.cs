using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using JackWeb.Framework.Extensions;

namespace JackWeb.Framework.Environment.Orm.Codefirst
{
	public class NMapAutoConfiguration : DefaultAutomappingConfiguration
	{
		protected IList<string> _namespaceToMap;

		public NMapAutoConfiguration(params string[] namespacesToMap)
		{
			_namespaceToMap = namespacesToMap.ToList();
		}

		public override bool ShouldMap(Type type)
		{
			return _namespaceToMap
				.SingleOrDefault(x => x.Equals(_namespaceToMap))
				.IsNotNull();
		}
	}
}

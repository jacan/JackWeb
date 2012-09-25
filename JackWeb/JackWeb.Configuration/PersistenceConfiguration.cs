using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions;

namespace JackWeb.Configuration
{
	public class PersistenceConfiguration
	{
		public DefaultAutomappingConfiguration MappingConfiguration
		{
			get;
			set;
		}

		public IReferenceConvention CascadeConvention
		{
			get;
			set;
		}

		public PersistenceConfiguration()
		{
			MappingConfiguration = null;
			CascadeConvention = null;
		}

		public PersistenceConfiguration(DefaultAutomappingConfiguration configuration, IReferenceConvention cascadeConvention)
		{
			MappingConfiguration = configuration;
			CascadeConvention = cascadeConvention;
		}

		public AutoPersistenceModel CreatePersistenceModel()
		{
			var persistenceModel = new AutoPersistenceModel();

			persistenceModel
				.AddMappingsFromAssemblyOf<JackWeb.Data.Entities.IEntityStandardDefinition>()
				.AddMappingsFromAssemblyOf<JackWeb.Data.Entities.Tech.TechChoiceReason>()
				.Conventions.Add(CascadeConvention);

			return persistenceModel;
		}
	}
}

using FluentNHibernate.Automapping;

namespace JackWeb.Configuration
{
	public interface IPersistenceConfiguration
	{
		AutoPersistenceModel CreatePersistenceModel();
	}
}

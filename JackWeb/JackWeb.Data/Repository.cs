using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

namespace JackWeb.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public void Add(TEntity entity)
        {
            _session.Save(entity);    
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _session.Query<TEntity>()
                .ToList();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate, bool has)
        {
            return _session.Query<TEntity>()
                .Where(predicate)
                .ToList();
        }
    }
}

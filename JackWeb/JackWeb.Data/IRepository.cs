using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.Data
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
		void DoStuff();
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate, bool has);
		// some crappy change
    }
}

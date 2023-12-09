using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class CasosRepository : ICasosRepository
    {
        public bool Exists(Expression<Func<Casos, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Casos> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Casos GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(Casos entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Casos entity)
        {
            throw new NotImplementedException();
        }
    }
}

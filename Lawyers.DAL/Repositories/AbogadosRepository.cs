using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class AbogadosRepository : IAbogadosRepository
    {
        public bool Exists(Expression<Func<Abogados, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Abogados> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Abogados GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(Abogados entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Abogados entity)
        {
            throw new NotImplementedException();
        }
    }
}

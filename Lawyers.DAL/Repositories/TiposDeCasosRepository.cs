using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class TiposDeCasosRepository : ITiposDeCasosRepository
    {
        public bool Exists(Expression<Func<TiposDeCasos, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TiposDeCasos> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TiposDeCasos GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(TiposDeCasos entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TiposDeCasos entity)
        {
            throw new NotImplementedException();
        }
    }
}

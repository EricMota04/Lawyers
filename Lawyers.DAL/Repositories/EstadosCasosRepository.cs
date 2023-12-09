using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class EstadosCasosRepository : IEstadosCasosRepository
    {
        public bool Exists(Expression<Func<EstadosCasos, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadosCasos> GetEntities()
        {
            throw new NotImplementedException();
        }

        public EstadosCasos GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(EstadosCasos entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadosCasos entity)
        {
            throw new NotImplementedException();
        }
    }
}

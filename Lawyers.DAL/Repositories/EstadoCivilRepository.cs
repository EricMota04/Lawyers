using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class EstadoCivilRepository : IEstadoCivilRepository
    {
        public bool Exists(Expression<Func<EstadoCivil, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoCivil> GetEntities()
        {
            throw new NotImplementedException();
        }

        public EstadoCivil GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(EstadoCivil entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadoCivil entity)
        {
            throw new NotImplementedException();
        }
    }
}

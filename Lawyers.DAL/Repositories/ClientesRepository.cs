using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        public bool Exists(Expression<Func<Clientes, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clientes> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Clientes GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(Clientes entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Clientes entity)
        {
            throw new NotImplementedException();
        }
    }
}

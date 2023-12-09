using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        public bool Exists(Expression<Func<Roles, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Roles> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Roles GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(Roles entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Roles entity)
        {
            throw new NotImplementedException();
        }
    }
}

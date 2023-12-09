using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public bool Exists(Expression<Func<Usuarios, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuarios> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Usuarios GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuarios entity)
        {
            throw new NotImplementedException();
        }
    }
}

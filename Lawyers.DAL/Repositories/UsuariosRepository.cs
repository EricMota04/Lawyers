using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ILogger _logger;
        private readonly LawyersContext _context;
        public UsuariosRepository(LawyersContext context, ILogger<UsuariosRepository> logger) 
        {
            this._context = context;
            this._logger = logger;
        }

        public bool Exists(Expression<Func<Usuarios, bool>> filter)
        {
            return _context.USUARIOS.Any(filter);
        }

        public IEnumerable<Usuarios> GetEntities()
        {
            return _context.USUARIOS.ToList();
        }

        public Usuarios GetEntity(int entityid)
        {
            return _context.USUARIOS.Find(entityid);
        }

        public void Save(Usuarios entity)
        {
            _context.USUARIOS.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Usuarios entity)
        {
            try
            {
                Usuarios usuarioModificar = GetEntity(entity.Id);
                usuarioModificar.Usuario = entity.Usuario;
                usuarioModificar.Contrasena = entity.Contrasena;
                usuarioModificar.RolId = entity.RolId;

                _context.USUARIOS.Update(usuarioModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

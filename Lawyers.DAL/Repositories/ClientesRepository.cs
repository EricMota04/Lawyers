using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly LawyersContext _context;
        private readonly ILogger<Clientes> _logger;
        public ClientesRepository(LawyersContext context, ILogger<Clientes> logger) {
        
            _context = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Clientes, bool>> filter)
        {
            return _context.Clientes.Any(filter);
        }

        public IEnumerable<Clientes> GetEntities()
        {
            return _context.Clientes.ToList();
        }

        public Clientes GetEntity(int entityid)
        {
            return _context.Clientes.Find(entityid);
        }

        public void Save(Clientes entity)
        {
            _context.Clientes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Clientes entity)
        {
            try
            {
                Clientes ClienteModificar = GetEntity(entity.Id);
                ClienteModificar.Cedula = entity.Cedula;
                ClienteModificar.Nombre = entity.Nombre;
                ClienteModificar.Apellido = entity.Apellido;
                ClienteModificar.celular = entity.celular;
                ClienteModificar.Telefono = entity.Telefono;
                ClienteModificar.correo = entity.correo;
                ClienteModificar.Direccion = entity.Direccion;
                ClienteModificar.IdEstadoCivil = entity.IdEstadoCivil;

                _context.Update(ClienteModificar);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

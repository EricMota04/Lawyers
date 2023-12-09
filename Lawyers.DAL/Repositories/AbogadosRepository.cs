using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class AbogadosRepository : IAbogadosRepository
    {
        private readonly LawyersContext _context;
        private readonly ILogger<Abogados> _logger;
        
        public AbogadosRepository(LawyersContext context, ILogger<Abogados> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Abogados, bool>> filter)
        {
            return _context.Abogados.Any(filter);
        }

        public IEnumerable<Abogados> GetEntities()
        {
            return _context.Abogados.ToList();
        }

        public Abogados GetEntity(int entityid)
        {
            return _context.Abogados.Find(entityid);
        }

        public void Save(Abogados entity)
        {
            _context.Abogados.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Abogados entity)
        {
            try
            {
                Abogados AbogadoModificar = GetEntity(entity.Id);
                AbogadoModificar.Nombre = entity.Nombre;
                AbogadoModificar.Apellido = entity.Apellido;
                AbogadoModificar.celular = entity.celular;
                AbogadoModificar.Telefono = entity.Telefono;
                AbogadoModificar.correo = entity.correo;
                
                _context.Update(AbogadoModificar);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

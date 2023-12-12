using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class CasosRepository : ICasosRepository
    {
        private readonly LawyersContext _context;
        private readonly ILogger<Casos> _logger;
        public CasosRepository(LawyersContext context, ILogger<Casos> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Casos, bool>> filter)
        {
            return _context.Casos.Any(filter);
        }

        public IEnumerable<Casos> GetEntities()
        {
            return _context.Casos.ToList();
        }

        public Casos GetEntity(int entityid)
        {
            return _context.Casos.Find(entityid);
        }

        public void Save(Casos entity)
        {
            _context.Casos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Casos entity)
        {
            try
            {
                Casos CasoModificar = GetEntity(entity.Id);

                CasoModificar.Id = entity.Id;
                CasoModificar.FechaCaso = entity.FechaCaso;
                CasoModificar.IdAbogado = entity.IdAbogado;
                CasoModificar.IdCliente = entity.IdCliente;
                CasoModificar.IdEstadoCaso = entity.IdEstadoCaso;
                CasoModificar.IdTipoCaso = entity.IdTipoCaso;
                CasoModificar.Latitud = entity.Latitud;
                CasoModificar.Longitud = entity.Longitud;
                CasoModificar.Descripcion = entity.Descripcion;
                _context.Update(CasoModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

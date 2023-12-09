using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class EstadosCasosRepository : IEstadosCasosRepository
    {
        private readonly LawyersContext _context;
        private readonly ILogger<EstadosCasos> _logger;
        public EstadosCasosRepository(LawyersContext context, ILogger<EstadosCasos> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<EstadosCasos, bool>> filter)
        {
            return _context.EstadosCasos.Any(filter);
        }

        public IEnumerable<EstadosCasos> GetEntities()
        {
            return _context.EstadosCasos.ToList();
        }

        public EstadosCasos GetEntity(int entityid)
        {
            return _context.EstadosCasos.Find(entityid);
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

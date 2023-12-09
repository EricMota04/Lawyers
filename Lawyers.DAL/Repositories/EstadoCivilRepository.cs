using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class EstadoCivilRepository : IEstadoCivilRepository
    {
        private readonly LawyersContext _context;
        private readonly ILogger<EstadoCivil> _logger;
        public EstadoCivilRepository(LawyersContext context, ILogger<EstadoCivil> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<EstadoCivil, bool>> filter)
        {
            return _context.EstadoCivil.Any(filter);
        }

        public IEnumerable<EstadoCivil> GetEntities()
        {
            return _context.EstadoCivil.ToList();
        }

        public EstadoCivil GetEntity(int entityid)
        {
            return _context.EstadoCivil.Find(entityid);
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

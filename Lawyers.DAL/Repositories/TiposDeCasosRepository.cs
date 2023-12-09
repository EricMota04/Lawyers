using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class TiposDeCasosRepository : ITiposDeCasosRepository
    {
        private readonly LawyersContext _context;
        private readonly ILogger<TiposDeCasos> _logger;
        public TiposDeCasosRepository(LawyersContext context, ILogger<TiposDeCasos> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<TiposDeCasos, bool>> filter)
        {
            return _context.TiposDeCasos.Any(filter);
        }

        public IEnumerable<TiposDeCasos> GetEntities()
        {
            return _context.TiposDeCasos.ToList();
        }

        public TiposDeCasos GetEntity(int entityid)
        {
            return _context.TiposDeCasos.Find(entityid);
        }

        public void Save(TiposDeCasos entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TiposDeCasos entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Data.DAL.Context;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Lawyers.DAL.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly LawyersContext _context;
        private readonly ILogger<Roles> _logger;
        public RolesRepository(LawyersContext context, ILogger<Roles> logger) 
        {
            _context = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Roles, bool>> filter)
        {
            return _context.Roles.Any(filter);
        }

        public IEnumerable<Roles> GetEntities()
        {
            return _context.Roles.ToList();
        }

        public Roles GetEntity(int entityid)
        {
            return _context.Roles.Find(entityid);
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

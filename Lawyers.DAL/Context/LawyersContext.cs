using Microsoft.EntityFrameworkCore;
using Lawyers.DAL.Entities;

namespace Data.DAL.Context
{
    public class LawyersContext : DbContext
    {
        public LawyersContext(DbContextOptions<LawyersContext> options) : base(options)
        {
        }

        public DbSet<Abogados> Abogados { get; set; }
        public DbSet<Casos> Casos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<EstadosCasos> EstadosCasos { get; set; }
        public DbSet<Roles> Roles { get; set; }

        public DbSet<TiposDeCasos> TiposDeCasos { get; set; }
        
        public DbSet<Usuarios> USUARIOS { get; set; }
    }
    }



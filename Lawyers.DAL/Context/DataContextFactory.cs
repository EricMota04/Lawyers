using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAL.Context;

namespace Lawyers.DAL.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<LawyersContext>
    {
        public LawyersContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LawyersContext>();
            optionsBuilder.UseSqlServer("Server=ERIC;Database=ExamenFinal;User ID=Abogados;Password=1234;MultipleActiveResultSets=true;Encrypt=false;");

            return new LawyersContext(optionsBuilder.Options);
        }
    }
}

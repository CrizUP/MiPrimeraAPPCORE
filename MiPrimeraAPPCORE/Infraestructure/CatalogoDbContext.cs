using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MiPrimeraAPPCORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.Infraestructure
{

    public class CatalogoDbContext: DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}

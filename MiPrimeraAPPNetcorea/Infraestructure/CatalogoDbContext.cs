using Microsoft.EntityFrameworkCore;
using MiPrimeraAPPNetcorea.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Infraestructure
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Marca> Marca { get; set; }

    }
}

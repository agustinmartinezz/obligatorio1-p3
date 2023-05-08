using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.BaseDatos
{
    public class HotelCabanaContext:DbContext
    {
        public DbSet<Cabana> Cabanas { get; set; }
        //public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoCabana> TipoCabanas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        public HotelCabanaContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabana>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<TipoCabana>().HasIndex(t => t.Nombre).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}

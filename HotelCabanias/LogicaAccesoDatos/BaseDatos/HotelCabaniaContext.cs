﻿using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.BaseDatos
{
    public class HotelCabaniaContext:DbContext
    {
        public DbSet<Cabania> Cabanias { get; set; }

        public DbSet<TipoCabania> TipoCabanias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        public HotelCabaniaContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List<string>>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}

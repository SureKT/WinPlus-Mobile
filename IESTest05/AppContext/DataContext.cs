using IESTest05.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IESTest05.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Acumulados> Acumulados { get; set; }
        public DbSet<Causas> Causas { get; set; }
        public DbSet<Contadores> Contadores { get; set; }
        public DbSet<Fichajes> Fichajes { get; set; }
        public DbSet<Incidencias> Incidencias { get; set; }
        public DbSet<Personal> Personales { get; set; }
        public DbSet<TUsuarios> TUsuarios { get; set; }
        public DbSet<Validacion> Validaciones { get; set; }
        public DbSet<VContadores> VContadores { get; set; }
        public DbSet<VFichajes> VFichajes { get; set; }
        public DbSet<VIncidencias> VIncidencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Acumulados>()
            .HasKey(a => new { a.Personal, a.Inicio, a.Actividad });

            modelBuilder.Entity<Fichajes>()
            .HasKey(f => new { f.Hora, f.Tarjeta, f.Estado });

            modelBuilder.Entity<Validacion>()
            .HasKey(v => new { v.Personal, v.Fecha });

            modelBuilder.Entity<VContadores>()
            .HasKey(vc => new { vc.Personal, vc.Fecha, vc.Contador });

            modelBuilder.Entity<VFichajes>()
            .HasKey(vf => new { vf.Personal, vf.Fecha, vf.Hora, vf.Funcion });

            modelBuilder.Entity<VIncidencias>()
            .HasKey(vi => new { vi.Personal, vi.Fecha, vi.Incidencia, vi.Causa });
        }

    }
}
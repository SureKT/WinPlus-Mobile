﻿using WinPlusMobile.Entity;
using Microsoft.EntityFrameworkCore;
using MobileLite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinPlusMobile.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Causas> Causas { get; set; }
        public DbSet<Contadores> Contadores { get; set; }
        public DbSet<Fichajes> Fichajes { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<TUsuarios> TUsuarios { get; set; }
        public DbSet<Validacion> Validacion { get; set; }
        public DbSet<VContadores> VContadores { get; set; }
        public DbSet<VFichajes> VFichajes { get; set; }
        public DbSet<Config> Config { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
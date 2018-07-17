using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Doitclick.Models.Workflow;

namespace Doitclick.Data
{
    public class WorkflowDbContext : DbContext
    {


        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Transito> Transiciones { get; set; }

        public WorkflowDbContext(DbContextOptions<WorkflowDbContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Proceso>()
                .HasMany(d => d.Etapas)
                .WithOne(d => d.Proceso)
                .IsRequired();

            builder.Entity<Etapa>()
               .HasMany(d => d.TareasAutomaticas)
               .WithOne(d => d.Etapa);

            builder.Entity<Etapa>()
                .HasMany(d => d.Destinos)
                .WithOne(d => d.EtapaDestino)
                .IsRequired();
            
            builder.Entity<Etapa>()
                .HasMany(d => d.Actuales)
                .WithOne(d => d.EtapaActaual)
                .IsRequired();

            builder.Entity<Etapa>()
                .Property(e => e.TipoUsuarioAsignado)
                .HasConversion(
                    c => c.ToString(),
                    c => Enum.Parse<TipoUsuarioAsignado>(c)
                ).IsRequired();

            builder.Entity<Etapa>()
                .Property(d => d.TipoEtapa)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<TipoEtapa>(v)
                ).IsRequired();

            builder.Entity<Etapa>()
                .Property(d => d.TipoDuracion)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<TipoDuracion>(v)
                ).IsRequired(false);

            builder.Entity<Solicitud>()
                .HasMany(d => d.Tareas)
                .WithOne(d => d.Solicitud)
                .IsRequired();

            builder.Entity<Etapa>()
                .Property(s => s.ValorUsuarioAsignado)
                .IsRequired();

            builder.Entity<Proceso>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<Solicitud>()
                .Property(s => s.NumeroTicket)
                .IsRequired();

            builder.Entity<Solicitud>()
                .Property(s => s.FechaTermino)
                .IsRequired(false);

            builder.Entity<Solicitud>()
               .HasIndex(s => s.NumeroTicket)
               .IsUnique();

            builder.Entity<Solicitud>()
                .Property(s => s.InstanciadoPor)
                .IsRequired();

            builder.Entity<Solicitud>()
               .HasIndex(s => s.InstanciadoPor);

        }
    }
}

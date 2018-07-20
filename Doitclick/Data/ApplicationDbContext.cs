using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Doitclick.Models.Security;
using Doitclick.Models.Workflow;
using Doitclick.Models.Application;


namespace Doitclick.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Rol, string>
    {
        public DbSet<Organizacion> Organizaciones { get; set; }

        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Transito> Transiciones { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*Identity*/
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Rol>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("ReclamosUsuarios");
            builder.Entity<IdentityUserRole<string>>().ToTable("RolesUsuarios");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AccesosUsuarios");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("ReclamosRoles");
            builder.Entity<IdentityUserToken<string>>().ToTable("TokensUsuarios");

            builder.Entity<Organizacion>()
                .HasMany(f => f.Roles)
                .WithOne(f => f.Orzanizacion)
                .IsRequired();

            builder.Entity<Organizacion>()
                .HasOne(f => f.Padre)
                .WithMany(e => e.Hijos)
                .IsRequired(false);

            builder.Entity<Organizacion>()
                .Property(p => p.Nombre)
                .IsRequired();

            builder.Entity<Organizacion>()
                .Property(o => o.TipoOrganizacion)
                .HasConversion(
                    c => ((char)c).ToString(),
                    c => (TipoOrganizacion)char.Parse(c)
                )
                .IsRequired();

            /*WF*/
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

            /*App*/
            builder.Entity<Cliente>()
                .HasMany(c => c.MetaDatosCliente)
                .WithOne(m => m.Cliente)
                .IsRequired(false);

            builder.Entity<Cliente>()
                .HasMany(c => c.Cotizaciones)
                .WithOne(m => m.Cliente)
                .IsRequired(false);

            builder.Entity<Contacto>()
                .HasMany(c => c.MetaDatosContacto)
                .WithOne(m => m.Contacto)
                .IsRequired(false);

            builder.Entity<Cotizacion>()
                .HasMany(c => c.ItemsCotizar)
                .WithOne(m => m.Cotizacion)
                .IsRequired(false);

            builder.Entity<CuentaCorriente>()
                .HasMany(c => c.Movimientos)
                .WithOne(m => m.CuentaCorriente)
                .IsRequired(false);

            builder.Entity<CuentaCorriente>()
                .HasOne(d => d.Cliente)
                .WithMany();

            builder.Entity<MaterialDisponible>()
                .HasMany(m => m.Movimientos)
                .WithOne(m => m.MaterialDisponible);


            builder.Entity<MaterialDisponible>()
                .HasMany(m => m.Presupuestado)
                .WithOne(m => m.MaterialDisponible);

            builder.Entity<PrevisionSalud>()
                .HasMany(t => t.Clientes)
                .WithOne(c => c.PrevisionSalud)
                .IsRequired();





        }
    }
}
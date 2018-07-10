using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Doitclick.Models.Security;

namespace Doitclick.Data
{
    public class SecurityDbContext : DbContext
    {

        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organizacion> Organizaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<UsuarioRoles> UsuarioRoles { get; set; }
        //public DbSet<UsuarioTokens> UsuarioTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Rol>()
                .HasOne(p => p.Orzanizacion)
                .WithMany(x => x.Roles);

            builder.Entity<UsuarioRoles>()
                .HasOne(d => d.Rol)
                .WithMany(x => x.UsuarioRoles);

            builder.Entity<UsuarioRoles>()
                .HasOne(d => d.Usuario)
                .WithMany(x => x.UsuarioRoles);
        }
    }
}
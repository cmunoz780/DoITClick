using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Doitclick.Models.Security;
namespace Doitclick.Data
{
    public class SecurityDbContext : IdentityDbContext<Usuario, Rol, string>
    {
        public DbSet<Organizacion> Organizaciones { get; set; }

        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
                    c => c.ToString(),
                    c => Enum.Parse<TipoOrganizacion>(c)
                ).IsRequired();
        }
    }
}
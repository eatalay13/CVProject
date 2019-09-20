using CVP.Data.Models;
using CVP.Domain.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data
{
    public class CVProjectContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public CVProjectContext(DbContextOptions<CVProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(x =>
            {
                x.ToTable("Users");
            });


            builder.Entity<Role>()
            .ToTable("Roles");

            builder.Entity<RoleClaim>()
            .ToTable("RoleClaims");

            builder.Entity<UserClaim>()
            .ToTable("UserClaims");

            builder.Entity<UserLogin>()
            .ToTable("UserLogins")
            .HasKey(k => new
            {
                k.UserId,
                k.ProviderKey
            });

            builder.Entity<UserRole>()
            .ToTable("UserRoles")
            .HasKey(k => new
            {
                k.UserId,
                k.RoleId
            });

            builder.Entity<UserToken>()
            .ToTable("UserTokens")
            .HasKey(k => new
            {
                k.UserId,
                k.LoginProvider,
                k.Name
            });

            builder.Entity<Skill>()
                .ToTable("Skill");
        }


        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }

        public virtual DbSet<Skill> Skill { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Common;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Contexts
{
    public class AplicationContext : DbContext
    {
        // Opciones de conexion a la DB
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

        //Configuracion de los modelos (tablas) que voy a ultilizar para este Context
        public DbSet<Pokemones> Pokemones { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        //Configuraciones de las tablas 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API

            #region "Tables"
            modelBuilder.Entity<Pokemones>().ToTable("Pokemones");
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<Tipo>().ToTable("Tipo");
            #endregion

            #region "Primary keys"
            modelBuilder.Entity<Pokemones>().HasKey(pokemones => pokemones.Id);
            modelBuilder.Entity<Region>().HasKey(region => region.Id);
            modelBuilder.Entity<Tipo>().HasKey(tipo => tipo.Id);
            #endregion

            #region "Relationships"
            modelBuilder.Entity<Region>()
                .HasMany<Pokemones>(region => region.Pokemones)
                .WithOne(pokemones => pokemones.Region)
                .HasForeignKey(pokemones => pokemones.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipo>()
                .HasMany<Pokemones>(tipo => tipo.Pokemones)
                .WithOne(pokemones => pokemones.Tipo)
                .HasForeignKey(pokemones => pokemones.TipoPrimarioId)
                .HasForeignKey(pokemones => pokemones.TipoSecundarioId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            // Restricciones a nivel de base de datos
            #region "Property Configuration"

            #region "Pokemones"

            modelBuilder.Entity<Pokemones>()
                .Property(pokemones => pokemones.Name)
                .IsRequired();

            #endregion

            #region "Region"

            modelBuilder.Entity<Region>()
                .Property(region => region.Name)
                .IsRequired();

            #endregion

            #region "Tipo"

            modelBuilder.Entity<Tipo>()
                .Property(tipo => tipo.Name)
                .IsRequired()
                .HasMaxLength(70);

            #endregion

            #endregion
        }
    }
}

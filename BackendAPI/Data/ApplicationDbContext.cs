using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Eleve> Eleves{get;set;}
        public DbSet<Ecole> Ecoles{get;set;}
        public DbSet<Inscription> Inscriptions{ get;set;}
        public DbSet<Annee_Scolaire> Annee_Scolaires{ get;set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Mettre à jour automatiquement la propriété de creation ou mise à jour d'une entité
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Noms spécifiques pour les propriétées (Clés primaires) des tables
            modelBuilder.Entity<Eleve>()
                .Property(e => e.Id)
                .HasColumnName("IdEleve");

            modelBuilder.Entity<Ecole>()
                .Property(e => e.Id)
                .HasColumnName("IdEcole");

            modelBuilder.Entity<Inscription>()
               .Property(e => e.Id)
               .HasColumnName("IdInscription");

            modelBuilder.Entity<Annee_Scolaire>()
                .Property(e => e.AnneeScolaire)
                .HasColumnName("AnneScolaireId");

            base.OnModelCreating(modelBuilder);
        }

        
    }
}

using Hatogan.Application.Interfaces;
using Hatogan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IInventoryContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Sex> Sexs { get; set; } = default!;
        public DbSet<Origin> Origins { get; set; } = default!;
        public DbSet<Status> Statuses { get; set; } = default!;

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            BeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void BeforeSave()
        {
            // Get all the entities that inherit from AuditableEntity
            // and have a state of Added or Modified
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            // For each entity we will set the Audit properties
            foreach (var entityEntry in entries)
            {
                // If the entity state is Added let's set
                // the CreatedOn and CreatedBy properties
                if (entityEntry.State == EntityState.Added)
                {
                    ((IAuditEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                    ((IAuditEntity)entityEntry.Entity).CreatedBy = "system"; //this.httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
                }
                else
                {
                    // If the state is Modified then we don't want
                    // to modify the CreatedOn and CreatedBy properties
                    // so we set their state as IsModified to false
                    Entry((IAuditEntity)entityEntry.Entity).Property(p => p.CreatedDate).IsModified = false;
                    Entry((IAuditEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                // In any case we always want to set the properties
                // ModifiedOn and ModifiedBy
                ((IAuditEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;
                ((IAuditEntity)entityEntry.Entity).UpdatedBy = "system";//this.httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
            }

            // After we set all the needed properties
            // we call the base implementation of SaveChangesAsync
            // to actually save our entities in the database
            //return await base.SaveChangesAsync(CancellationToken);
        }
    }
}

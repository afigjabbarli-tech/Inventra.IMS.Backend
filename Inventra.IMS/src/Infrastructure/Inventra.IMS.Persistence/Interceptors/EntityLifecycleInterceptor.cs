using Inventra.IMS.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Inventra.IMS.Persistence.Interceptors
{
    public class EntityLifecycleInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            ApplyChanges(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            ApplyChanges(eventData.Context);

            return base.SavingChangesAsync(
                eventData,
                result,
                cancellationToken);
        }

        private static void ApplyChanges(DbContext? dbContext)
        {
            if (dbContext is null)
                return;

            foreach (var entry in dbContext.ChangeTracker.Entries())
            {
                if (entry.Entity is not SoftDeletableEntity<Guid, DateTimeOffset> entity)
                    continue;

                switch (entry.State)
                {
                    case EntityState.Added:
                        HandleAdded(entity);
                        break;

                    case EntityState.Modified:
                        HandleModified(entity);
                        break;

                    case EntityState.Deleted:
                        HandleDeleted(entry, entity);
                        break;
                }
            }
        }

        private static void HandleAdded(
            SoftDeletableEntity<Guid, DateTimeOffset> entity)
        {
            var now = DateTimeOffset.UtcNow;

            entity.CreatedAt = now;
            entity.LastModifiedAt = now;

            // TODO:
            // entity.CreatedBy = ...
            // entity.LastModifiedBy = ...
        }

        private static void HandleModified(
            SoftDeletableEntity<Guid, DateTimeOffset> entity)
        {
            entity.LastModifiedAt = DateTimeOffset.UtcNow;

            // TODO:
            // entity.LastModifiedBy = ...
        }

        private static void HandleDeleted(
            EntityEntry entry,
            SoftDeletableEntity<Guid, DateTimeOffset> entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTimeOffset.UtcNow;

            // TODO:
            // entity.DeletedBy = ...

            entry.State = EntityState.Modified;
        }
    }
}

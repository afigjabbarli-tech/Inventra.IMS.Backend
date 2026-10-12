using Inventra.IMS.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inventra.IMS.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyGlobalQueryFilters(
            this ModelBuilder modelBuilder)
        {
            ApplySoftDeleteFilter(modelBuilder);

            //sonraki filterler bura elave edile biler...
        }

        private static void ApplySoftDeleteFilter(
            ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.BaseType is null ||
                    !entityType.ClrType.BaseType.IsGenericType ||
                    entityType.ClrType.BaseType.GetGenericTypeDefinition() !=
                    typeof(SoftDeletableEntity<,>))
                {
                    continue;
                }

                var parameter = Expression.Parameter(
                    entityType.ClrType,
                    "entity");

                var isDeleted = Expression.Property(
                    parameter,
                    nameof(SoftDeletableEntity<Guid, DateTimeOffset>.IsDeleted));

                var filter = Expression.Lambda(
                    Expression.Equal(
                        isDeleted,
                        Expression.Constant(false)),
                    parameter);

                modelBuilder.Entity(entityType.ClrType)
                    .HasQueryFilter(filter);
            }
        }
    }
}

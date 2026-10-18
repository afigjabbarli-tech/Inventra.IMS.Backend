using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Infrastructure.Mappings
{
    public static class OwnerTypeFolderMapper
    {
        public static string ToFolderName(this EntityType ownerType)
        {
            return ownerType switch
            {
                EntityType.Country => "countries",

                _ => throw new ArgumentOutOfRangeException(
                    nameof(ownerType),
                    ownerType,
                    "Unsupported owner type!")
            };
        }
    }
}

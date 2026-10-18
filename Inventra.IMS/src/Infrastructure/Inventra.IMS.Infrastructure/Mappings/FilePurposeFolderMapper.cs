using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Infrastructure.Mappings
{
    public static class FilePurposeFolderMapper
    {
        public static string ToFolderName(this FilePurpose purpose)
        {
            return purpose switch
            {
                FilePurpose.OptionImage => "option-images",
                FilePurpose.ProfileImage => "profile-images",

                _ => throw new ArgumentOutOfRangeException(
                    nameof(purpose),
                    purpose,
                    "Unsupported file purpose!")
            };
        }
    }
}

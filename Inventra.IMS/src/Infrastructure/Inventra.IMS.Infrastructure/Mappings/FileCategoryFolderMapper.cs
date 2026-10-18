using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Infrastructure.Mappings
{
    public static class FileCategoryFolderMapper
    {
        public static string ToFolderName(this FileCategory category)
        {
            return category switch
            {
                FileCategory.Image => "images",
                FileCategory.Document => "documents",
                FileCategory.Video => "videos",
                FileCategory.Audio => "audio",
                FileCategory.Archive => "archives",
                FileCategory.Other => "others",

                _ => throw new ArgumentOutOfRangeException(
                    nameof(category),
                    category,
                    "Unsupported file category!")
            };
        }
    }
}

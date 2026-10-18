using Inventra.IMS.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Inventra.IMS.Application.Extensions
{
    public static class FileCategoryExtensions
    {
        public static FileCategory ToFileCategory(this IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string contentType = file.ContentType;

            if (string.IsNullOrWhiteSpace(file.FileName))
            {
                throw new ArgumentException(
                    "File extension is required!",
                    nameof(extension));
            }

            if (string.IsNullOrWhiteSpace(contentType))
            {
                throw new ArgumentException(
                    "Content type is required!",
                    nameof(contentType));
            }

            extension = extension.Trim().ToLowerInvariant();
            contentType = contentType.Trim().ToLowerInvariant();

            bool Matches(params string[] mimeTypes) =>
                mimeTypes.Contains(contentType, StringComparer.OrdinalIgnoreCase);

            return extension switch
            {
                // Images
                ".jpg" or ".jpeg" when Matches("image/jpeg")
                    => FileCategory.Image,
                ".png" when Matches("image/png")
                    => FileCategory.Image,
                ".gif" when Matches("image/gif")
                    => FileCategory.Image,
                ".webp" when Matches("image/webp")
                    => FileCategory.Image,
                ".bmp" when Matches("image/bmp", "image/x-ms-bmp")
                    => FileCategory.Image,
                ".tif" or ".tiff" when Matches("image/tiff")
                    => FileCategory.Image,
                ".svg" when Matches("image/svg+xml")
                    => FileCategory.Image,
                ".ico" when Matches("image/vnd.microsoft.icon", "image/x-icon")
                    => FileCategory.Image,
                ".avif" when Matches("image/avif")
                    => FileCategory.Image,

                // Documents
                ".pdf" when Matches("application/pdf")
                    => FileCategory.Document,
                ".doc" when Matches("application/msword")
                    => FileCategory.Document,
                ".docx" when Matches(
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                    => FileCategory.Document,
                ".odt" when Matches("application/vnd.oasis.opendocument.text")
                    => FileCategory.Document,
                ".rtf" when Matches("application/rtf", "text/rtf")
                    => FileCategory.Document,
                ".txt" when Matches("text/plain")
                    => FileCategory.Document,
                ".csv" when Matches("text/csv", "application/csv", "application/vnd.ms-excel")
                    => FileCategory.Document,
                ".md" when Matches("text/markdown", "text/plain")
                    => FileCategory.Document,
                ".xls" when Matches("application/vnd.ms-excel")
                    => FileCategory.Document,
                ".xlsx" when Matches(
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    => FileCategory.Document,
                ".ods" when Matches("application/vnd.oasis.opendocument.spreadsheet")
                    => FileCategory.Document,
                ".ppt" when Matches("application/vnd.ms-powerpoint")
                    => FileCategory.Document,
                ".pptx" when Matches(
                    "application/vnd.openxmlformats-officedocument.presentationml.presentation")
                    => FileCategory.Document,
                ".odp" when Matches("application/vnd.oasis.opendocument.presentation")
                    => FileCategory.Document,

                // Videos
                ".mp4" when Matches("video/mp4")
                    => FileCategory.Video,
                ".webm" when Matches("video/webm")
                    => FileCategory.Video,
                ".mkv" when Matches("video/x-matroska")
                    => FileCategory.Video,
                ".avi" when Matches("video/x-msvideo", "video/avi")
                    => FileCategory.Video,
                ".mov" when Matches("video/quicktime")
                    => FileCategory.Video,
                ".wmv" when Matches("video/x-ms-wmv")
                    => FileCategory.Video,
                ".flv" when Matches("video/x-flv")
                    => FileCategory.Video,
                ".mpeg" or ".mpg" when Matches("video/mpeg")
                    => FileCategory.Video,
                ".m4v" when Matches("video/x-m4v", "video/mp4")
                    => FileCategory.Video,
                ".3gp" when Matches("video/3gpp")
                    => FileCategory.Video,

                // Audio
                ".mp3" when Matches("audio/mpeg")
                    => FileCategory.Audio,
                ".wav" when Matches("audio/wav", "audio/x-wav", "audio/wave")
                    => FileCategory.Audio,
                ".ogg" when Matches("audio/ogg", "application/ogg")
                    => FileCategory.Audio,
                ".aac" when Matches("audio/aac", "audio/x-aac")
                    => FileCategory.Audio,
                ".flac" when Matches("audio/flac", "audio/x-flac")
                    => FileCategory.Audio,
                ".m4a" when Matches("audio/mp4", "audio/x-m4a")
                    => FileCategory.Audio,
                ".wma" when Matches("audio/x-ms-wma")
                    => FileCategory.Audio,
                ".opus" when Matches("audio/opus", "audio/ogg")
                    => FileCategory.Audio,
                ".aiff" or ".aif" when Matches("audio/aiff", "audio/x-aiff")
                    => FileCategory.Audio,
                ".mid" or ".midi" when Matches("audio/midi", "audio/x-midi", "application/x-midi")
                    => FileCategory.Audio,

                // Archives
                ".zip" when Matches("application/zip", "application/x-zip-compressed")
                    => FileCategory.Archive,
                ".rar" when Matches("application/vnd.rar", "application/x-rar-compressed")
                    => FileCategory.Archive,
                ".7z" when Matches("application/x-7z-compressed")
                    => FileCategory.Archive,
                ".tar" when Matches("application/x-tar")
                    => FileCategory.Archive,
                ".gz" or ".gzip" when Matches("application/gzip", "application/x-gzip")
                    => FileCategory.Archive,
                ".bz2" when Matches("application/x-bzip2")
                    => FileCategory.Archive,
                ".xz" when Matches("application/x-xz")
                    => FileCategory.Archive,
                ".tgz" when Matches("application/gzip", "application/x-gzip")
                    => FileCategory.Archive,
                ".zst" when Matches("application/zstd", "application/x-zstd")
                    => FileCategory.Archive,

                _ => FileCategory.Other
            };
        }
    }
}

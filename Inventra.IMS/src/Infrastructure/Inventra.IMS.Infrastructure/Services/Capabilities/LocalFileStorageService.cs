using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Application.Models.File;
using Inventra.IMS.Domain.Enums;
using Inventra.IMS.Infrastructure.Mappings;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace Inventra.IMS.Infrastructure.Services.Capabilities
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly string _rootPath;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalFileStorageService(
            string rootPath,
            IHttpContextAccessor httpContextAccessor)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
            {
                throw new ArgumentException(
                    "File storage root path cannot be empty!",
                    nameof(rootPath));
            }

            _rootPath = Path.GetFullPath(rootPath);

            _httpContextAccessor = httpContextAccessor
                ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<FileStorageResult> UploadAsync(FileUploadParameters parameters,
            int length, CancellationToken cancellationToken)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.File is null)
            {
                throw new ArgumentNullException(nameof(parameters.File));
            }

            if (parameters.File.Length == 0)
            {
                throw new ArgumentException(
                    "File cannot be empty!",
                    nameof(parameters.File));
            }

            if (!Enum.IsDefined(parameters.FileCategory))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(parameters.FileCategory));
            }

            if (!Enum.IsDefined(parameters.OwnerType))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(parameters.OwnerType));
            }

            if (!Enum.IsDefined(parameters.FilePurpose))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(parameters.FilePurpose));
            }

            string originalFileName = parameters.File.FileName;
            string extension = Path.GetExtension(originalFileName);

            string uniqueFileName = GenerateUniqueFileName(extension, _rootPath, length);

            string directoryPath = GenerateFileDirectoryPath(
                _rootPath, parameters.FileCategory,
                parameters.OwnerType, parameters.FilePurpose);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(
                directoryPath,
                uniqueFileName);

            string checksum;

            try
            {
                await using (FileStream fileStream = new(
                    filePath,
                    FileMode.CreateNew,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 81920,
                    options: FileOptions.Asynchronous))
                {
                    await parameters.File.CopyToAsync(
                        fileStream,
                        cancellationToken);
                }

                checksum = await CalculateChecksumAsync(
                    filePath,
                    cancellationToken);
            }
            catch
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                catch
                {
                    // Silinmə xətası ilkin xətanı əvəz etməsin.
                    // İstehsalat mühitində bu xətanı loglamaq lazımdır.
                }

                throw;
            }

            string storageKey = Path
                .GetRelativePath(_rootPath, filePath)
                .Replace('\\', '/');

            return new FileStorageResult
            {
                OriginalFileName = originalFileName,
                StorageFileName = uniqueFileName,
                StorageKey = storageKey,
                SizeBytes = parameters.File.Length,
                Extension = extension,
                ContentType = parameters.File.ContentType,
                Checksum = checksum,
                FileCategory = parameters.FileCategory,
                StorageProvider = StorageProvider.Local
            };
        }

        public string GeneratePublicURL(string storageKey)
        {
            if (string.IsNullOrWhiteSpace(storageKey))
            {
                throw new ArgumentException(
                    "Storage key cannot be null or empty!",
                    nameof(storageKey));
            }

            string normalizedKey = storageKey.Replace('\\', '/');

            string[] segments = normalizedKey.Split('/');

            if (segments.Any(segment =>
                string.IsNullOrWhiteSpace(segment) ||
                segment == "." ||
                segment == ".."))
            {
                throw new ArgumentException(
                    "Invalid storage key!",
                    nameof(storageKey));
            }

            string encodedStorageKey = string.Join(
                "/",
                segments.Select(Uri.EscapeDataString));

            string baseUrl = GetBaseURL(_httpContextAccessor);

            return $"{baseUrl}/uploads/{encodedStorageKey}";
        }

        public void Delete(string storageKey)
        {
            if (string.IsNullOrWhiteSpace(storageKey))
            {
                throw new ArgumentException(
                    "Storage key cannot be null or empty!",
                    nameof(storageKey));
            }

            string normalizedKey = storageKey.Replace('\\', '/');

            string[] segments = normalizedKey.Split('/');

            if (segments.Any(segment =>
                string.IsNullOrWhiteSpace(segment) ||
                segment == "." ||
                segment == ".."))
            {
                throw new ArgumentException(
                    "Invalid storage key!",
                    nameof(storageKey));
            }

            string filePath = Path.GetFullPath(
                Path.Combine(
                    _rootPath,
                    normalizedKey.Replace(
                        '/',
                        Path.DirectorySeparatorChar)));

            string relativePath = Path.GetRelativePath(
                _rootPath,
                filePath);

            if (Path.IsPathRooted(relativePath) ||
                relativePath == ".." ||
                relativePath.StartsWith(
                    ".." + Path.DirectorySeparatorChar,
                    StringComparison.Ordinal))
            {
                throw new ArgumentException(
                    "Storage key points outside the storage root!",
                    nameof(storageKey));
            }

            File.Delete(filePath);
        }

        private string GenerateFileDirectoryPath(string rootDirectoryPath,
        FileCategory fileCategory, EntityType entityType, FilePurpose filePurpose)
        {
            string fileCategoryFolderName =
                fileCategory.ToFolderName();

            string ownerTypeFolderName =
                entityType.ToFolderName();

            string filePurposeFolderName =
                filePurpose.ToFolderName();

            string directoryPath = Path.Combine(rootDirectoryPath,
                fileCategoryFolderName, ownerTypeFolderName, filePurposeFolderName);

            return directoryPath;
        }

        private bool FileNameExists(string rootDirectoryPath,
        string fileName)
        {
            if (string.IsNullOrWhiteSpace(rootDirectoryPath) ||
                string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }

            if (!Directory.Exists(rootDirectoryPath))
                return false;

            return Directory
                .EnumerateFiles(
                    rootDirectoryPath,
                    "*",
                    SearchOption.AllDirectories)
                .Any(filePath =>
                    string.Equals(
                        Path.GetFileNameWithoutExtension(filePath),
                        fileName,
                        StringComparison.OrdinalIgnoreCase));
        }

        private string GenerateUniqueFileName(string extension, string rootDirectoryPath, int length)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentException(
                "File extension cannot be null or empty!",
                nameof(extension));
            }

            if (string.IsNullOrWhiteSpace(rootDirectoryPath))
            {
                throw new ArgumentException(
                "Root directory path cannot be null or empty!",
                nameof(rootDirectoryPath));
            }

            if (length < 32)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(length),
                    length,
                    "File name length must be at least 32 characters.");
            }

            string uniqueFileIdentifier;

            do
            {
                uniqueFileIdentifier = GenerateUniqueFileIdentifier(length);
            }
            while (FileNameExists(rootDirectoryPath, uniqueFileIdentifier));

            string uniqueFileName = $"{uniqueFileIdentifier}{extension}";

            return uniqueFileName;
        }

        private string GenerateUniqueFileIdentifier(int length)
        {
            List<char> uppercaseLetters =
            [
                'A', 'B', 'C', 'D', 'E', 'F', 'G',
                'H', 'I', 'J', 'K', 'L', 'M', 'N',
                'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            ];

            List<char> lowercaseLetters =
            [
                'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z'
            ];

            List<char> digits =
            [
                '0', '1', '2', '3', '4',
                '5', '6', '7', '8', '9'
            ];

            string stage = "UPPERCASE";
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int index = 0; index < length; index++)
            {
                if (stage.Equals("UPPERCASE"))
                {
                    stringBuilder.Append(uppercaseLetters[GenerateRandomNumber(
                        0, uppercaseLetters.Count)]);

                    stage = "LOWERCASE";
                }

                else if (stage.Equals("LOWERCASE"))
                {
                    stringBuilder.Append(lowercaseLetters[GenerateRandomNumber(
                        0, lowercaseLetters.Count)]);

                    stage = "DIGIT";
                }

                else
                {
                    stringBuilder.Append(digits[GenerateRandomNumber(
                        0, digits.Count)]);

                    stage = "UPPERCASE";
                }
            }

            return stringBuilder.ToString();
        }

        private async Task<string> CalculateChecksumAsync(
        string filePath,
        CancellationToken cancellationToken = default)
        {
            await using FileStream fileStream = new(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 81920,
                options: FileOptions.Asynchronous);

            byte[] hash = await SHA256.HashDataAsync(
                fileStream,
                cancellationToken);

            return Convert.ToHexString(hash).ToLowerInvariant();
        }

        private int GenerateRandomNumber(int minValue, int maxValue)
        {
            return Random.Shared.Next(minValue, maxValue);
        }

        private string GetBaseURL(IHttpContextAccessor httpContextAccessor)
        {
            var request = _httpContextAccessor.HttpContext?.Request;

            if(request is null)
            {
                throw new InvalidOperationException(
                 "HTTP context is not available!");
            }

            return $"{request.Scheme}://{request.Host}{request.PathBase}";
        }
    }
}

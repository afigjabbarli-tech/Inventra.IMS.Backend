using Inventra.IMS.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Inventra.IMS.Application.Models.File
{
    public class FileUploadParameters
    {
        public FileCategory FileCategory { get; set; }
        public EntityType OwnerType { get; set; }
        public FilePurpose FilePurpose { get; set; }
        public IFormFile File { get; set; }
    }
}

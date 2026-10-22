using Inventra.IMS.Domain.Enums;

namespace Inventra.IMS.Application.DTOs.Country
{
    public class CountryFlagGetDTO
    {
        public string original_file_name { get; set; } = string.Empty;
        public FilePurpose file_purpose { get; set; }
        public bool is_primary { get; set; }
        public int sort_order { get; set; }
        public FileCategory file_category { get; set; }
        public string url { get; set; } = string.Empty;
        public Guid file_attachment_uid { get; set; }
    }
}

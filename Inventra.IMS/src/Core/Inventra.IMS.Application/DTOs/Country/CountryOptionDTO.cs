namespace Inventra.IMS.Application.DTOs.Country
{
    public class CountryOptionDTO
    {
        public Guid uid { get; set; }
        public string common_name { get; set; } = string.Empty;
        public string flag_url { get; set; } = string.Empty;
        public string phone_code { get; set; } = string.Empty;
    }
}

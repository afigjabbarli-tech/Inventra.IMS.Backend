using Microsoft.AspNetCore.Http;

namespace Inventra.IMS.Application.DTOs.Country
{
    public class CountryFlagPostDTO
    {
        public IFormFile flag { get; set; }
        public int sort_order { get; set; }
        public bool is_primary { get; set; }
    }
}

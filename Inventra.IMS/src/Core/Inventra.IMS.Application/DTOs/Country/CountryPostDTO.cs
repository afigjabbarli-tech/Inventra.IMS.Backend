using Microsoft.AspNetCore.Http;

namespace Inventra.IMS.Application.DTOs.Country
{
    public class CountryPostDTO
    {
        public string common_name { get; set; } = string.Empty;
        public string official_name { get; set; } = string.Empty;
        public string native_name { get; set; } = string.Empty;
        public string alpha2_code { get; set; } = string.Empty;
        public string alpha3_code { get; set; } = string.Empty;
        public string numeric_code { get; set; } = string.Empty;
        public string tld { get; set; } = string.Empty;
        public string? overview { get; set; }
        public string capital { get; set; } = string.Empty;
        public string phone_code { get; set; } = string.Empty;
        public string? largest_city_by_area { get; set; }
        public string? smallest_city_by_area { get; set; }
        public double area_km2 { get; set; }
        public long population { get; set; }
        public string? demonym { get; set; }    
        public decimal? gdp { get; set; }
    }
}

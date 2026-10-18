namespace Inventra.IMS.Application.DTOs.Country
{
    public class CountryGetDTO
    {
        public Guid uid { get; set; }

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

        public string flag_url { get; set; } = string.Empty;

        public double? population_density { get; set; }
        public decimal? gdp_per_capita { get; set; }

        public DateTimeOffset created_at { get; set; }
        public DateTimeOffset? last_modified_at { get; set; }

        public Guid? created_by { get; set; }
        public Guid? last_modified_by { get; set; }
    }
}

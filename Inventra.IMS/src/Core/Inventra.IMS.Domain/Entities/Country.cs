using Inventra.IMS.Domain.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventra.IMS.Domain.Entities
{
    [Table(name: "countries", Schema = "public")]
    public class Country : SoftDeletableEntity<Guid, DateTimeOffset>
    {
        [Column(name: "common_name", Order = 8, TypeName = "text")]
        public string CommonName { get; set; } = string.Empty;

        [Column(name: "official_name", Order = 9, TypeName = "text")]
        public string OfficialName { get; set; } = string.Empty;

        [Column(name: "native_name", Order = 10, TypeName = "text")]
        public string NativeName { get; set; } = string.Empty;

        [Column(name: "alpha2_code", Order = 11, TypeName = "varchar(2)")]
        public string Alpha2Code { get; set; } = string.Empty;

        [Column(name: "alpha3_code", Order = 12, TypeName = "varchar(3)")]
        public string Alpha3Code { get; set; } = string.Empty;

        [Column(name: "numeric_code", Order = 13, TypeName = "varchar(3)")]
        public string NumericCode { get; set; } = string.Empty;

        [Column(name: "tld", Order = 14, TypeName = "varchar(10)")]
        public string TLD { get; set; } = string.Empty;

        [Column(name: "overview", Order = 15, TypeName = "text")]
        public string? Overview { get; set; }

        [Column(name: "capital", Order = 16, TypeName = "text")]
        public string Capital { get; set; } = string.Empty;

        [Column(name: "phone_code", Order = 17, TypeName = "varchar(5)")]
        public string PhoneCode { get; set; } = string.Empty;

        [Column(name: "largest_city_by_area", Order = 18, TypeName = "text")]
        public string? LargestCityByArea { get; set; }

        [Column(name: "smallest_city_by_area", Order = 19, TypeName = "text")]
        public string? SmallestCityByArea { get; set; }

        [Column(name: "area_km2", Order = 20, TypeName = "double precision")]
        public double AreaKm2 { get; set; }

        [Column(name: "population", Order = 21, TypeName = "bigint")]
        public long Population { get; set; }

        [Column(name: "demonym", Order = 22, TypeName = "text")]
        public string? Demonym { get; set; }

        [Column(name: "gdp", Order = 23, TypeName = "numeric")]
        public decimal? GDP { get; set; }

        [NotMapped]
        public double? PopulationDensity =>
        AreaKm2 > 0 ? (double)Population / AreaKm2 : null;

        [NotMapped]
        public decimal? GDPPerCapita =>
            Population > 0 && GDP.HasValue
                ? GDP.Value / Population
                : null;
    }
}

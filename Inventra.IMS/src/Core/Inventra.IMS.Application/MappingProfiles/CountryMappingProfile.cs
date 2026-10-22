using AutoMapper;
using Inventra.IMS.Application.DTOs.Country;
using Inventra.IMS.Domain.Entities;

namespace Inventra.IMS.Application.MappingProfiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CountryPostDTO, Country>()
                .ForMember(dest => dest.CommonName,
                    opt => opt.MapFrom(src => src.common_name))
                .ForMember(dest => dest.OfficialName,
                    opt => opt.MapFrom(src => src.official_name))
                .ForMember(dest => dest.NativeName,
                    opt => opt.MapFrom(src => src.native_name))
                .ForMember(dest => dest.Alpha2Code,
                    opt => opt.MapFrom(src => src.alpha2_code))
                .ForMember(dest => dest.Alpha3Code,
                    opt => opt.MapFrom(src => src.alpha3_code))
                .ForMember(dest => dest.NumericCode,
                    opt => opt.MapFrom(src => src.numeric_code))
                .ForMember(dest => dest.TLD,
                    opt => opt.MapFrom(src => src.tld))
                .ForMember(dest => dest.Overview,
                    opt => opt.MapFrom(src => src.overview))
                .ForMember(dest => dest.Capital,
                    opt => opt.MapFrom(src => src.capital))
                .ForMember(dest => dest.PhoneCode,
                    opt => opt.MapFrom(src => src.phone_code))
                .ForMember(dest => dest.LargestCityByArea,
                    opt => opt.MapFrom(src => src.largest_city_by_area))
                .ForMember(dest => dest.SmallestCityByArea,
                    opt => opt.MapFrom(src => src.smallest_city_by_area))
                .ForMember(dest => dest.AreaKm2,
                    opt => opt.MapFrom(src => src.area_km2))
                .ForMember(dest => dest.Population,
                    opt => opt.MapFrom(src => src.population))
                .ForMember(dest => dest.Demonym,
                    opt => opt.MapFrom(src => src.demonym))
                .ForMember(dest => dest.GDP,
                    opt => opt.MapFrom(src => src.gdp));

            CreateMap<Country, CountryGetDTO>()
                .ForMember(dest => dest.uid,
                    opt => opt.MapFrom(src => src.Uid))
                .ForMember(dest => dest.common_name,
                    opt => opt.MapFrom(src => src.CommonName))
                .ForMember(dest => dest.official_name,
                    opt => opt.MapFrom(src => src.OfficialName))
                .ForMember(dest => dest.native_name,
                    opt => opt.MapFrom(src => src.NativeName))
                .ForMember(dest => dest.alpha2_code,
                    opt => opt.MapFrom(src => src.Alpha2Code))
                .ForMember(dest => dest.alpha3_code,
                    opt => opt.MapFrom(src => src.Alpha3Code))
                .ForMember(dest => dest.numeric_code,
                    opt => opt.MapFrom(src => src.NumericCode))
                .ForMember(dest => dest.tld,
                    opt => opt.MapFrom(src => src.TLD))
                .ForMember(dest => dest.overview,
                    opt => opt.MapFrom(src => src.Overview))
                .ForMember(dest => dest.capital,
                    opt => opt.MapFrom(src => src.Capital))
                .ForMember(dest => dest.phone_code,
                    opt => opt.MapFrom(src => src.PhoneCode))
                .ForMember(dest => dest.largest_city_by_area,
                    opt => opt.MapFrom(src => src.LargestCityByArea))
                .ForMember(dest => dest.smallest_city_by_area,
                    opt => opt.MapFrom(src => src.SmallestCityByArea))
                .ForMember(dest => dest.area_km2,
                    opt => opt.MapFrom(src => src.AreaKm2))
                .ForMember(dest => dest.population,
                    opt => opt.MapFrom(src => src.Population))
                .ForMember(dest => dest.demonym,
                    opt => opt.MapFrom(src => src.Demonym))
                .ForMember(dest => dest.gdp,
                    opt => opt.MapFrom(src => src.GDP))
                .ForMember(dest => dest.population_density,
                    opt => opt.MapFrom(src => src.PopulationDensity))
                .ForMember(dest => dest.gdp_per_capita,
                    opt => opt.MapFrom(src => src.GDPPerCapita))
                .ForMember(dest => dest.created_at,
                    opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.last_modified_at,
                    opt => opt.MapFrom(src => src.LastModifiedAt))
                .ForMember(dest => dest.created_by,
                    opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.last_modified_by,
                    opt => opt.MapFrom(src => src.LastModifiedBy));

            CreateMap<Country, CountryOptionDTO>()
                .ForMember(dest => dest.uid,
                    opt => opt.MapFrom(src => src.Uid))
                .ForMember(dest => dest.common_name,
                    opt => opt.MapFrom(src => src.CommonName))
                .ForMember(dest => dest.phone_code,
                    opt => opt.MapFrom(src => src.PhoneCode));
        }
    }
}

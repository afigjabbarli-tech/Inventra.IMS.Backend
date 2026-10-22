using FluentValidation;
using Inventra.IMS.Application.Features.Commands.Country.CreateCountry;

namespace Inventra.IMS.Application.Validations.Country
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommandRequest>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(request => request.CountryPostDTO.common_name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin ümumi adı")
                    .WithMessage("'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz." +
                    " Zəhmət olmasa, bu sahəyə '{PropertyName}'nı daxil edin!")
                .MinimumLength(2)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin ümumi adı")
                    .WithMessage(
                    "'{PropertyName}' minimum 2 simvoldan ibarət olmalıdır!")
                .MaximumLength(100)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin ümumi adı")
                    .WithMessage(
                    "'{PropertyName}' maksimum 100 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.official_name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin rəsmi adı")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nı daxil edin!")
                .MinimumLength(2)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin rəsmi adı")
                    .WithMessage(
                        "'{PropertyName}' minimum 2 simvoldan ibarət olmalıdır!")
                .MaximumLength(200)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin rəsmi adı")
                    .WithMessage(
                        "'{PropertyName}' maksimum 200 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.native_name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin yerli adı")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nı daxil edin!")
                .MinimumLength(2)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin yerli adı")
                    .WithMessage(
                        "'{PropertyName}' minimum 2 simvoldan ibarət olmalıdır!")
                .MaximumLength(200)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin yerli adı")
                    .WithMessage(
                        "'{PropertyName}' maksimum 200 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.alpha2_code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Alpha-2 ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nu daxil edin!")
                .Length(2)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Alpha-2 ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' dəqiq 2 simvoldan ibarət olmalıdır!")
                .Matches(@"^[A-Z]{2}$")
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Alpha-2 ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' yalnız böyük latın hərflərindən ibarət olmalıdır!");

            RuleFor(request => request.CountryPostDTO.alpha3_code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Alpha-3 ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nu daxil edin!")
                .Length(3)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Alpha-3 ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' dəqiq 3 simvoldan ibarət olmalıdır!")
                .Matches(@"^[A-Z]{3}$")
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Alpha-3 ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' yalnız böyük latın hərflərindən ibarət olmalıdır!");

            RuleFor(request => request.CountryPostDTO.numeric_code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Numeric ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nu daxil edin!")
                .Length(3)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Numeric ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' dəqiq 3 rəqəmdən ibarət olmalıdır!")
                .Matches(@"^[0-9]{3}$")
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("ISO Numeric ölkə kodu")
                    .WithMessage(
                        "'{PropertyName}' yalnız rəqəmlərdən ibarət olmalıdır!");

            RuleFor(request => request.CountryPostDTO.tld)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin domen uzantısı")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nı daxil edin!")
                .MaximumLength(10)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin domen uzantısı")
                    .WithMessage(
                        "'{PropertyName}' maksimum 10 simvoldan ibarət ola bilər!")
                .Matches(@"^\.[a-zA-Z0-9-]+$")
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin domen uzantısı")
                    .WithMessage(
                        "'{PropertyName}' nöqtə ilə başlamalı və yalnız latın hərflərindən, rəqəmlərdən və tiredən ibarət olmalıdır!");

            RuleFor(request => request.CountryPostDTO.overview)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(2000)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkə haqqında ümumi məlumat")
                    .WithMessage(
                        "'{PropertyName}' maksimum 2000 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.capital)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin paytaxtı")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nın adını daxil edin!")
                .MinimumLength(2)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin paytaxtı")
                    .WithMessage(
                        "'{PropertyName}' minimum 2 simvoldan ibarət olmalıdır!")
                .MaximumLength(100)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin paytaxtı")
                    .WithMessage(
                        "'{PropertyName}' maksimum 100 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.phone_code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin beynəlxalq telefon kodu")
                    .WithMessage(
                        "'{PropertyName}' sahəsi boş buraxıla və ya yalnız boşluqlardan ibarət ola bilməz. " +
                        "Zəhmət olmasa, bu sahəyə '{PropertyName}'nu daxil edin!")
                .MaximumLength(5)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin beynəlxalq telefon kodu")
                    .WithMessage(
                        "'{PropertyName}' maksimum 5 simvoldan ibarət ola bilər!")
                .Matches(@"^\+[1-9][0-9]{0,2}$")
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin beynəlxalq telefon kodu")
                    .WithMessage(
                        "'{PropertyName}' '+' işarəsi ilə başlamalı və beynəlxalq telefon kodu formatına uyğun olmalıdır!");

            RuleFor(request => request.CountryPostDTO.largest_city_by_area)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(100)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Sahəsinə görə ən böyük şəhər")
                    .WithMessage(
                        "'{PropertyName}' maksimum 100 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.smallest_city_by_area)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(100)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Sahəsinə görə ən kiçik şəhər")
                    .WithMessage(
                        "'{PropertyName}' maksimum 100 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.area_km2)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin sahəsi")
                    .WithMessage(
                        "'{PropertyName}' mənfi ola bilməz!")
                .LessThanOrEqualTo(18_000_000)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin sahəsi")
                    .WithMessage(
                        "'{PropertyName}' maksimum 18 000 000 km² ola bilər!");

            RuleFor(request => request.CountryPostDTO.population)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin əhalisi")
                    .WithMessage(
                        "'{PropertyName}' mənfi ola bilməz!")
                .LessThanOrEqualTo(10_000_000_000)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin əhalisi")
                    .WithMessage(
                        "'{PropertyName}' maksimum 10 000 000 000 ola bilər!");

            RuleFor(request => request.CountryPostDTO.demonym)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(100)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkə sakinlərinin adı")
                    .WithMessage(
                        "'{PropertyName}' maksimum 100 simvoldan ibarət ola bilər!");

            RuleFor(request => request.CountryPostDTO.gdp)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ümumi daxili məhsul (ÜDM)")
                    .WithMessage(
                        "'{PropertyName}' mənfi ola bilməz!");

            RuleFor(request => request.CountryFlagPostDTO.flag)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin bayraq şəkli")
                    .WithMessage(
                        "'{PropertyName}' faylı boş buraxıla bilməz!")
                .Must(file => file is { Length: > 0 })
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin bayraq şəkli")
                    .WithMessage(
                        "'{PropertyName}' faylı boş ola bilməz!")
                .Must(file => file.Length <= 2 * 1024 * 1024)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin bayraq şəkli")
                    .WithMessage(
                        "'{PropertyName}' faylının ölçüsü maksimum 2 MB ola bilər!")
                .Must(file =>
                    file.ContentType is "image/svg+xml" or "image/png")
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Ölkənin bayraq şəkli")
                    .WithMessage(
                        "'{PropertyName}' yalnız SVG və ya PNG formatında olmalıdır!");

            RuleFor(request => request.CountryFlagPostDTO.sort_order)
                .GreaterThanOrEqualTo(1)
                    .WithSeverity(Severity.Error)
                    .WithErrorCode("Localization zamani tetbiq et!")
                    .WithName("Şəklin sıralaması")
                    .WithMessage(
                        "'{PropertyName}' minimum 1 olmalıdır!");
        }
    }
}

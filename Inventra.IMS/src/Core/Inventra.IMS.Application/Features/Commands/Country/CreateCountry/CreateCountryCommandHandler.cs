using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.Extensions;
using Inventra.IMS.Application.Models.File;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Inventra.IMS.Application.Features.Commands.Country.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommandRequest, CreateCountryCommandResponse>
    {
        private readonly ICountryService _countryService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCountryCommandHandler(ICountryService countryService, IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _countryService = countryService;
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }
        public async Task<CreateCountryCommandResponse> Handle(CreateCountryCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var countryGetDTO = await _countryService
                .CreateCountryAsync(request.CountryPostDTO, cancellationToken);

                IFormFile file = request.CountryFlagUploadDTO.flag;

                var fileCategory = FileCategoryExtensions
                    .ToFileCategory(file);

                var parameters = new FileUploadParameters
                {
                    FileCategory = fileCategory,
                    OwnerType = EntityType.Country,
                    FilePurpose = FilePurpose.OptionImage,
                    File = file
                };

                FileStorageResult fileStorageResult =
                    await _fileStorageService.UploadAsync(parameters,
                    64, cancellationToken);

                return new CreateCountryCommandResponse { };
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(CancellationToken.None);

                throw;
            }
        }
    }
}


using AutoMapper;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.DTOs.FileMetadata;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Domain.Entities;

namespace Inventra.IMS.Persistence.Concretes.Services
{
    public class FileMetadataService : IFileMetadataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FileMetadataService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FileMetadataReadDTO> CreateFileMetadataAsync(
            FileMetadataCreateDTO fileMetadataCreateDTO,
            CancellationToken cancellationToken)
        {
            var fileMetadata = _mapper.Map<FileMetadata>(fileMetadataCreateDTO);

            var addedFileMetadata = await _unitOfWork.FileMetadataWriteRepository
                .AddAsync(fileMetadata, cancellationToken);

            var fileMetadataReadDTO = _mapper.Map<FileMetadataReadDTO>(addedFileMetadata);

            return fileMetadataReadDTO;
        }
    }
}

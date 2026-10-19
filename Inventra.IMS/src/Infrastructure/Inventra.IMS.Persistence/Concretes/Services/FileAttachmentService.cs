using AutoMapper;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.DTOs.FileAttachment;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Domain.Entities;

namespace Inventra.IMS.Persistence.Concretes.Services
{
    public class FileAttachmentService : IFileAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FileAttachmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FileAttachmentReadDTO> CreateFileAttachmentAsync(
            FileAttachmentCreateDTO fileAttachmentCreateDTO,
            CancellationToken cancellationToken)
        {
            var fileAttachment = _mapper.Map<FileAttachment>(fileAttachmentCreateDTO);

            var addedFileAttachment = await _unitOfWork.FileAttachmentWriteRepository
                .AddAsync(fileAttachment, cancellationToken);

            var fileAttachmentReadDTO = _mapper.Map<FileAttachmentReadDTO>(addedFileAttachment);

            return fileAttachmentReadDTO;
        }
    }
}

using AutoMapper;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.Common.Exceptions;
using Inventra.IMS.Application.DTOs.FileAttachment;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Domain.Entities;
using Inventra.IMS.Domain.Enums;

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

        public async Task<FileAttachmentReadDTO> GetFileAttachmentByOwnerAsync(
            EntityType ownerType, Guid ownerUid,
            bool isTarcking, CancellationToken cancellationToken)
        {
            var fileAttachment = await _unitOfWork.FileAttachmentReadRepository
                .GetByConditionAsync((fileAttachment)
                => fileAttachment.OwnerType.Equals(ownerType)
                && fileAttachment.OwnerUid.Equals(ownerUid),
                isTarcking, cancellationToken);

            if(fileAttachment is null)
            {
                throw new NotFoundException(
                $"File attachment for owner type '{ownerType}'" +
                $" with UID '{ownerUid}' was not found!");
            }

            var fileAttachmentReadDTO = _mapper
                .Map<FileAttachmentReadDTO>(fileAttachment);

            return fileAttachmentReadDTO;
        }

        public async Task DeleteFileAttachmentByOwnerAsync(
            EntityType ownerType, Guid ownerUid,
            bool isTarcking, CancellationToken cancellationToken)
        {
            var fileAttachment = await _unitOfWork.FileAttachmentReadRepository
                .GetByConditionAsync((fileAttachment)
                => fileAttachment.OwnerType.Equals(ownerType)
                && fileAttachment.OwnerUid.Equals(ownerUid),
                isTarcking, cancellationToken);

            if (fileAttachment is null)
            {
                throw new NotFoundException(
                $"File attachment for owner type '{ownerType}'" +
                $" with UID '{ownerUid}' was not found!");
            }

            _unitOfWork.FileAttachmentWriteRepository.Remove(fileAttachment);
        }
    }
}

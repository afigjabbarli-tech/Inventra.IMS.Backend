using AutoMapper;
using Inventra.IMS.Application.DTOs.FileAttachment;
using Inventra.IMS.Domain.Entities;

namespace Inventra.IMS.Application.MappingProfiles
{
    public class FileAttachmentMappingProfile : Profile
    {
        public FileAttachmentMappingProfile()
        {
            CreateMap<FileAttachmentCreateDTO, FileAttachment>()
                .ForMember(dest => dest.FileUid, opt => opt.MapFrom(src => src.FileUid))
                .ForMember(dest => dest.OwnerType, opt => opt.MapFrom(src => src.OwnerType))
                .ForMember(dest => dest.OwnerUid, opt => opt.MapFrom(src => src.OwnerUid))
                .ForMember(dest => dest.FilePurpose, opt => opt.MapFrom(src => src.FilePurpose))
                .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.IsPrimary, opt => opt.MapFrom(src => src.IsPrimary));

            CreateMap<FileAttachment, FileAttachmentReadDTO>()
                .ForMember(dest => dest.uid, opt => opt.MapFrom(src => src.Uid))
                .ForMember(dest => dest.file_uid, opt => opt.MapFrom(src => src.FileUid))
                .ForMember(dest => dest.owner_type, opt => opt.MapFrom(src => src.OwnerType))
                .ForMember(dest => dest.owner_uid, opt => opt.MapFrom(src => src.OwnerUid))
                .ForMember(dest => dest.file_purpose, opt => opt.MapFrom(src => src.FilePurpose))
                .ForMember(dest => dest.sort_order, opt => opt.MapFrom(src => src.SortOrder))
                .ForMember(dest => dest.is_primary, opt => opt.MapFrom(src => src.IsPrimary))
                .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.last_modified_at, opt => opt.MapFrom(src => src.LastModifiedAt))
                .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.last_modified_by, opt => opt.MapFrom(src => src.LastModifiedBy));
        }
    }
}

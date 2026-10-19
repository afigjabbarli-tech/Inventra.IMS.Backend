using AutoMapper;
using Inventra.IMS.Application.DTOs.FileMetadata;
using Inventra.IMS.Domain.Entities;

namespace Inventra.IMS.Application.MappingProfiles
{
    public class FileMetadataMappingProfile : Profile
    {
        public FileMetadataMappingProfile()
        {
            CreateMap<FileMetadataCreateDTO, FileMetadata>()
                .ForMember(dest => dest.OriginalFileName,
                    opt => opt.MapFrom(src => src.OriginalFileName))
                .ForMember(dest => dest.StoredFileName,
                    opt => opt.MapFrom(src => src.StoredFileName))
                .ForMember(dest => dest.StorageKey,
                    opt => opt.MapFrom(src => src.StorageKey))
                .ForMember(dest => dest.ContentType,
                    opt => opt.MapFrom(src => src.ContentType))
                .ForMember(dest => dest.Extension,
                    opt => opt.MapFrom(src => src.Extension))
                .ForMember(dest => dest.SizeBytes,
                    opt => opt.MapFrom(src => src.SizeBytes))
                .ForMember(dest => dest.Checksum,
                    opt => opt.MapFrom(src => src.Checksum))
                .ForMember(dest => dest.StorageProvider,
                    opt => opt.MapFrom(src => src.StorageProvider))
                .ForMember(dest => dest.FileCategory,
                    opt => opt.MapFrom(src => src.FileCategory));

            CreateMap<FileMetadata, FileMetadataReadDTO>()
                .ForMember(dest => dest.uid, opt => opt.MapFrom(src => src.Uid))
                .ForMember(dest => dest.original_file_name, opt => opt.MapFrom(src => src.OriginalFileName))
                .ForMember(dest => dest.stored_file_name, opt => opt.MapFrom(src => src.StoredFileName))
                .ForMember(dest => dest.storage_key, opt => opt.MapFrom(src => src.StorageKey))
                .ForMember(dest => dest.content_type, opt => opt.MapFrom(src => src.ContentType))
                .ForMember(dest => dest.extension, opt => opt.MapFrom(src => src.Extension))
                .ForMember(dest => dest.size_bytes, opt => opt.MapFrom(src => src.SizeBytes))
                .ForMember(dest => dest.checksum, opt => opt.MapFrom(src => src.Checksum))
                .ForMember(dest => dest.storage_provider, opt => opt.MapFrom(src => src.StorageProvider))
                .ForMember(dest => dest.file_category, opt => opt.MapFrom(src => src.FileCategory))
                .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.last_modified_at, opt => opt.MapFrom(src => src.LastModifiedAt))
                .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.last_modified_by, opt => opt.MapFrom(src => src.LastModifiedBy));
        }
    }
}

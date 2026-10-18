namespace Inventra.IMS.Domain.Enums
{
    public enum StorageProvider : byte
    {
        Local = 1,
        AmazonS3 = 2,
        AzureBlobStorage = 3,
        GoogleCloudStorage = 4,
        MinIO = 5,
        Sftp = 6
    }
}

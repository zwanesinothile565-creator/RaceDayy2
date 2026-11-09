namespace RaceDayy.Services
{
    public record BlobUploadResults(String BlobName, string Url);
    public interface IBlobStorageService
    {
        string? Validate(IFormFile file);

        Task<BlobUploadResults>UploadBannerAsync(IFormFile file, CancellationToken ct = default);

        Task DeleteAsync(string? blobName, CancellationToken ct = default);
    }
}

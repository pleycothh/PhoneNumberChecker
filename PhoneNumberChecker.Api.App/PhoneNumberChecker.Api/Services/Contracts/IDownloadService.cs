using PhoneNumberChecker.Api.Models;

namespace PhoneNumberChecker.Api.Services.Contracts
{
    public interface IDownloadService
    {
        string DownloadCsv(ResultModel result);
        Task<string?> DownloadCsv(int id);
    }
}
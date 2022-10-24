using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;
using System.Text;

namespace PhoneNumberChecker.Api.Services
{
    public class DownloadService : IDownloadService
    {
        public string DownloadCsv(ResultModel result)
        {
            StringBuilder sb = new();
            sb.AppendLine("IsValid, IsPossible, PhoneType, InternationalFormat");
            sb.AppendLine($"{result.IsValid}, {result.IsPossible}, {result.PhoneType}, {result.InternationalFormat}");
            return sb.ToString();
        }
    }
}

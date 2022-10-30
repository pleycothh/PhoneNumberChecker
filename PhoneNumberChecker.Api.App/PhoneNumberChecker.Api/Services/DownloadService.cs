using PhoneNumberChecker.Api.Data;
using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;
using System.Text;

namespace PhoneNumberChecker.Api.Services
{
    public class DownloadService : IDownloadService
    {
        private readonly DataContext _context;

        public DownloadService(DataContext context)
        {
            _context = context;
        }

        public string DownloadCsv(ResultModel result)
        {
            StringBuilder sb = new();
            sb.AppendLine("IsValid, IsPossible, PhoneType, InternationalFormat");
            sb.AppendLine($"{result.IsValid}, {result.IsPossible}, {result.PhoneType}, {result.InternationalFormat}");
            return sb.ToString();
        }

        public async Task<string?> DownloadCsv(int id)
        {

            var result = await _context.Results.FindAsync(id);

            if (result == null)
            {
                return  null;
            }

            StringBuilder sb = new();
            sb.AppendLine("IsValid, IsPossible, PhoneType, InternationalFormat");
            sb.AppendLine($"{result.IsValid}, {result.IsPossible}, {result.PhoneType}, {result.InternationalFormat}");
            return sb.ToString();
        }
    }
}

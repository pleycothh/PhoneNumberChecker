using PhoneNumberChecker.Api.Models;

namespace PhoneNumberChecker.Api.Services.Contracts
{
    public interface IValidationService
    {
        ResultModel Validating(int id, string phoneNumber);
        Task SaveResult(ResultModel resultModel); 
        Task<IEnumerable<ResultModel>> GetResults();
        Task<int> DeleteResult(int id);
    }
}
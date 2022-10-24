using PhoneNumberChecker.Api.Models;

namespace PhoneNumberChecker.Api.Services.Contracts
{
    public interface IValidationService
    {
        ResultModel Validating(int id, string phoneNumber);
    }
}
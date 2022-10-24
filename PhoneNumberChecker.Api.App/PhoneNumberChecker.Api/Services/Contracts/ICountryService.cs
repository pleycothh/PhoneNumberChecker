using PhoneNumberChecker.Api.Models;

namespace PhoneNumberChecker.Api.Services.Contracts
{
    public interface ICountryService
    {
        IEnumerable<CountryModel> GetCountry();
    }
}
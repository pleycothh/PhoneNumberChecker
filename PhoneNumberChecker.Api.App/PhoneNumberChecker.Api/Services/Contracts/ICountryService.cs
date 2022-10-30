using PhoneNumberChecker.Api.Models;
using System.Security.Cryptography;

namespace PhoneNumberChecker.Api.Services.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryModel>> GetCountry();
    }
}
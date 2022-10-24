using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;

namespace PhoneNumberChecker.Api.Services
{
    public class CountryService : ICountryService
    {
        public List<CountryModel> Countries { get; set; } = new();

        public CountryService()
        {
            Countries.Add(new CountryModel(0,"Australia"));
            Countries.Add(new CountryModel(1,"Canada"));
            Countries.Add(new CountryModel(2,"China"));
            Countries.Add(new CountryModel(3,"United States"));
        }

        public IEnumerable<CountryModel> GetCountry()
        {
            return Countries;
        }
    }
}

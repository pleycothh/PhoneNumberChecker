using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Api.Data;
using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;

namespace PhoneNumberChecker.Api.Services
{
    public class CountryService : ICountryService
    {
        public List<CountryModel> Countries { get; set; } = new();
        private readonly DataContext _context;


        public CountryService(DataContext context)
        {
            _context = context;
            InitCountry();
        }

        public async Task<IEnumerable<CountryModel>> GetCountry()
        {
            return await _context.Countries.ToListAsync();
        }


        private void InitCountry()
        {
            var countries = _context.Countries.Find();
            if (countries is null)
            {
                _context.Countries.Add(new CountryModel(0, "Australia"));
                _context.Countries.Add(new CountryModel(1, "Canada"));
                _context.Countries.Add(new CountryModel(2, "China"));
                _context.Countries.Add(new CountryModel(3, "United States"));

                _context.SaveChangesAsync();

                Console.WriteLine("Four countries has initialized");
            }
           
        }
    }
}

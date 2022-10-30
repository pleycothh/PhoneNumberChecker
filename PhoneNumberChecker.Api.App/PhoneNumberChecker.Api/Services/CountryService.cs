using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Api.Data;
using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;
using System.Runtime.CompilerServices;

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
            var countries =  _context.Countries.Any();
            if (!countries)
            {
                _context.Countries.Add(new CountryModel() { Name= "Australia" });
                _context.Countries.Add(new CountryModel() { Name= "Canada" });
                _context.Countries.Add(new CountryModel() { Name= "China" });
                _context.Countries.Add(new CountryModel() { Name= "United States" });

                _context.SaveChanges();

                Console.WriteLine("Four countries has initialized");
            }
           
        }
    }
}

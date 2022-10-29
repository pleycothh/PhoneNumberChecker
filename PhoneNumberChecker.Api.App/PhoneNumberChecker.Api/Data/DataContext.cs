using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;

namespace PhoneNumberChecker.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<ResultModel> Results { get; set; }
    }
}

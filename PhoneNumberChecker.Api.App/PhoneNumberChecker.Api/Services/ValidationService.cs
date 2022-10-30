using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Api.Data;
using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;


namespace PhoneNumberChecker.Api.Services
{
    public class ValidationService : IValidationService
    {
        private readonly DataContext _context;

        public ValidationService(DataContext context)
        {
            _context = context;
        }
       
        public ResultModel Validating(int id, string phoneNumber)
        {
            // if input value is not number, return invalid
            if(!int.TryParse(phoneNumber, out _)) return new ResultModel("False", "False", "Invalid Number", "Unknown");

            // else: do validation
            var region = CountryModel.Region[id];

            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

            var number = phoneNumberUtil.Parse(phoneNumber, region);

            // Get Result
            var isValid = phoneNumberUtil.IsValidNumber(number).ToString();
            var isPossible = phoneNumberUtil.IsPossibleNumber(number).ToString();
            var phoneType = phoneNumberUtil.GetNumberType(number).ToString();
            
            var regionCode = phoneNumberUtil.GetCountryCodeForRegion(region);
            var internationalFormat = $"+{regionCode} {phoneNumber}";

            var result = new ResultModel(isValid, isPossible, phoneType, internationalFormat);

            return result;
        }

        public async Task SaveResult(ResultModel resultModel)
        {
            _context.Results.Add(resultModel);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ResultModel>> GetResults()
        {
            return await _context.Results.ToListAsync();
        }

        public async Task<int> DeleteResult(int id)
        {
           //  await _context.Results.ToListAsync();
            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                return -1;
            }

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();
            return result.Id;
        }
    }
}

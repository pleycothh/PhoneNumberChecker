using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services.Contracts;


namespace PhoneNumberChecker.Api.Services
{
    public class ValidationService : IValidationService
    {
        
       
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

            return new ResultModel(isValid, isPossible, phoneType, internationalFormat);
        }

        public void SaveResult(ResultModel resultModel)
        {

        }
    }
}

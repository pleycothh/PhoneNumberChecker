namespace PhoneNumberChecker.Api.Models
{
    public class ResultModel
    {
        public int Id { get; set; }
        public CountryModel Country { get; set; } = new CountryModel(1, "demo");
        public string IsValid { get; set; }
        public string IsPossible { get; set; }
        public string PhoneType { get; set; }
        public string InternationalFormat { get; set; }

        public ResultModel(string isValid, string isPossible, string phoneType, string internationalFormat)
        {
            IsValid = isValid;
            IsPossible = isPossible;
            PhoneType = phoneType;
            InternationalFormat = internationalFormat;
        }

    }
}

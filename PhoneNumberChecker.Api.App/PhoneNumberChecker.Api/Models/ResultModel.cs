namespace PhoneNumberChecker.Api.Models
{
    public class ResultModel
    {
        public int Id { get; set; }
        public CountryModel Country { get; set; } = new();
        public string IsValid { get; set; } = string.Empty;
        public string IsPossible { get; set; } = string.Empty;
        public string PhoneType { get; set; } = string.Empty;
        public string InternationalFormat { get; set; } = string.Empty;

    //    public ResultModel(string isValid, string isPossible, string phoneType, string internationalFormat)
    //    {
    //        IsValid = isValid;
    //        IsPossible = isPossible;
    //        PhoneType = phoneType;
    //        InternationalFormat = internationalFormat;
    //    }

    }
}

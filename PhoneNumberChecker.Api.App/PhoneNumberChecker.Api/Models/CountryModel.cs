using System.Diagnostics;
using System.Text;

namespace PhoneNumberChecker.Api.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static string[] Region { get; set; } = new string[] { "AU", "CA" , "CN", "US"};


       // public CountryModel(int id, string name)
       // {
       //     Id = id;
       //     Name = name;
       // }

    }
}

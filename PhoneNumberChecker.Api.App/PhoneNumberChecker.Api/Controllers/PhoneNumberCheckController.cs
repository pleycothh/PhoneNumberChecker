using Microsoft.AspNetCore.Mvc;
using PhoneNumberChecker.Api.Models;
using PhoneNumberChecker.Api.Services;
using PhoneNumberChecker.Api.Services.Contracts;
using PhoneNumbers;
using System.Diagnostics.Metrics;

namespace PhoneNumberChecker.Api.Controllers
{
    [Route("api/number-check")]
    [ApiController]
    public class PhoneNumberCheckController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IDownloadService _downloadService;
        private readonly IValidationService _validationSerive;
        public PhoneNumberCheckController( ICountryService countryService, IDownloadService downloadService, IValidationService validationSerive)
        {

            _countryService = countryService;
            _downloadService = downloadService;
            _validationSerive = validationSerive;
        }


        // Get ContryList
        //  /api/api/number-check
        [HttpGet]
        public IActionResult GetCountries()
        {
            var country =  _countryService.GetCountry();
           return Ok(country);
        }

        // send post request to get valid
        //  /api/number-checker/valid?countryId=1,phoneNum=0505100100
        [HttpGet("{id}/{phoneNumber}")]
        public IActionResult GetPhoneNumber([FromRoute] int id , [FromRoute] string phoneNumber)
        {
            var result = _validationSerive.Validating(id, phoneNumber);
            return Ok(result);
        }

        // send from formbody
        //  /api/number-checke/download
        [HttpPost("download")]
        public IActionResult GetDownload(ResultModel result)
        {
            var csvFile = _downloadService.DownloadCsv(result);
            return Ok(csvFile);
        }

    }
}

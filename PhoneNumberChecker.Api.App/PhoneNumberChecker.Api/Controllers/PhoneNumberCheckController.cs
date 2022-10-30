using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public async Task<IActionResult> GetCountries()
        {
            var country =  await _countryService.GetCountry();
           return Ok(country);
        }

        // send post request to get valid
        //  /api/number-checker/valid?countryId=1,phoneNum=0505100100
        [HttpGet("{id}/{phoneNumber}")]
        public async Task<IActionResult> GetPhoneNumber([FromRoute] int id , [FromRoute] string phoneNumber)
        {
            var result = _validationSerive.Validating(id, phoneNumber);

            // record user search to database
            await _validationSerive.SaveResult(result);

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

        // dowload from database, selected by id
        //  /api/number-checke/download
        [HttpPost("download/{id}")]
        public async Task<IActionResult> GetDownload([FromRoute] int id)
        {
            var csvFile = await _downloadService.DownloadCsv(id);

            if(csvFile == null)
            {
                return NotFound();
            }
            
            return Ok(csvFile);
        }


        // get list of result model from database
        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var results = await _validationSerive.GetResults();
            return Ok(results);
        }

        // get list of result model from database
        [HttpDelete("history/{id}")]
        public async Task<IActionResult> DeleteHistory([FromRoute] int id)
        {
            var result = await _validationSerive.DeleteResult(id);

            if (result == -1) return NotFound();
            return Ok(result);
        }

    }
}

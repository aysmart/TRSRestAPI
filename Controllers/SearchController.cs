using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TRSRestAPI.Models;
using RestSharp;

namespace TRSRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {

        private readonly ILogger<SearchController> _logger;
        private readonly DBModelsContext _db;

        public SearchController(ILogger<SearchController> logger, DBModelsContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        public IActionResult Get([FromBody] CountryName country)
        {
            //Country Variable
            string countryLink = "https://restcountries.com/v3.1/name/" + country.name;
            // Get Country Details
            var client = new RestClient(countryLink);
            var request = new RestRequest("", Method.Get);
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);

            // Get Weather Forecast Details
            var apiKeys = "0b819f8a860dbf4de23350f1243bdebe";
            var weatherLink = "http://api.openweathermap.org/data/2.5/forecast?q=" + country.name + "&appid=" + apiKeys;
            var client2 = new RestClient(weatherLink);
            var request2 = new RestRequest("", Method.Get);
            request.AddHeader("content-type", "application/json");
            RestResponse response2 = client2.Execute(request2);

            return Json(response.Content.ToString() + response2.Content.ToString());
        }

    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using TRSRestAPI.Models;
using TRSRestAPI.Repository;

namespace TRSRestAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TRSController : Controller
    {

        private readonly ILogger<TRSController> _logger;
        private readonly DBModelsContext _db;
        private readonly IJWTManagerRepository _jWTManager;
        public TRSController(ILogger<TRSController> logger, DBModelsContext db, IJWTManagerRepository jWTManager)
        {
            _logger = logger;
            _db = db;
            _jWTManager = jWTManager;
        }

        //[AllowAnonymous]
        [HttpGet]
        [Route("getTravelData")]
        public IActionResult Get()
        {
            
            var TravelReqs = _db.TravelRequests;
            return Json(TravelReqs);
        }

        [HttpPost]
        [Route("addTravelData")]
        public IActionResult Post([FromBody] TravelRequests TravelReq)
        {
            TravelRequests travelRequest = new TravelRequests
            {
                RequestDate = DateTime.Now,
                SourceLocation = TravelReq.SourceLocation,
                SourceCountry = TravelReq.SourceCountry,
                DestinationLocation = TravelReq.DestinationLocation,
                DestinationCountry = TravelReq.DestinationCountry,
                DepartureTimestamp = TravelReq.DepartureTimestamp,
                TravelClass = TravelReq.TravelClass,
                TripType = TravelReq.TripType,
                ChargeCode = TravelReq.ChargeCode,
                TravelerName = TravelReq.TravelerName,
                RequestStatus = TravelReq.RequestStatus
            };

            _db.TravelRequests.Add(travelRequest);
            _db.SaveChanges();

            return Json(travelRequest.RequestID);
        }

        [HttpPut]
        [Route("updateTravelData")]
        public IActionResult Put([FromBody] TravelRequests TravelReq)
        {
            var travelRequest = _db.TravelRequests.Find(TravelReq.RequestID);
            if (travelRequest == null || travelRequest.RequestStatus=="Booked")
            {
                return Json("Request Instance is either not found or it has been booked!");
            }

            travelRequest.SourceLocation = TravelReq.SourceLocation;
            travelRequest.SourceCountry = TravelReq.SourceCountry;
            travelRequest.DestinationLocation = TravelReq.DestinationLocation;
            travelRequest.DestinationCountry = TravelReq.DestinationCountry;
            travelRequest.DepartureTimestamp = TravelReq.DepartureTimestamp;
            travelRequest.TravelClass = TravelReq.TravelClass;
            travelRequest.TripType = TravelReq.TripType;
            travelRequest.ChargeCode = TravelReq.ChargeCode;
            travelRequest.TravelerName = TravelReq.TravelerName;
            travelRequest.RequestStatus = TravelReq.RequestStatus;

            _db.TravelRequests.Update(travelRequest);
            _db.SaveChanges();

            return Json("Done");
        }

        [HttpDelete]
        [Route("deleteTravelData")]
        public IActionResult Delete([FromBody] int id)
        {
            var travelRequest = _db.TravelRequests.Find(id);
            if (travelRequest == null || travelRequest.RequestStatus == "Booked")
            {
                return Json("Request Instance is either not found or it has been booked!");
            }
            _db.TravelRequests.Remove(travelRequest);
            _db.SaveChanges();
            return Json("Deleted Successfully!");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel user)
        {
            /*var register = new AuthenticationModel
            {
                UserName = user.UserName,
                UserPassword = user.UserPassword
            };

            _db.UserAuthentication.Add(register);
            _db.SaveChanges();*/

            var token = _jWTManager.Authenticate(user);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPost]
        [Route("search")]
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

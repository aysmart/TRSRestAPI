using System.ComponentModel.DataAnnotations;
namespace TRSRestAPI.Models
{
    public class TravelRequests
    {
        [Key]
        public int RequestID { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? SourceLocation { get; set; }
        public string? SourceCountry { get; set; }
        public string? DestinationLocation { get; set; }
        public string? DestinationCountry { get; set; }
        public DateTime DepartureTimestamp { get; set; }
        public string? TravelClass { get; set; }
        public string? TripType { get; set; }
        public string? ChargeCode { get; set; }
        public string? TravelerName { get; set; }
        public string? RequestStatus { get; set; }
    }
}

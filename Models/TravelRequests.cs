using System.ComponentModel.DataAnnotations;
namespace TRSRestAPI.Models
{
    public class TravelRequests
    {
        [Key]
        public int RequestID { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string SourceLocation { get; set; }
        [Required]
        public string SourceCountry { get; set; }
        [Required]
        public string DestinationLocation { get; set; }
        [Required]
        public string DestinationCountry { get; set; }
        [Required]
        public DateTime DepartureTimestamp { get; set; }
        [Required]
        public string TravelClass { get; set; }
        [Required]
        public string TripType { get; set; }
        [Required]
        public string ChargeCode { get; set; }
        [Required]
        public string TravelerName { get; set; }
        [Required]
        public string RequestStatus { get; set; }
    }
}

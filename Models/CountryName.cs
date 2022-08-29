using System.ComponentModel.DataAnnotations;
namespace TRSRestAPI.Models
{
    public class CountryName
    {
        [Key]
        public int RequestID { get; set; }
        [Required]
        public string? name { get; set; }
    }
}

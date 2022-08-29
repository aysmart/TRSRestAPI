using System.ComponentModel.DataAnnotations;
namespace TRSRestAPI.Models
{
    public class AuthenticationModel
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public DateTime RegDate { get; set; } = DateTime.Now;
    }
}

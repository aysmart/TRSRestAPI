using System.ComponentModel.DataAnnotations;
namespace TRSRestAPI.Models
{
    public class JwtTokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

    }
}

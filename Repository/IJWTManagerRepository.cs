using TRSRestAPI.Models;

namespace TRSRestAPI.Repository
{
    public interface IJWTManagerRepository
    {
        JwtTokens Authenticate(AuthenticationModel users);
    }

}

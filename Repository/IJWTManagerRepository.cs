using TRSRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRSRestAPI.Repository
{
    public interface IJWTManagerRepository
    {
        JwtTokens Authenticate(AuthenticationModel users);
    }

}

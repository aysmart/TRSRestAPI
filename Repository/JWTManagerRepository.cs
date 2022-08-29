using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TRSRestAPI.Repository;
using TRSRestAPI.Models;

public class JWTManagerRepository : IJWTManagerRepository
{
	Dictionary<string, string> UsersRecs = new Dictionary<string, string>
	{
		{ "pwc1","password1"},
		{ "pwc2","password2"},
		{ "pwc3","password3"},
	};

	private readonly IConfiguration iconfiguration;
	//private readonly DBModelsContext _db;
	public JWTManagerRepository(IConfiguration iconfiguration)
	{
		this.iconfiguration = iconfiguration;
	//	_db = db;
	}
	public JwtTokens Authenticate(AuthenticationModel users)
	{
		//var UsersData = _db.UserAuthentication;
		if (!UsersRecs.Any(x => x.Key == users.UserName && x.Value == users.UserPassword))
		{
			return null;
		}

		// Else generate JSON Web Token
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
		  {
			 new Claim(ClaimTypes.Name, users.UserName)
		  }),
			Expires = DateTime.UtcNow.AddMinutes(60),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return new JwtTokens { Token = tokenHandler.WriteToken(token) };

	}
}
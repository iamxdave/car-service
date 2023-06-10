using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace backend.Helpers.Jwt
{
    public class JwtService : IJwtService
    {
        //private readonly string secureKey;
        private readonly IConfiguration _configuration;
        private readonly string jwt_token;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            jwt_token = _configuration.GetValue<string>("JwtToken") ?? throw new ArgumentNullException("JwtToken not found"); 
        }

        public string Generate(Guid id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt_token));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(14));

            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwt_token);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken) validatedToken;
        }
    }
}
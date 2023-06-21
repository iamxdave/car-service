using System.IdentityModel.Tokens.Jwt;

namespace backend.Helpers.Jwt
{
    public interface IJwtService
    {
        public string Generate(Guid id);
        public JwtSecurityToken Verify(string jwt);
    }
}
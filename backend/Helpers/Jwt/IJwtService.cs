using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers.Jwt
{
    public interface IJwtService
    {
        public string Generate(int id);
        public JwtSecurityToken Verify(string jwt);
    }
}
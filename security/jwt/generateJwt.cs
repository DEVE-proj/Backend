using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DeveSecurity
{
    partial class Auth
    {
        public static string GenerateJwt(GetUserDto data)
        {
            Claim[] claims =
            [
                new Claim(JwtRegisteredClaimNames.Sub, data.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, data.Name),
                new Claim("login", data.Login)
            ];

            string secretKey = "34u584ngwejg-324252001143576845m";
            var ketBytes = Encoding.UTF8.GetBytes(secretKey);
            var securityKey = new SymmetricSecurityKey(ketBytes);
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "DEVE",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
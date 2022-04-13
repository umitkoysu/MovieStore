using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.MovieStore.Application.Results;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.MovieStore.Application.Authentication
{
    public class JwtTokenBuilder
    {
        private readonly IConfiguration _configuration;
        public JwtTokenBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenBuilderResult GetToken(int userId)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT")["Key"]));
            var authorizeClaims = new List<Claim>
            {
                new Claim(nameof(ClaimType.Id), userId.ToString()),
            };


            var token = new JwtSecurityToken(
                    expires: DateTime.Now.ToLocalTime().AddHours(2),
                    claims: authorizeClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

            var refreshClaims = new List<Claim>
            {
                new Claim(nameof(ClaimType.Id), userId.ToString()),
                new Claim(nameof(ClaimType.RefreshToken), "true")
            };

            var refreshToken = new JwtSecurityToken(
                expires: DateTime.Now.ToLocalTime().AddDays(3),
                claims: refreshClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var result = new TokenBuilderResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken),
            };

            return result;

        }
    }
}

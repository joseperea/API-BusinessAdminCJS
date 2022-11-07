
using API_BusinessAdminCJS.Data.Entities;
using API_BusinessAdminCJS.ModelsView;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_BusinessAdminCJS.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _configuration;
        private Usuario _user;

        public AuthManager(UserManager<Usuario> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = getSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOption(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOption(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtsettings = _configuration.GetSection("Jwt");
            var lifeTime = DateTime.Now.AddMinutes(Convert.ToDouble(jwtsettings.GetSection("lifeTime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtsettings.GetSection("Issuer").Value,
                claims: claims,
                expires: lifeTime,
                signingCredentials: signingCredentials
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, _user.UserName) };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var itemRole in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, itemRole));
            }

            return claims;
        }

        private SigningCredentials getSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginUserDTO loginUserDTO)
        {
            _user = await _userManager.FindByNameAsync(loginUserDTO.Email);

            bool CheckPassword =  await _userManager.CheckPasswordAsync(_user, loginUserDTO.Password);

            return (_user != null && await _userManager.CheckPasswordAsync(_user, loginUserDTO.Password));
        }
    }
}

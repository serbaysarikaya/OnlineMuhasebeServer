using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineMuhasebeServer.Infrastructure.Authentication;
using System.Text;

namespace OnlineMuhasebeServer.WebApi.OptionsSetup
{
    public class JwtBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOtions;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOtions)
        {
            _jwtOtions = jwtOtions.Value;
        }

        public void PostConfigure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters.ValidateIssuer = true;
            options.TokenValidationParameters.ValidateAudience = true;
            options.TokenValidationParameters.ValidateLifetime = true;
            options.TokenValidationParameters.ValidateIssuerSigningKey = true;
            options.TokenValidationParameters.ValidIssuer = _jwtOtions.Issuer;
            options.TokenValidationParameters.ValidAudience = _jwtOtions.Audience;
            options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOtions.SecretKey));
        }
    }
}

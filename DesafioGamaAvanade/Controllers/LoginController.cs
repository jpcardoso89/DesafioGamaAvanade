using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using DesafioGamaAvanade.Business.Models.Inputs;
using Marraia.Notifications.Base;
using Marraia.Notifications.Handlers;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace SuperHero.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;
        private readonly DomainNotificationHandler _smartNotification;

        public LoginController(ILoginService loginService,
            IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<object> Post([FromBody] LoginInput input,
                                        [FromServices] SigningConfigurations signingConfigurations)
        {
            try
            {
                var logged = await _loginService
                                    .LoginAsync(input.Login, input.Password)
                                    .ConfigureAwait(false);

                if (logged != default)
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(logged.Login, "Login"),
                        new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, logged.Id.ToString()),
                        new Claim(ClaimTypes.Role, logged.Profile.Description),
                        new Claim("ProfileId", logged.Profile.Id.ToString())
                        }
                    );

                    var dateCreated = DateTime.Now;
                    var dateExpiration = dateCreated + TimeSpan.FromSeconds(int.Parse(_configuration["TokenSeconds"]));

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = _configuration["TokenIssuer"],
                        Audience = _configuration["TokenAudience"],
                        SigningCredentials = signingConfigurations.SigningCredentials,
                        Subject = identity,
                        NotBefore = dateCreated,
                        Expires = dateExpiration
                    });
                    var token = handler.WriteToken(securityToken);

                    return new
                    {
                        authenticated = true,
                        created = dateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = dateExpiration.ToString("yyyy-MM-dd HH:mm:ss"),
                        accessToken = token,
                        message = "OK"
                    };
                }


                return Unauthorized(_smartNotification.GetNotifications());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.InnerException);
            }
        }
    }
}

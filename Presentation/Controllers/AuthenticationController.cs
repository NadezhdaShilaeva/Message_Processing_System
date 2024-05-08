using System.Net;
using System.Security.Claims;
using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Accounts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _service;

        public AuthenticationController(ILoginService service)
        {
            _service = service;
        }

        public CancellationToken CancellationToken => HttpContext.RequestAborted;

        [HttpPost]
        public async Task<IActionResult> LogInToTheAccountAsync([FromBody] LoginAccountModel model)
        {
            AccountDto account = await _service.LogInToTheAccountAsync(model.emploeeId, model.login, model.password, CancellationToken);

            if (account is null)
            {
                return AccessDenied();
            }

            var claims = new Claim[]
            {
            new Claim(ClaimTypes.Name, account.login),
            new Claim(ClaimTypes.Sid, account.id.ToString()),
            new Claim(ClaimTypes.Role, account.role),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return Ok(account);
        }

        [Route("error")]
        [HttpGet]
        [HttpPost]
        public IActionResult AccessDenied()
        {
            Claim? roleClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);

            return roleClaim is not null
                ? StatusCode((int)HttpStatusCode.Forbidden, $"User with role {roleClaim.Value} is not authorized to invoke this method")
                : Unauthorized("User is not authenticated");
        }
    }
}

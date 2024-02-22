using EdynamicsLog.Prueba.Api.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MultitenantInventario.Application.Interfaces;
using MultitenantInventario.Domain.Entities;

namespace MultitenantInventario.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IAuthenticationServices authenticationService, IUserService userService) : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService = authenticationService;
        private readonly IUserService _userService = userService;

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest($"Porfavor validar datos ingresados: {model}");

            var user = model.Adapt<User>();

            var userResponse = await _userService.FindUserAsync(user);

            var token = _authenticationService.GenerateJwtToken(userResponse);

            return Ok(new ModelResponse<ResponseJwt>
            {
                Status = 200,
                StatusText = "Post Request success",
                Data = new ResponseJwt
                {
                    AccessToken = token,
                    Tenants = new List<object>
                    {
                        new {SlugTenant = userResponse.Organization.Name}
                    }
                }
            });
        }
    }
}

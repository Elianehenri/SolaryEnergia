using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Interfaces.Services;

namespace SolaryEnergia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        private readonly IUserService _userService;

        public AutenticacaoController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(
        [FromBody] LoginDto login)
        {
            return Ok(_userService.GetUser(login));
        }

        [HttpPost]
        [Route("refresh-token")]
        [AllowAnonymous]
        public IActionResult Refresh(
       [FromQuery] string token,
       [FromQuery] string refreshToken)
        {

            return Ok(_userService.RefreshToken(token, refreshToken));
        }
    }
}

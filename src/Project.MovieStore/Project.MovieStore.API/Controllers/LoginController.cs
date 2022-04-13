using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.MovieStore.API.Helpers;
using Project.MovieStore.Application.Authorization;
using Project.MovieStore.Application.Services;
using Project.MovieStore.Application.Services.Categories.Dto;

namespace Project.LoginStore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService _LoginService { get; set; }
        public LoginController(ILoginService LoginService)
        {
            _LoginService = LoginService;
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromBody] LoginPostDto body)
        {
            return Ok(await _LoginService.LoginManagerAsync(body));
        }

        [Authorize(nameof(PolicyGroup.REFRESH_TOKEN_POLICY))]
        [HttpGet]
        public async Task<ActionResult> RefreshLoginAsync()
        {
            var userId = ClaimReader.ReadUserId(HttpContext);

            return Ok(await _LoginService.RefReshLoginManagerAsync(userId));
        }

    }
}

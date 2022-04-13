using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.MovieStore.Application.Authorization;
using Project.MovieStore.Application.Services;
using Project.MovieStore.Application.Services.Users.Dto;

namespace Project.UserStore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _UserService { get; set; }
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpGet("{UserId}")]
        public async Task<ActionResult> GetAsync(int UserId)
        {
            return Ok(await _UserService.GetAsync(UserId));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _UserService.GetAllAsync());
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpPut("{UserId}")]
        public async Task<ActionResult> UpdateAsync(int UserId, [FromBody] UserUpdateDto body)
        {
            return Ok(await _UserService.UpdateAsync(UserId, body));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpPatch("{UserId}/password")]
        public async Task<ActionResult> PatchPasswordAsync(int UserId, [FromBody] UserPatchPasswordDto body)
        {
            return Ok(await _UserService.PatchPasswordAsync(UserId, body));
        }

        [HttpPost("register")]
        public async Task<ActionResult> AddAsync([FromBody] UserAddDto body)
        {
            return Ok(await _UserService.AddAsync(body));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpDelete("{UserId}")]
        public async Task<ActionResult> DeleteAsync(int UserId)
        {
            return Ok(await _UserService.DeleteAsync(UserId));
        }

    }
}

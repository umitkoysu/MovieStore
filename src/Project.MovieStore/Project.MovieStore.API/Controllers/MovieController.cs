using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.MovieStore.Application.Authorization;
using Project.MovieStore.Application.Services;
using Project.MovieStore.Application.Services.Movies.Dto;

namespace Project.MovieStore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IMovieService _movieService { get; set; }
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpGet("{movieId}")]
        public async Task<ActionResult> GetAsync(int movieId)
        {
            return Ok(await _movieService.GetAsync(movieId));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _movieService.GetAllAsync());
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpPut("{movieId}")]
        public async Task<ActionResult> UpdateAsync(int movieId, [FromBody] MovieAddOrUpdateDto body)
        {
            return Ok(await _movieService.UpdateAsync(movieId, body));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] MovieAddOrUpdateDto body)
        {
            return Ok(await _movieService.AddAsync(body));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpDelete("{movieId}")]
        public async Task<ActionResult> DeleteAsync(int movieId)
        {
            return Ok(await _movieService.DeleteAsync(movieId));
        }

    }
}

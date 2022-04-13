using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.CategoryStore.Application.Services;
using Project.MovieStore.Application.Authorization;
using Project.MovieStore.Application.Services.Categories.Dto;

namespace Project.CategoryStore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _categoryService { get; set; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpGet("{categoryId}")]
        public async Task<ActionResult> GetAsync(int categoryId)
        {
            return Ok(await _categoryService.GetAsync(categoryId));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateAsync(int categoryId, [FromBody] CategoryAddOrUpdateDto body)
        {
            return Ok(await _categoryService.UpdateAsync(categoryId, body));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CategoryAddOrUpdateDto body)
        {
            return Ok(await _categoryService.AddAsync(body));
        }

        [Authorize(Policy = nameof(PolicyGroup.CHECK_CLAIM_POLICY))]
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeleteAsync(int categoryId)
        {
            return Ok(await _categoryService.DeleteAsync(categoryId));
        }

    }
}

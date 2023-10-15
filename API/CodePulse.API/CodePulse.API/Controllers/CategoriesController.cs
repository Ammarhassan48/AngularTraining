using AutoMapper;
using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository,
            ILogger<CategoriesController> logger,IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this._logger = logger;
            this._mapper = mapper;
            _logger.LogInformation("Categories Controller called");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
        {
            _logger.LogInformation("CreateCategory Action invoked");

            Category category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            
            await categoryRepository.CreateAsync(category);
            
            CategoryDto response = new CategoryDto
            {
                Id = category.Id, 
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            return Ok(response); 
        }

        // GET: /api/categories
        // https://localhost:7121/api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            _logger.LogInformation("GetAllCategories method invoked");

            var categories = await categoryRepository.GetAllAsync();

            // Map domain model to DTO

            var response = new List<CategoryDto>();

            foreach (var cateogory in categories)
            {
                response.Add(_mapper.Map<CategoryDto>(cateogory));
            }

            return Ok(response);
        }


        // GET: https://localhost:7121/api/Categories{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAllCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await categoryRepository.GetById(id);

            if (existingCategory is null)
            {
                return NotFound();
            }

            var response = new CategoryDto 
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };

            return Ok(response);
        }

        // PUT: https://localhost:7121/api/Categories{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id,UpdateCategoryRequestDto request)
        {
            // Convert DTO to domain model
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            category = await categoryRepository.UpdateAsync(category);
            
            if (category == null)
            {
                return NotFound();
            }
            // convert domain model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        // DELETE: https://localhost:7121/api/Categories{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleteAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            // Convert domain model to DTO
            var response = new CategoryDto 
            {
                Id = category.Id, 
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }
    }
}
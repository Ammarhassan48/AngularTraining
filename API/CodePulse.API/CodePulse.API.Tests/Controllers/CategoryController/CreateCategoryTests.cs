using AutoMapper;
using CodePulse.API.Controllers;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.API.Tests.Controllers.CategoryController
{
    public class CreateCategoryTests
    {
        private readonly Mock<ICategoryRepository> categoryRepository;
        private readonly Mock<ILogger<CategoriesController>> logger;
        private readonly Mock<IMapper> mapper;

        public CreateCategoryTests()
        {
            categoryRepository = new Mock<ICategoryRepository>();
            logger = new Mock<ILogger<CategoriesController>>();
            mapper = new Mock<IMapper>();
        }

        [Fact]
        public void CreateCategoryTest_HappyCase()
        {
            // Arrange
            Category category = GetCategoryObject();       
            
            categoryRepository.Setup(x=>x.CreateAsync(category)).Returns(Task.FromResult(category));
            
            CategoriesController categoriesController = new CategoriesController(categoryRepository.Object, logger.Object, mapper.Object);
            
            CreateCategoryRequestDto createCategoryRequestDto = GetCreateCategoryRequestDtoObject();
           
            // Act
            var response = categoriesController.CreateCategory(createCategoryRequestDto);

            // Assert
            // Assert.Equal(createCategoryRequestDto.Name,JsonConvert.DeserializeObject<CategoryDto>(response).Name);
        }

        private CreateCategoryRequestDto GetCreateCategoryRequestDtoObject()
        {
            CreateCategoryRequestDto createCategoryRequestDto = new CreateCategoryRequestDto
            {
                Name = "ABC",
                UrlHandle = "www.att.com"
            };
            return createCategoryRequestDto;
        }

        private Category GetCategoryObject()
        {
            Category category = new Category
            {
                Id = Guid.Empty,
                Name = "ABC",
                UrlHandle = "www.att.com"
            };

            return category;
        }
    }
}

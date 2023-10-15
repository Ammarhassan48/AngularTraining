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
        private readonly Mock<ICategoryRepository> categoryRepositoryMoq;
        private readonly Mock<ILogger<CategoriesController>> logger;
        private readonly Mock<IMapper> mapper;

        public CreateCategoryTests()
        {
            categoryRepositoryMoq = new Mock<ICategoryRepository>(); // Normal Mock of service
            logger = new Mock<ILogger<CategoriesController>>();
            mapper = new Mock<IMapper>();
        }

        [Fact]
        public void CreateCategoryTest_HappyCase()
        {
            // Arrange
            Category category = GetCategoryObject();       
            
            categoryRepositoryMoq.Setup(x=>x.CreateAsync(category)).Returns(Task.FromResult(category));
        
            var LazyCategoryRepositoryService = new Lazy<ICategoryRepository>(categoryRepositoryMoq.Object); // Prepare Lazy Mock

            CategoriesController categoriesController = new CategoriesController(LazyCategoryRepositoryService, logger.Object, mapper.Object);
            
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

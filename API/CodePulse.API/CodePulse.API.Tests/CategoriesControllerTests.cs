using CodePulse.API.Controllers;
using CodePulse.API.Repositories.Interface;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.API.Tests
{
    public class CategoriesControllerTests
    {
        private readonly Mock<ICategoryRepository> categoryRepository;
        private readonly Mock<ILogger<CategoriesController>> logger;

        public CategoriesControllerTests()
        {
                categoryRepository = new Mock<ICategoryRepository>();
            logger = new Mock<ILogger<CategoriesController>>();
        }

        [Fact]
        public void getAllCategories_Logic()
        {
            // this is act 
            // Arrange 
            //var cateogriesController = new CategoriesController(categoryRepository,logger);

            // Act 

            // Assert
        }

        /// <summary>
        /// Mock Data function for provide all categories data
        /// </summary>
        public void GetCategoriesData()
        {

        }

    }
}

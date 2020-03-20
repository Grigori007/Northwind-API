using Moq;
using NorthwindContextLib;
using NorthwindService.Controllers;
using NorthwindService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class CategoriesControllerTest
    {
        private readonly Mock<ICategoriesRepository> categoriesRepoMock;
        private readonly CategoriesController categoriesController;

        public CategoriesControllerTest()
        {
            categoriesRepoMock = new Mock<ICategoriesRepository>();
            categoriesController = new CategoriesController(categoriesRepoMock.Object);
        }

        [Fact]
        public async Task ReadEntitiesTest_ReturnsCategoriesCollection()
        {
            // Arrange
            var mockCategoriesList = new List<Category>
            {
                new Category {CategoryName = "Example Category 1"},
                new Category {CategoryName = "Example Category 2"}
            };

            var iMockCategoriesList = (IEnumerable<Category>)mockCategoriesList;

            categoriesRepoMock
                .Setup(c => c.GetAllAsync())
                .Returns(Task.FromResult(iMockCategoriesList));

            // Act
            var result = await categoriesController.ReadEntities();

            // Assert
            Assert.NotEmpty(result);
        }
    }
}

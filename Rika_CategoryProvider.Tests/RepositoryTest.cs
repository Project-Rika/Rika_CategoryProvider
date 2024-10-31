using Moq;
using Rika_CategoryProvider.Infrastructure.Entities;
using Rika_CategoryProvider.Infrastructure.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Rika_CategoryProvider.Tests
{
    public class BaseRepositoryTests
    {
        private readonly Mock<IBaseRepository<Category>> _repositoryMock;

        public BaseRepositoryTests()
        {
            _repositoryMock = new Mock<IBaseRepository<Category>>();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectEntity()
        {
            // Arrange
            var expectedCategory = new Category { Id = 1, Name = "Test Category" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(expectedCategory);

            // Act
            var result = await _repositoryMock.Object.GetByIdAsync(1);

            // Assert
            Assert.Equal(expectedCategory, result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            // Arrange
            var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" }
        };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

            // Act
            var result = await _repositoryMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddAsync_ShouldReturnAddedEntity()
        {
            // Arrange
            var newCategory = new Category { Id = 3, Name = "New Category" };
            _repositoryMock.Setup(repo => repo.AddAsync(newCategory)).ReturnsAsync(newCategory);

            // Act
            var result = await _repositoryMock.Object.AddAsync(newCategory);

            // Assert
            Assert.Equal(newCategory, result);
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
       
    }
}

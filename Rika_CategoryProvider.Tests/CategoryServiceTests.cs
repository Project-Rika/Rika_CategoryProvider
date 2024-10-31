﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using Rika_CategoryProvider.Infrastructure.Entities;
using Rika_CategoryProvider.Infrastructure.Repos;

namespace Rika_CategoryProvider.Tests;

public class CategoryServiceTests
{
    private readonly Mock<CategoryRepository> _categoryRepositoryMock;
    private readonly Mock<ILogger<CategoryService>> _loggerMock;
    private readonly CategoryService _categoryService;

    public CategoryServiceTests()
    {
        _categoryRepositoryMock = new Mock<CategoryRepository>();
        _loggerMock = new Mock<ILogger<CategoryService>>();
        _categoryService = new CategoryService(_categoryRepositoryMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task AddCategoryAsync_ShouldAddCategory_WhenCategoryDoesNotExist()
    {
        // Arrange
        var categoryName = "New Category";
        _categoryRepositoryMock?.Setup(repo => repo.GetCategoryAsync(It.IsAny<Func<CategoryEntity, bool>>()))
                               .ReturnsAsync((CategoryEntity)null);  // Simulera att kategorin inte finns

        _categoryRepositoryMock?.Setup(repo => repo.AddAsync(It.IsAny<CategoryEntity>()))
                               .ReturnsAsync(new CategoryEntity { CategoryName = categoryName });

        // Act
        var result = await _categoryService.AddCategoryAsync(categoryName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categoryName, result.CategoryName);
        _categoryRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<CategoryEntity>()), Times.Once);
    }

    [Fact]
    public async Task AddCategoryAsync_ShouldThrowException_WhenCategoryAlreadyExists()
    {
        // Arrange
        var categoryName = "Existing Category";
        _categoryRepositoryMock.Setup(repo => repo.GetCategoryAsync(It.IsAny<Func<CategoryEntity, bool>>()))
                               .ReturnsAsync(new CategoryEntity { CategoryName = categoryName }); // Simulera att kategorin redan finns

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _categoryService.AddCategoryAsync(categoryName));
    }

    [Fact]
    public async Task GetAllCategoriesAsync_ShouldReturnCategories()
    {
        // Arrange
        var categories = new List<CategoryEntity>
        {
            new CategoryEntity { CategoryName = "Category 1" },
            new CategoryEntity { CategoryName = "Category 2" }
        };
        _categoryRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

        // Act
        var result = await _categoryService.GetAllCategoriesAsync();

        // Assert
        Assert.Equal(2, result.Count());
        _categoryRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllCategoriesAsync_ShouldLogError_WhenExceptionThrown()
    {
        // Arrange
        _categoryRepositoryMock.Setup(repo => repo.GetAllAsync()).ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _categoryService.GetAllCategoriesAsync());
        _loggerMock.Verify(
            logger => logger.LogError(It.IsAny<Exception>(), "An error occurred while getting all categories."),
            Times.Once
        );
    }
}


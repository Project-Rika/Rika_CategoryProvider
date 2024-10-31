using Microsoft.Extensions.Logging;
using Rika_CategoryProvider.Infrastructure.Entities;
using Rika_CategoryProvider.Infrastructure.Repos;

public class CategoryService
{
    private readonly IBaseRepository<CategoryEntity> _categoryRepository;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(IBaseRepository<CategoryEntity> categoryRepository, ILogger<CategoryService> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }


    public async Task<CategoryEntity> AddCategoryAsync(string categoryName)
	{
		var existingCategory = await _categoryRepository.GetCategoryAsync(x => x.CategoryName == categoryName);
		if (existingCategory != null)
		{
			throw new InvalidOperationException("Category already exists.");
		}

		var newCategory = new CategoryEntity
		{
			CategoryName = categoryName
		};

		var addedCategory = await _categoryRepository.AddAsync(newCategory);
		return addedCategory;
	}

	public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
	{
		try
		{
			return await _categoryRepository.GetAllAsync();
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while getting all categories.");
			throw; 
		}
	}
}







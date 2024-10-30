//using Microsoft.EntityFrameworkCore;
//using Rika_CategoryProvider.Infrastructure.Context;
//using Rika_CategoryProvider.Infrastructure.Entities;
//using Rika_CategoryProvider.Infrastructure.Repos;

//public class CategoryService(CategoryRepository categoryRepository)
//{
//	private readonly CategoryRepository _categoryRepository = categoryRepository;

//	public async Task<CategoryEntity> AddCategoryAsync(string categoryName)
//	{
//		var result = await _categoryRepository.GetCategoryAsync(x => x.CategoryName = categoryName);


//		await _context.Categories.AddAsync(entity);
//		await _context.SaveChangesAsync();
//		return entity;
//	}

//	public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity entity)
//	{
//		_context.Categories.Update(entity);
//		await _context.SaveChangesAsync();
//		return entity;
//	}

//	public async Task<CategoryEntity> DeleteCategoryAsync(CategoryEntity entity)
//	{
//		_context.Categories.Remove(entity);
//		await _context.SaveChangesAsync();
//		return entity;
//	}

//	public async Task<CategoryEntity?> GetCategoryByIdAsync(int id)
//	{
//		return await _context.Categories.FindAsync(id);
//	}

//	public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
//	{
//		return await _context.Categories.ToListAsync();
//	}

//}




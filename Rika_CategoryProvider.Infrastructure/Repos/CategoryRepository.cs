using Microsoft.EntityFrameworkCore;
using Rika_CategoryProvider.Infrastructure.Context;
using Rika_CategoryProvider.Infrastructure.Entities;
using System.Linq.Expressions;

namespace Rika_CategoryProvider.Infrastructure.Repos;

public class CategoryRepository : IBaseRepository<CategoryEntity>
{
	private readonly CategoryDbContext _context;

	public CategoryRepository(CategoryDbContext context)
	{
		_context = context;
	}

	public async Task<CategoryEntity> AddAsync(CategoryEntity entity)
	{
		await _context.Categories.AddAsync(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<CategoryEntity> UpdateAsync(CategoryEntity entity)
	{
		_context.Categories.Update(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<CategoryEntity> DeleteAsync(CategoryEntity entity)
	{
		_context.Categories.Remove(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<CategoryEntity?> GetByIdAsync(int id)
	{
		return await _context.Categories.FindAsync(id);
	}

	public async Task<CategoryEntity?> GetByNameAsync(string name)
	{
		return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == name);
	}

	public async Task<CategoryEntity?> GetCategoryAsync(Expression<Func<CategoryEntity, bool>> predicate)
	{
		try
		{
			if (await _context.Categories.AnyAsync(predicate))
			{
				return await _context.Categories.FirstOrDefaultAsync(predicate);
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	public async Task<IEnumerable<CategoryEntity>> GetAllAsync()

	{
		return await _context.Categories.ToListAsync();
	}

    public void GetCategoryAsync(Func<CategoryEntity, bool> func)
    {
        throw new NotImplementedException();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rika_CategoryProvider.Infrastructure.Repos
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<T> DeleteAsync(T entity);
		Task<T?> GetByIdAsync(int id);
		Task<T?> GetByNameAsync(string name);
		Task<IEnumerable<T>> GetAllAsync();
	}
}

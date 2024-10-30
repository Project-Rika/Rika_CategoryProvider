using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Rika_CategoryProvider.Infrastructure.Entities
{
	public class CategoryEntity
	{
		[Key]
		public int CategoryId { get; set; }

		[Required]
		public string CategoryName { get; set; } = null!;

		public ICollection<int> ProductIds { get; set; } = new List<int>();
	}
}

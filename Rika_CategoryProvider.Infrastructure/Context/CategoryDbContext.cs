using Microsoft.EntityFrameworkCore;
using Rika_CategoryProvider.Infrastructure.Entities;

namespace Rika_CategoryProvider.Infrastructure.Context
{
	public class CategoryDbContext : DbContext
	{
		public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
		{
		}

		public DbSet<CategoryEntity> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CategoryEntity>(entity =>
			{
				entity.HasKey(e => e.CategoryId);
				entity.Property(e => e.CategoryName).IsRequired();

				entity.Property(e => e.ProductIds)
					  .HasConversion(
						  v => string.Join(',', v),
						  v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
			});
		}
	}
}

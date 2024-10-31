using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rika_CategoryProvider.Tests
{
	internal class RepositoryTest
	{
	}
}



public class BaseRepositoryTests
{
	private readonly Mock<IBaseRepository<OrderEntity>> _mockRepository;

	public BaseRepositoryTests()
	{
		_mockRepository = new Mock<IBaseRepository<OrderEntity>>();
	}


	[Fact]
	public async Task CreateAsync_ShouldReturnOrderEntity()
	{
		// Arrange
		var customer = new OrderCustomerEntity
		{
			CustomerName = "John Doe",
			CustomerEmail = "john@domain.com",
			CustomerPhone = "1234567890"
		};

		var address = new OrderAddressEntity
		{
			Address = "123 Main",
			City = "New York",
			PostalCode = "10001",
			Country = "USA"
		};

		var products = new List<OrderProductEntity>
		{
			new() {
				ProductName = "Product 1",
				UnitPrice = "50",
				Quantity = "2"
			},
			new() {
				ProductName = "Product 2",
				UnitPrice = "100",
				Quantity = "5"
			}
		};

		var orderEntity = new OrderEntity
		{
			TotalAmount = "100",
			PaymnetMehod = "Cash",
			ShipmentMethod = "UPS",
			OrderAddress = address,
			OrderProducts = products,
			OrderCustomer = customer,
		};
		_mockRepository.Setup(x => x.CreateAsync(orderEntity)).ReturnsAsync(orderEntity);

		// Act
		var result = await _mockRepository.Object.CreateAsync(orderEntity);

		// Assert
		Assert.NotNull(result);
		Assert.Equal(orderEntity, result);
		Assert.Equal("John Doe", result.OrderCustomer.CustomerName);
		Assert.Equal("Product 1", result.OrderProducts.FirstOrDefault(x => x.ProductName == "Product 1")!.ProductName);
		Assert.Equal("Product 2", result.OrderProducts.FirstOrDefault(x => x.ProductName == "Product 2")!.ProductName);
	}

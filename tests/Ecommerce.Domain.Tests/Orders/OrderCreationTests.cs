using FluentAssertions;
using Xunit;

namespace Ecommerce.Domain.Tests.Orders;

public class OrderCreationTests
{
    [Fact]
    public void Create_ShouldThrowException_WhenItemsAreEmpty()
    {
        // Arrange
        IEnumerable<OrderItem> emptyItems = Enumerable.Empty<OrderItem>();

        // Act
        Action act = () => Order.Create(emptyItems);

        // Assert
        act.Should()
           .Throw<DomainException>()
           .WithMessage("Pedido deve possuir ao menos um item");
    }

    [Fact]
    public void Create_ShouldCreateOrder_WhenItemsAreValid()
    {
        // Arrange
        List<OrderItem> items =
        [
            new OrderItem(Guid.NewGuid(), 1),
            new OrderItem(Guid.NewGuid(), 2)
        ];

        // Act
        Order order = Order.Create(items);

        // Assert
        order.Items.Should().HaveCount(2);
    }
}
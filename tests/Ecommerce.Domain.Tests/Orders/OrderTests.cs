using FluentAssertions;
using Xunit;

namespace Ecommerce.Domain.Tests.Orders;

public class OrderTests
{
    [Fact]
    public void AddItem_ShouldThrowException_WhenQuantityIsLessOrEqualZero()
    {
        // Arrange
        Order order = new();
        OrderItem invalidItem = new(
            productId: Guid.NewGuid(),
            quantity: 0
        );

        // Act
        Action act = () => order.AddItem(invalidItem);

        // Assert
        act.Should()
           .Throw<DomainException>()
           .WithMessage("Quantidade inválida");
    }

    [Fact]
    public void AddItem_ShouldAddItem_WhenQuantityIsValid()
    {
        // Arrange
        Order order = new();
        OrderItem validItem = new(
            productId: Guid.NewGuid(),
            quantity: 2
        );

        // Act
        order.AddItem(validItem);

        // Assert
        order.Items.Should().HaveCount(1);
    }
}
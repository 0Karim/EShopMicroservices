

namespace Ordering.Domain.Models
{
    public class OrderItem : Entity<OrderItemId>
    {
        public OrderItem(OrderId orderId, ProductId productId, int quantity, decimal price)
        {
            Id = OrderItemId.Of(Guid.NewGuid());
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public OrderId OrderId { private set; get; } = default!;

        public ProductId ProductId { private set; get; } = default!;

        public int Quantity { private set; get; } = default!;

        public decimal Price { private set; get; } = default!;
    }
}

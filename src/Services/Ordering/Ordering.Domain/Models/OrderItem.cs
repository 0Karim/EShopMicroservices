using System;


namespace Ordering.Domain.Models
{
    public class OrderItem : Entity<Guid>
    {
        public OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid OrderId { private set; get; } = default!;

        public Guid ProductId { private set; get; } = default!;

        public int Quantity { private set; get; } = default!;

        public decimal Price { private set; get; } = default!;
    }
}

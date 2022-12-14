using Shopi.Challange.Ordering.Core.Enums;

namespace Shopi.Challange.Ordering.Business.Commands.AddNewOrders
{
    public class OrderBody
    {
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public string StoreName { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = default!;
        public OrderStatus Status { get; set; }
    }
}

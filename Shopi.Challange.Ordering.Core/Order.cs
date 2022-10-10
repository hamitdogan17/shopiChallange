using Shopi.Challange.Ordering.Core.Base;

namespace Shopi.Challange.Ordering.Core
{
    public class Order : Entity
    {
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public string StoreName { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Status { get; set; }
    }
}

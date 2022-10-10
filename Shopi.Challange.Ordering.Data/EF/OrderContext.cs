using Microsoft.EntityFrameworkCore;
using Shopi.Challange.Ordering.Core;

namespace Shopi.Challange.Ordering.Data.EF
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}

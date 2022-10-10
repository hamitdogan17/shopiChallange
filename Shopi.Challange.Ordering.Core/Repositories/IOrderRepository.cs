using Shopi.Challange.Ordering.Core.Enums;
using Shopi.Challange.Ordering.Core.Repositories.Base;

namespace Shopi.Challange.Ordering.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByFilter(int pageSize, int pageNumber,
            string searchText, DateTime? startDate, DateTime? endDate, List<OrderStatus> statuses, string sortBy);
    }
}

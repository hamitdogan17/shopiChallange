using FluentValidation.Internal;
using Microsoft.EntityFrameworkCore;
using Shopi.Challange.Ordering.Core;
using Shopi.Challange.Ordering.Core.Enums;
using Shopi.Challange.Ordering.Core.Repositories;
using Shopi.Challange.Ordering.Data.EF;
using Shopi.Challange.Ordering.Data.Repositories.Base;

namespace Shopi.Challange.Ordering.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByFilter(int pageSize, int pageNumber,
            string searchText, DateTime? startDate, DateTime? endDate, List<OrderStatus> statuses, string sortBy)
        {
            var query = _dbContext.Orders.Select(s => s);

            if (!string.IsNullOrEmpty(searchText)) query = query.Where(q => q.CustomerName.ToLower().Contains(searchText.ToLower()) || q.StoreName.ToLower().Contains(searchText.ToLower()));
            if (startDate != null) query = query.Where(q => q.CreatedOn > startDate);
            if (endDate != null) query = query.Where(q => q.CreatedOn < endDate);
            if (statuses?.Count > 0) query = query.Where(q =>  statuses.Select(s => (int)s).Contains(q.Status));
            if (!string.IsNullOrEmpty(sortBy))
            {
                var prop = typeof(Order).GetProperty(sortBy);
                if (prop != null) query = query.OrderBy(x => prop.GetValue(x, null));
            }

            var response  = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return response;
        }
    }
}

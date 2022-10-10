using MediatR;
using Shopi.Challange.Ordering.Core.Enums;

namespace Shopi.Challange.Ordering.Business.Queries.ListOfOrder
{
    public class Request : IRequest<IEnumerable<Response>>
    {        
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string? SearchText { get; set; } = default!;
        public DateTime? StartDate { get; set; } = default!;
        public DateTime? EndDate { get; set; } = default!;
        public List<OrderStatus>? Statuses { get; set; } = default!;
        public string? SortBy { get; set; } = default!; 
    }
}

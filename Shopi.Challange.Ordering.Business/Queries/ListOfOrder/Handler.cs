using MediatR;
using Shopi.Challange.Ordering.Business.Mapper;
using Shopi.Challange.Ordering.Core.Repositories;

namespace Shopi.Challange.Ordering.Business.Queries.ListOfOrder
{
    public class Handler : IRequestHandler<Request, IEnumerable<Response>>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByFilter(request.PageSize, request.PageNumber, request.SearchText, request.StartDate, request.EndDate, request.Statuses, request.SortBy);

            var orderResponseList = OrderMapper.Mapper.Map<IEnumerable<Response>>(orderList);
            return orderResponseList;
        }
    }
}

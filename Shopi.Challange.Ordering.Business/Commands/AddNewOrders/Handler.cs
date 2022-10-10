using MediatR;
using Shopi.Challange.Ordering.Business.Mapper;
using Shopi.Challange.Ordering.Core;
using Shopi.Challange.Ordering.Core.Repositories;

namespace Shopi.Challange.Ordering.Business.Commands.AddNewOrders
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private IOrderRepository _orderRepository; 
        public Handler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var orders = request.OrderList.Where(o => o.BrandId == 0).ToList();

            var orderEntities = OrderMapper.Mapper.Map<IEnumerable<Order>>(orders);
            var result = await _orderRepository.AddRangeAsync(orderEntities.ToList());

            return null;
        }
    }
}

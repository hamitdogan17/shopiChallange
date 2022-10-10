using MediatR;

namespace Shopi.Challange.Ordering.Business.Commands.AddNewOrders
{
    public class Request : IRequest<Response>
    {
        public IList<OrderBody> OrderList { get; set; } = default!;
    }
}

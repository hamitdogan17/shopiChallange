using FluentValidation;
using Shopi.Challange.Ordering.Core.Enums;

namespace Shopi.Challange.Ordering.Business.Commands.AddNewOrders
{
    public class OrderBodyValidator : AbstractValidator<OrderBody>
    {
        public OrderBodyValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.StoreName).NotEmpty();
            RuleFor(x => x.Status).IsInEnum().NotEmpty();
            RuleFor(x => x.CreatedOn).NotEmpty();
        }
    }

    public class AddOrderListRequestValidator : AbstractValidator<Request>
    {
        public AddOrderListRequestValidator()
        {
            RuleForEach(x => x.OrderList).SetValidator(new OrderBodyValidator());
        }
    }
}

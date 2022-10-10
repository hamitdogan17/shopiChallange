using MediatR;
using Microsoft.AspNetCore.Mvc; 
using Shopi.Challange.Ordering.Business.Commands.AddNewOrders;
using System.Net;

namespace Shopi.Challange.Ordering.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddOrders")]
        [ProducesResponseType(typeof(IEnumerable<Response>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Response>>> AddOrders([FromBody] Request request)
        {
            var orders = await _mediator.Send(request);

            return Ok(orders);
        }

        [HttpPost("filterOrder")]
        public async Task<ActionResult<IEnumerable<Business.Queries.ListOfOrder.Response>>> FilterOrder([FromBody] Business.Queries.ListOfOrder.Request request)
        {
            var orders = await _mediator.Send(request);

            return Ok(orders);
        }

    }
}

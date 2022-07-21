using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Producer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public OrderController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Order request)
        {
            await _publishEndpoint.Publish<Order>(request);

            return Ok();
        }
    }
}

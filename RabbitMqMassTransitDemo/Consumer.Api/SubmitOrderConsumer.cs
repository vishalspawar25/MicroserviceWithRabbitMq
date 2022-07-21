using System.Text.Json;
using System.Threading.Tasks;

using MassTransit;
using Microsoft.Extensions.Logging;
using Models;

namespace Consumer.Api
{
    public class SubmitOrderConsumer : IConsumer<Order>
    {
        readonly ILogger<SubmitOrderConsumer> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
            _logger = logger;
        }

        public async  Task Consume(ConsumeContext<Order> context)
        {
            var jsonString = JsonSerializer.Serialize(context.Message);

            _logger.LogInformation("Order Submitted: {OrderId}", jsonString);

            
        }
    }
}

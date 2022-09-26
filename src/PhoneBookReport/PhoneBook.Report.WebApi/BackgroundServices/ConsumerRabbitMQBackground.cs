using Microsoft.Extensions.Hosting;
using PhoneBook.Report.Business.RabbitMQ;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Report.WebApi.BackgroundServices
{
    public class ConsumerRabbitMQBackground : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ConsumerRabbitMQ consumerRabbitMQ = new ConsumerRabbitMQ();
            
            return Task.FromResult(true);
        }
    }
}

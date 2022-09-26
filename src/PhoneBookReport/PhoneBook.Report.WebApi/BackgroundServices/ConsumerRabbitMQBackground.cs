using Microsoft.Extensions.Hosting;
using PhoneBook.Report.Business.RabbitMQ;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Report.WebApi.BackgroundServices
{
    public class ConsumerRabbitMQBackground : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Action instance = () => new ConsumerRabbitMQ();
            return Task.Run(instance);
        }
    }
}

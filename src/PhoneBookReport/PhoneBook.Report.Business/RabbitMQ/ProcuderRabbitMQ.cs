using PhoneBook.Report.Entity.Entity;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PhoneBook.Report.Business.RabbitMQ
{
    public static class ProcuderRabbitMQ
    {
        public static void LocationReportPublishMessage(LocationReport report)
        {
            IModel channel = ChannelRabbitMQ.GetLocationReportChannel();

            var dataArr = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(report));

            channel.BasicPublish(
                ConstantsRabbitMQ.ExchangeNames.ExchangeName,
                ConstantsRabbitMQ.RoutingKeys.LocationReport, null, dataArr);
        }

    }
}

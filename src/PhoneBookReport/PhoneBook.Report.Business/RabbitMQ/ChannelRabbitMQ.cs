using RabbitMQ.Client;

namespace PhoneBook.Report.Business.RabbitMQ
{
    public static class ChannelRabbitMQ
    {
        private static IModel _channel;
        private static IModel Channel => _channel ??= CreateOrGetChannel();

        private static IModel CreateOrGetChannel()
        {
            return ConnectionRabbitMQ.GetConnection().CreateModel();
        }

        public static IModel GetLocationReportChannel()
        {
            Channel.QueueDeclare(ConstantsRabbitMQ.QueueNames.LocationReport, exclusive: false);
            Channel.ExchangeDeclare(ConstantsRabbitMQ.ExchangeNames.ExchangeName, ConstantsRabbitMQ.ExchangeTypes.ExchangeType);
            Channel.QueueBind(
                ConstantsRabbitMQ.QueueNames.LocationReport,
                ConstantsRabbitMQ.ExchangeNames.ExchangeName,
                ConstantsRabbitMQ.RoutingKeys.LocationReport);
            return Channel;
        }

    }
}

namespace PhoneBook.Report.Business.RabbitMQ
{
    public static class ConstantsRabbitMQ
    {
        public static class QueueNames
        {
            public static string LocationReport => "location_report_queue";
        }

        public static class ExchangeNames
        {
            public static string ExchangeName => "report_direct";
        }
        public static class ExchangeTypes
        {
            public static string ExchangeType => "direct";
        }
        public static class RoutingKeys
        {
            public static string LocationReport => "location_report";
        }

    }
}

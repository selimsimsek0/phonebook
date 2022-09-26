using RabbitMQ.Client;
using System;

namespace PhoneBook.Report.Business.RabbitMQ
{
    public static class ConnectionRabbitMQ
    {
        private static string connectionString = "amqp://guest:guest@localhost:5672";
        private static IConnection connection;

        private static IConnection CreateConnection()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                Uri = new Uri(connectionString, UriKind.RelativeOrAbsolute)
            };

            return factory.CreateConnection();
        }

        public static IConnection GetConnection()
        {
            if (connection == null || connection.IsOpen == false)
            {
                connection = CreateConnection();
            }

            return connection;
        }
    }
}

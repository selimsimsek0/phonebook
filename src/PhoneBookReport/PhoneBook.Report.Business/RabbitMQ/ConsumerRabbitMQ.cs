using PhoneBook.Report.Business.DependenctResolvers.Ninject;
using PhoneBook.Report.Creator.CreatorManager.Abstract;
using PhoneBook.Report.Entity.Entity;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace PhoneBook.Report.Business.RabbitMQ
{
    public class ConsumerRabbitMQ
    {
        ILocationReportCreatorManager _locationReportCreator;
        public ConsumerRabbitMQ()
        {
            _locationReportCreator = ReportCreatorInstanceFactory.GetInstance<ILocationReportCreatorManager>();
            SetConsumerEvents();

        }

        private void SetConsumerEvents()
        {
            LocationReportConsumerEvent();
        }

        private void LocationReportConsumerEvent()
        {
            IModel channel = ChannelRabbitMQ.GetLocationReportChannel();

            EventingBasicConsumer consumerEvent = new EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, e) =>
            {
                var byteArr = e.Body.ToArray();
                var bodyStr = Encoding.UTF8.GetString(byteArr);

                LocationReport locationReport = JsonSerializer.Deserialize<LocationReport>(bodyStr);

                _locationReportCreator.CreateReportAsync(locationReport).GetAwaiter().GetResult();


            };

            channel.BasicConsume(ConstantsRabbitMQ.QueueNames.LocationReport, true, consumerEvent);
        }
    }
}

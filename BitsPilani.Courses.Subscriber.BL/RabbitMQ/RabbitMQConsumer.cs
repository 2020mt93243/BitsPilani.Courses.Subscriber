using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BitsPilani.Courses.Subscriber.BL.Commands;
using BitsPilani.Courses.Subscriber.BL.DTO;
using BitsPilani.Courses.Subscriber.Common.Entities;
using BitsPilani.RabbitMQMessageBroker;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BitsPilani.Courses.Subscriber.BL.RabbitMQ
{
    public class RabbitMQConsumer
    {
        private readonly IRabbitMQConnectionProvider connection;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public RabbitMQConsumer(IRabbitMQConnectionProvider connection, IMediator mediator, IMapper mapper)
        {
            this.connection = connection;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public void Consume()
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: RabbitMQMessageBroker.Constants.RabbitMQCheckoutQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: RabbitMQMessageBroker.Constants.RabbitMQCheckoutQueue, autoAck: true, consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == RabbitMQMessageBroker.Constants.RabbitMQCheckoutQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var basketCheckoutEvent = JsonConvert.DeserializeObject<List<CheckoutEvent>>(message);
                // var command = mapper.Map(basketCheckoutEvent, new List<CourseSubscriberEntity>());
                var lstCourseSubscriber = new List<CourseSubscriberEntity>();
                foreach (var msg in basketCheckoutEvent)
                {
                    var course = new CourseSubscriberEntity
                    {

                        FirstName = msg.FirstName,
                        LastName = msg.LastName,
                        EmailAddress = msg.EmailAddress,
                        PhoneNumber = msg.PhoneNumber,
                        Address = msg.Address,
                        Subjects = msg.Subjects,
                        TotalPrice = msg.TotalPrice

                    };
                    lstCourseSubscriber.Add(course);
                    var result = await mediator.Send(new AddCourseSubscriberCommand() { Courses = lstCourseSubscriber });
                }

            }
        }

        public void Disconnect()
        {
            connection.Dispose();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BitsPilani.RabbitMQMessageBroker;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using BitsPilani.Courses.Subscriber.BL.RabbitMQ;
using MediatR;

namespace BitsPilani.Courses.Subscriber.BL
{
    public static class DIBL
    {
        public static IServiceCollection AddBL(this IServiceCollection services, IConfiguration configuration)
        {
           // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IRabbitMQConnectionProvider>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBus:HostName"]
                };

                if (!string.IsNullOrEmpty(configuration["EventBus:UserName"]))
                {
                    factory.UserName = configuration["EventBus:UserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBus:Password"]))
                {
                    factory.Password = configuration["EventBus:Password"];
                }

                return new RabbitMQConnectionProvider(factory);
            });

            services.AddSingleton<RabbitMQConsumer>();
            return services;
        }
    }
}

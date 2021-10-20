using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace BitsPilani.Courses.Subscriber.Common
{
    public static class DICommon
     {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

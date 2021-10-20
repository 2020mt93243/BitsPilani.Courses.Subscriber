using BitsPilani.Courses.Subscriber.Common.Interfaces;
using BitsPilani.Courses.Subscriber.Common.UnitOfWork;
using BitsPilani.Courses.Subscriber.DB.Constant;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BitsPilani.Courses.Subscriber.DB
{
    public static class DIDB
    {
        public static IServiceCollection AddDB(this IServiceCollection services)
        {
            services.AddSingleton<IConfigConstants, ConfigConstants>();
            services.AddSingleton<IDbConnection>(conn => new SqlConnection(conn.GetService<IConfigConstants>().CourseSubscriberConnection));
            services.AddTransient<IUnitOfWork>(uof => new UnitOfWork.UnitOfWork(uof.GetService<IDbConnection>()));
            return services;
        }
    }
}

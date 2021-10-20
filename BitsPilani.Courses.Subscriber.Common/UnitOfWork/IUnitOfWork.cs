using BitsPilani.Courses.Subscriber.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.Courses.Subscriber.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICourseSubscriberRepository UserCourse { get; }
        void StartTransaction();
        void Commit();
    }
}

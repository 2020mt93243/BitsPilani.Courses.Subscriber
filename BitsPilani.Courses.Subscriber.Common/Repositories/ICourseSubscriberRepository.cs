using BitsPilani.Courses.Subscriber.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitsPilani.Courses.Subscriber.Common.Repositories
{
    public interface ICourseSubscriberRepository
    {
        Task<int> AddCourseSubscriber(CourseSubscriberEntity course);
        Task<bool> DeleteCourseSubscriber(int courseId);
        Task<IEnumerable<CourseSubscriberEntity>> GetAllCourseSubscriber();
    }
}

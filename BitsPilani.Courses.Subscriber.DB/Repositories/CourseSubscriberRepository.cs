using BitsPilani.Courses.Subscriber.Common.Entities;
using BitsPilani.Courses.Subscriber.Common.Repositories;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BitsPilani.Courses.Subscriber.DB.Repositories
{
    public class CourseSubscriberRepository : Repository, ICourseSubscriberRepository
    {
        public CourseSubscriberRepository(IDbConnection dbConnection, IDbTransaction dbtransaction)
          : base(dbConnection, dbtransaction)
        {
        }
        public Task<int> AddCourseSubscriber(CourseSubscriberEntity course)
        {
            course.DateAdded = DateTime.Now;
            course.DateUpdated = null;
            return DbConnection.InsertAsync(course, DbTransaction);
        }

        public Task<bool> DeleteCourseSubscriber(int courseId)
        {
            return DbConnection.DeleteAsync(new CourseSubscriberEntity { StudentCourseID = courseId }, DbTransaction);
        }

        public Task<IEnumerable<CourseSubscriberEntity>> GetAllCourseSubscriber()
        {
            try
            {
                return DbConnection.GetAllAsync<CourseSubscriberEntity>();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

    }
}

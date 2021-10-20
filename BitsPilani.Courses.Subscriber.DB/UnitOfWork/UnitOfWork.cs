using BitsPilani.Courses.Subscriber.Common.Repositories;
using BitsPilani.Courses.Subscriber.Common.UnitOfWork;
using BitsPilani.Courses.Subscriber.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BitsPilani.Courses.Subscriber.DB.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection dbConnection;
        private IDbTransaction transaction;
        public UnitOfWork(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.ManageConnection();
        }
        public ICourseSubscriberRepository UserCourse => new CourseSubscriberRepository(this.dbConnection, this.transaction);

        public void StartTransaction()
        {

            if (this.transaction == null)
            {
                this.transaction = this.dbConnection.BeginTransaction();
            }
        }
        public void Commit()
        {
            try
            {
                this.transaction.Commit();
            }
            catch
            {
                this.transaction.Rollback();
            }
        }

        private void ManageConnection()
        {
            if (this.dbConnection.State == ConnectionState.Closed)
            {
                this.dbConnection.Open();
            }
        }
    }
}

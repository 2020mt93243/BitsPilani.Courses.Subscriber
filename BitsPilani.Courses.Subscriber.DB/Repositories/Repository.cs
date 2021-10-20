using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BitsPilani.Courses.Subscriber.DB.Repositories
{
    public class Repository
    {
        protected IDbConnection DbConnection { get; }
        protected IDbTransaction DbTransaction { get; }
        public Repository(IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
            DbTransaction = dbTransaction;
            DbConnection = dbConnection;
        }
    }
}

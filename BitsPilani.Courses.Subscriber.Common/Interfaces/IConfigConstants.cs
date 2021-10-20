using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.Courses.Subscriber.Common.Interfaces
{
    public interface IConfigConstants
    {
        string CourseSubscriberConnection { get; }
        string TestFullStackConnection { get; }
        int LongRunningProcessMilliseconds { get; }
        string MSG_COURSE_COURSENAME { get; }
        string MSG_COURSE_NULLCREDITHOUR { get; }
        string MSG_COURSE_COURSEID { get; }

        string MSG_SC_NULLStdCourseID { get; }
    }
}

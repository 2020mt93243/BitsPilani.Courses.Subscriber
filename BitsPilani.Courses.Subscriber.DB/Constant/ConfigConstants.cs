using System;
using System.Collections.Generic;
using System.Text;
using BitsPilani.Courses.Subscriber.Common.Interfaces;
using Microsoft.Extensions.Configuration;
namespace BitsPilani.Courses.Subscriber.DB.Constant
{
    public class ConfigConstants : IConfigConstants
    {
        public IConfiguration Configuration { get; }
        public ConfigConstants(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string CourseSubscriberConnection => this.Configuration.GetConnectionString("CourseSubscriberConnection");

        public string TestFullStackConnection => this.Configuration.GetConnectionString("TestFullStackConnection");
        public int LongRunningProcessMilliseconds => int.Parse(this.Configuration["AppSettings:LongRunningProcessMilliseconds"]);

        public string MSG_COURSE_COURSENAME => this.Configuration["AppSettings:MSG_COURSE_COURSENAME"];

        public string MSG_COURSE_NULLCREDITHOUR => this.Configuration["AppSettings:MSG_COURSE_NULLCREDITHOUR"];

        public string MSG_COURSE_COURSEID => this.Configuration["AppSettings:MSG_COURSE_COURSEID"];

        public string MSG_SC_NULLStdCourseID => this.Configuration["AppSettings:MSG_SC_NULLStdCourseID"];
    }
}

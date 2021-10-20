using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitsPilani.Courses.Subscriber.BL.Commands;
using BitsPilani.Courses.Subscriber.BL.DTO;
using BitsPilani.Courses.Subscriber.BL.Queries;
using BitsPilani.Courses.Subscriber.BL.VM;
using BitsPilani.Courses.Subscriber.Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BitsPilani.Courses.Subscriber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubscriberController: BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CourseSubscriberVM>> Get()
        {
            return await this.Mediator.Send(new GetAllCourseSubscriberQuery());
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(List<CourseSubscriberEntity> courses)
        {
            return await this.Mediator.Send(new AddCourseSubscriberCommand() { Courses = courses });
        }

    }
}

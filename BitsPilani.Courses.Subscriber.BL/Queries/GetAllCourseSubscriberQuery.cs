using AutoMapper;
using BitsPilani.Courses.Subscriber.BL.DTO;
using BitsPilani.Courses.Subscriber.BL.VM;
using BitsPilani.Courses.Subscriber.Common.BaseClass;
using BitsPilani.Courses.Subscriber.Common.Interfaces;
using BitsPilani.Courses.Subscriber.Common.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BitsPilani.Courses.Subscriber.BL.Queries
{
    public class GetAllCourseSubscriberQuery : IRequest<CourseSubscriberVM>
    {
        public class GetAllCourseSubscriberHandler : AppBaseClass, IRequestHandler<GetAllCourseSubscriberQuery, CourseSubscriberVM>
        {
            public GetAllCourseSubscriberHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<CourseSubscriberVM> Handle(GetAllCourseSubscriberQuery request, CancellationToken cancellationToken)
            {
                var res = Mapper.Map(UnitOfWork.UserCourse.GetAllCourseSubscriber().Result, new List<CourseSubscriberDTO>());
                _ = new CourseSubscriberVM() { CourseSubscriberList = res };
                return await Task.FromResult(new CourseSubscriberVM() { CourseSubscriberList = res });
            }
        }
    }
}

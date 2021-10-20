using AutoMapper;
using BitsPilani.Courses.Subscriber.BL.DTO;
using BitsPilani.Courses.Subscriber.Common.BaseClass;
using BitsPilani.Courses.Subscriber.Common.Entities;
using BitsPilani.Courses.Subscriber.Common.Interfaces;
using BitsPilani.Courses.Subscriber.Common.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BitsPilani.Courses.Subscriber.BL.Commands
{
    public class AddCourseSubscriberCommand: IRequest<int>
    {
        public List<CourseSubscriberEntity> Courses { get; set; }
        public class AddCourseSubscriberHandler : AppBaseClass, IRequestHandler<AddCourseSubscriberCommand, int>
        {
            public AddCourseSubscriberHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<int> Handle(AddCourseSubscriberCommand request, CancellationToken cancellationToken)
            {
                var result = 0;

                this.UnitOfWork.StartTransaction();
                foreach (var course in request.Courses)
               {
                    var courseSubscriber = new CourseSubscriberEntity
                    {
                        FirstName = course.FirstName,
                        LastName = course.LastName,
                        TotalPrice = course.TotalPrice,
                        EmailAddress = course.EmailAddress,
                        Subjects = course.Subjects,
                        PhoneNumber = course.PhoneNumber,
                        Address = course.Address,
                        DateAdded = DateTime.Now,
                        SessionStartDate = DateTime.Now,
                        SessionEndDate = DateTime.Now.AddMonths(4),
                    };
                    result = UnitOfWork.UserCourse.AddCourseSubscriber(courseSubscriber).Result;
                }
                this.UnitOfWork.Commit();
                return await Task.Run(() => result, cancellationToken);
            }
        }

    }
}

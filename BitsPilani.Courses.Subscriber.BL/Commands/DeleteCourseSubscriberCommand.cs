using AutoMapper;
using BitsPilani.Courses.Subscriber.Common.BaseClass;
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
    public class DeleteCourseSubscriberCommand : IRequest<bool>
    {
        public int StudentCourseID { get; set; }
        public class DeleteCourseSubscriberHandler : AppBaseClass, IRequestHandler<DeleteCourseSubscriberCommand, bool>
        {
            public DeleteCourseSubscriberHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(DeleteCourseSubscriberCommand request, CancellationToken cancellationToken)
            {
                this.UnitOfWork.StartTransaction();
                var res = UnitOfWork.UserCourse.DeleteCourseSubscriber(request.StudentCourseID).Result;
                this.UnitOfWork.Commit();
                return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}

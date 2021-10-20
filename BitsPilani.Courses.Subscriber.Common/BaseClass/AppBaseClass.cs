using AutoMapper;
using BitsPilani.Courses.Subscriber.Common.Interfaces;
using BitsPilani.Courses.Subscriber.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.Courses.Subscriber.Common.BaseClass
{
    public class AppBaseClass
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IConfigConstants ConfigConstants { get; set; }
        public IMapper Mapper { get; set; }

        public AppBaseClass(IConfigConstants configConstants, IUnitOfWork unitOfWork, IMapper mapper)
        {
            ConfigConstants = configConstants;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}

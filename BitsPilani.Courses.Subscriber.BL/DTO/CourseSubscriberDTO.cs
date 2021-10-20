using BitsPilani.Courses.Subscriber.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BitsPilani.RabbitMQMessageBroker;
using AutoMapper;
using BitsPilani.Courses.Subscriber.Common.Mappings;

namespace BitsPilani.Courses.Subscriber.BL.DTO
{
    public class CourseSubscriberDTO : IMapFrom<CourseSubscriberEntity>, IMapFrom<CheckoutEvent>
    {
        public int StudentCourseID { get; set; }
        public string Subjects { get; set; }
        public decimal TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public DateTime SessionStartDate { get; set; }

        public DateTime SessionEndDate { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateUpdated { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseSubscriberDTO, CourseSubscriberEntity>();
            profile.CreateMap<CourseSubscriberEntity, CourseSubscriberDTO>();

            profile.CreateMap<CourseSubscriberDTO, CheckoutEvent>();
            profile.CreateMap<CheckoutEvent, CourseSubscriberDTO>();
        }
    }
}

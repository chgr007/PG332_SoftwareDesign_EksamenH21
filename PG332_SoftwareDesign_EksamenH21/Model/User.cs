using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public Specialization? Specialization { get; set; }
        public long? SpecializationId { get; set; }
        public long? UserCoursePlanId { get; set; }
        public StudentCourseOverview? StudentCourseOverview { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not User) return false;
            User user = (User) obj;
            return (user.Email == Email && user.Id == Id && user.FirstName == FirstName && user.LastName == LastName);
        }

    }
}
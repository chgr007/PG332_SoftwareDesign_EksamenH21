using PG332_SoftwareDesign_EksamenH21.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Semester : IProgressable
    {
        public long Id { get; set; }
        public List<Course> Courses { get; set; } = new();
        [NotMapped] public bool Published { get; set; } = false;

        private List<Course> OptionalCourses { get; set; } = new();
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class Specialization : IPublishable
    {
        public long Id { get; set; }
        public CoursesInSpecialization SpecializationCourses { get; set; }
        [NotMapped]
        public bool Published { get; }

        public Specialization()
        {
            Published = true;
        }
    }
}

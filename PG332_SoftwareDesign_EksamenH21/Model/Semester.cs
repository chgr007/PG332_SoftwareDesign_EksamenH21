using PG332_SoftwareDesign_EksamenH21.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Semester : IProgressable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set;  }
        public SemesterEnum SemesterEnum { get; set; }
        public List<Course> Courses { get; set; }
        public bool Finished { get; set; } = false;
        [NotMapped] public bool Published { get; set; } = true;

        [NotMapped]
        public string Title => SemesterEnum.ToString();
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public class Specialization : IProgressable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public List<CoursesInSpecialization>? CoursesInSpecializations { get; set; }
        [NotMapped]
        public bool Published { get; set; } = false;

        protected bool Equals(Specialization other)
        {
            return Id == other.Id && Name == other.Name && Code == other.Code;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Specialization) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Code);
        }
    }
}

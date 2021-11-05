using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Course : IPublishable
    {
        [NotMapped]
        public SemesterEnum Semester { get; set; }
        public long Id { get; set; }
        public string CourseCode { get; set; }
        public List<Lecture> Lectures { get; set; } = new();
        public DateTime ExamDate { get; set; }
        public ExamType ExamType { get; set; }
        public float CoursePoints { get; set; }
        [NotMapped]
        public bool Published { get; set; }

    }

    public enum ExamType
    {
        WRITTEN,
        HOME_24_HR,
        HOME_48_HR,
        PROJECT,
        ORAL,
    }
}
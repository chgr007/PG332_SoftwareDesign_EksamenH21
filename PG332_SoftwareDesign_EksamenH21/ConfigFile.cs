using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    class ConfigFile
    {

        public void AddDummyData()
        {
                UserDao db = new UserDao();
                User user = new();
                Address address = new();
                address.City = "Oslo";
                address.Country = "Norway";
                
                Specialization specialization = new();
                user.Specialization = specialization;

                user.Address = address;
                user.FirstName = "Roman";
                user.LastName = "Morso";
                user.Specialization = specialization;
                user.Email = "roman@morso.no";

                Course course_a = new();
                Course course_b = new();
                Course course_c = new();
                course_a.Semester = SemesterEnum.FIRST;

                CoursesInSpecialization coursesInSpecialization = new();
                coursesInSpecialization.Course = course_a;
                
                Lecture lecture = new();

                StudentCourseOverview studentCourseOverview = new();
                studentCourseOverview.Course = course_a;
                user.StudentCourseOverview = studentCourseOverview;

                Task task_a = new();
                Task task_b = new();
                Task task_c = new();
                lecture.TaskSet.Tasks.Add(task_a);
                lecture.TaskSet.Tasks.Add(task_b);
                lecture.TaskSet.Tasks.Add(task_c);


                db.Save(user);
            
        }
    }
}

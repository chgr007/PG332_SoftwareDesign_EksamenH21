using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionHandlerComposite : IProgressionHandler<IProgressable>
    {
        public IProgressable Progressable { get; }
        public List<IProgressionHandler<IProgressable>> Children { get; set; } 

        public ProgressionHandlerComposite(IProgressable progressable)
        {
            Progressable = progressable;
            Children = new();
        }

        public double GetProgression()
        {
            /*if (Progressable is Specialization)
            {
                //Specialization specialization = (Specialization)Progressable;
                //foreach (var semester in specialization.S)
            }
            else */if (Progressable is Semester)
            {
                Semester semester = (Semester)Progressable;
                foreach (var course in semester.Courses)
                {
                     Children.Add(new ProgressionHandlerComposite(course));
                }
            }
            else if (Progressable is Course)
            {
                Course course = (Course)Progressable;
                foreach (var lecture in course.Lectures)
                {
                    Children.Add(new ProgressionHandlerComposite(lecture));
                }
            }
            else if (Progressable is Lecture)
            {
                Lecture lecture = (Lecture)Progressable;
                Children.Add(new ProgressionHandlerLeaf(lecture));
                Children.Add(new ProgressionHandlerComposite(lecture.TaskSet));
            }
            else if (Progressable is TaskSet)
            {
                TaskSet taskSet = (TaskSet)Progressable;
                foreach (var task in taskSet.Tasks)
                {
                     Children.Add(new ProgressionHandlerLeaf(task));
                }
            }

            double returnValue = 0.00;

            if (Progressable.Published)
            {
                foreach (var Child in Children)
                {
                    if (Child.Progressable.Published)
                    {
                        returnValue += Child.GetProgression();
                    }
                }
            }
            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }
    }
}

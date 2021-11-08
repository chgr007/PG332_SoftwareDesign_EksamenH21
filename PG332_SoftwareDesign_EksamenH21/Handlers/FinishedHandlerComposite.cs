using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class FinishedHandlerComposite : IFinishedHandler<IProgressable>
    {
        public IProgressable Publishable { get; }
        public List<IFinishedHandler<IProgressable>> Children { get; set; } 

        public FinishedHandlerComposite(IProgressable publishable)
        {
            Publishable = publishable;
            Children = new();
        }

        public double GetFinishedPercent()
        {
            /*if (Progressable is Specialization)
            {
                Specialization s = Progressable as Specialization;
                foreach (var semester in s.Semesters)
            }
            else */if (Publishable is Semester)
            {
                Semester s = Publishable as Semester;
                foreach (var c in s.Courses)
                {
                     Children.Add(new FinishedHandlerComposite(c));
                }
            }
            else if (Publishable is Course)
            {
                Course c = Publishable as Course;
                foreach (var l in c.Lectures)
                {
                    Children.Add(new FinishedHandlerComposite(l));
                }
            }
            else if (Publishable is Lecture)
            {
                Lecture l = Publishable as Lecture;
                Children.Add(new FinishedHandlerLeaf(l));
                Children.Add(new FinishedHandlerComposite(l.TaskSet));
            }
            else if (Publishable is TaskSet)
            {
                TaskSet ts = Publishable as TaskSet;
                foreach (var t in ts.Tasks)
                {
                     Children.Add(new FinishedHandlerLeaf(t));
                }
            }

            double returnValue = 0.00;

            
            foreach (var c in Children)
            {
                returnValue += c.GetFinishedPercent();
            }
            

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }
    }
}

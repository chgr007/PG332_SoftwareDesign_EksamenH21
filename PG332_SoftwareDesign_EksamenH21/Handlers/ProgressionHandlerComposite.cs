using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionHandlerComposite : IProgressionHandler<IProgressable>
    {
        public IProgressable Progressable { get; }

        public List<IProgressionHandler<IProgressable>> Children = new();

        public ProgressionHandlerComposite(IProgressable progressable)
        {
            Progressable = progressable;
        }

        public double GetPublishedPercent()
        {
            double returnValue = 0.00;

            if (!Progressable.Published)
            {
                return returnValue;
            }

            foreach (var c in Children)
            {
                returnValue += c.GetPublishedPercent();
            }

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }

        public double GetFinishedPercent()
        {
            double returnValue = 0.00;

            if (!Progressable.Published)
            {
                return returnValue;
            }

            foreach (var c in Children)
            {
                returnValue += c.GetFinishedPercent();
            }

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }

        public ProgressionWrapper GetProgression()
        {
            if (Progressable is Semester)
            {
                Semester s = Progressable as Semester;
                foreach (var c in s.Courses)
                {
                    Children.Add(new ProgressionHandlerComposite(c));
                }
            }
            else if (Progressable is Course)
            {
                Course c = Progressable as Course;
                foreach (var l in c.Lectures)
                {
                    Children.Add(new ProgressionHandlerComposite(l));
                }
            }
            else if (Progressable is Lecture)
            {
                Lecture l = Progressable as Lecture;
                Children.Add(new ProgressionHandlerLeaf(l));
                Children.Add(new ProgressionHandlerComposite(l.TaskSet));
            }
            else if (Progressable is TaskSet)
            {
                TaskSet ts = Progressable as TaskSet;
                foreach (var t in ts.Tasks)
                {
                    Children.Add(new ProgressionHandlerLeaf(t));
                }
            }

            ProgressionWrapper progression = new(0.00, 0.00);

            if (!Progressable.Published)
            {
                return progression;
            }

            foreach (var c in Children)
            {
                progression = progression + c.GetProgression();
            }
            
            return progression / Children.Count;
        }
    }
}

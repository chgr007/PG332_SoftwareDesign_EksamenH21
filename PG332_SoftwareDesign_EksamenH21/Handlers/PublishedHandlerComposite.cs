using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class PublishedHandlerComposite: IPublishedHandler<IProgressable>
    {
        public IProgressable Progressable { get; }

        public List<IPublishedHandler<IProgressable>> Children;

        public PublishedHandlerComposite(IProgressable publishable)
        {
            Progressable = publishable;
            Children = new();
        }

        public double GetPublishedPercent()
        {
            if (!Progressable.Published)
            {
                return 0.00;
            }

            if (Progressable is Semester)
            {
                Semester s = Progressable as Semester;
                foreach (var c in s.Courses)
                {
                    Children.Add(new PublishedHandlerComposite(c));
                }
            }
            else if (Progressable is Course)
            {
                Course c = Progressable as Course;
                foreach (var l in c.Lectures)
                {
                    Children.Add(new PublishedHandlerComposite(l));
                }
            }
            else if (Progressable is Lecture)
            {
                Lecture l = Progressable as Lecture;
                Children.Add(new PublishedHandlerLeaf(l));
                Children.Add(new PublishedHandlerComposite(l.TaskSet));
            }
            else if (Progressable is TaskSet)
            {
                TaskSet ts = Progressable as TaskSet;
                foreach (var t in ts.Tasks)
                {
                    Children.Add(new PublishedHandlerLeaf(t));
                }
            }


            double returnValue = 0.00;

            foreach (var c in Children)
            {
                if (c.Progressable.Published)
                {
                    returnValue += c.GetPublishedPercent();
                }
            }

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }
    }
}

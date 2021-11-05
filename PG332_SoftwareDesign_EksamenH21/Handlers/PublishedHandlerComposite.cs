using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class PublishedHandlerComposite: IPublishedHandler<IPublishable>
    {
        public IPublishable Publishable { get; }

        public List<IPublishedHandler<IPublishable>> Children;

        public PublishedHandlerComposite(IPublishable publishable)
        {
            Publishable = publishable;
            Children = new();
        }

        public double GetPublishedPercent()
        {
            if (Publishable is Semester)
            {
                Semester s = Publishable as Semester;
                foreach (var c in s.Courses)
                {
                    Children.Add(new PublishedHandlerComposite(c));
                }
            }
            else if (Publishable is Course)
            {
                Course c = Publishable as Course;
                foreach (var l in c.Lectures)
                {
                    Children.Add(new PublishedHandlerComposite(l));
                }
            }
            else if (Publishable is Lecture)
            {
                Lecture l = Publishable as Lecture;
                Children.Add(new PublishedHandlerLeaf(l));
                Children.Add(new PublishedHandlerComposite(l.TaskSet));
            }
            else if (Publishable is TaskSet)
            {
                TaskSet ts = Publishable as TaskSet;
                foreach (var t in ts.Tasks)
                {
                    Children.Add(new PublishedHandlerLeaf(t));
                }
            }


            double returnValue = 0.00;

            foreach (var c in Children)
            {
                if (c.Publishable.Published)
                {
                    returnValue += c.GetPublishedPercent();
                }
            }

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }
    }
}

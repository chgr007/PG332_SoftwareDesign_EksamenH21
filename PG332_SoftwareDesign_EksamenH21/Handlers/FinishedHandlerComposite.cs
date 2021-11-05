﻿using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class FinishedHandlerComposite : IFinishedHandler<IPublishable>
    {
        public IPublishable Publishable { get; }
        public List<IFinishedHandler<IPublishable>> Children { get; set; } 

        public FinishedHandlerComposite(IPublishable publishable)
        {
            Publishable = publishable;
            Children = new();
        }

        public double GetFinishedPercentage()
        {
            /*if (Publishable is Specialization)
            {
                //Specialization specialization = (Specialization)Publishable;
                //foreach (var semester in specialization.S)
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
                if (c.Publishable.Published)
                {
                    returnValue += c.GetFinishedPercentage();
                }
            }
            

            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }
    }
}

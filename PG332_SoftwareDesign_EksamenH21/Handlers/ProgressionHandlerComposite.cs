using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    class ProgressionHandlerComposite : IProgressionHandler<IProgressable>
    {
        public IProgressable Progressable { get; }
        public List<IProgressionHandler<IProgressable>> Children { get; set; }

        public ProgressionHandlerComposite(IProgressable progressable)
        {
            Progressable = progressable;
        }

        public double GetProgression()
        {
            double returnValue = 0.00;

            if (Progressable.Published)
            {
                foreach (var Child in Children)
                {
                    if (Child.Progressable.Published)
                    {
                        returnValue = returnValue + Child.GetProgression();
                    }
                }
            }
            return Math.Round(returnValue / Children.Count, 2, MidpointRounding.ToZero);
        }
    }
}

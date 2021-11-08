using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionHandlerLeaf : IProgressionHandler<IProgressable>
    {
        public IProgressable Progressable { get; }

        public ProgressionHandlerLeaf(IProgressable progressable)
        {
            Progressable = progressable;
        }

        public double GetPublishedPercent()
        {
            if (Progressable.Published)
            {
                return 1.00;
            }

            return 0.00;
        }

        public double GetFinishedPercent()
        {
            IFinishable f = Progressable as IFinishable;

            if (f.Published && f.Finished)
            {
                return 1.00;
            }

            return 0.00;
        }

        public ProgressionWrapper GetProgression()
        {
            return new(GetPublishedPercent(), GetFinishedPercent());
        }
    }
}

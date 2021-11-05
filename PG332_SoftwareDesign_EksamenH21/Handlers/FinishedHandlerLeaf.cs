using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class FinishedHandlerLeaf : IFinishedHandler<IPublishable>
    {
        public IPublishable Publishable { get; }

        public FinishedHandlerLeaf(IFinishable progressable)
        {
            Publishable = progressable;
        }

        public double GetFinishedPercentage()
        {
            IFinishable f = Publishable as IFinishable;
            if (f.Finished)
            {
                return 1.00;
            }
            
            return 0.00;

        }
    }
}

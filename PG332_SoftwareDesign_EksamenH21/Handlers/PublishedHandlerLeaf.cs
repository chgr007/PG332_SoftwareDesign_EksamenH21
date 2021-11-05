using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class PublishedHandlerLeaf : IPublishedHandler<IPublishable>
    {
        public IPublishable Publishable { get; }

        public PublishedHandlerLeaf(IFinishable publishable)
        {
            Publishable = publishable;
        }

        public double GetPublishedPercent()
        {
            IFinishable f = Publishable as IFinishable;
            if (f.Published)
            {
                return 1.00;
            }
            
            return 0.00;
            
        }
    }
}

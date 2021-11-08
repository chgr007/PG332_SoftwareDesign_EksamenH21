using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class PublishedHandlerLeaf : IPublishedHandler<IProgressable>
    {
        public IProgressable Progressable { get; }

        public PublishedHandlerLeaf(IFinishable publishable)
        {
            Progressable = publishable;
        }

        public double GetPublishedPercent()
        {
            IFinishable f = Progressable as IFinishable;
            if (f.Published)
            {
                return 1.00;
            }
            
            return 0.00;
            
        }
    }
}

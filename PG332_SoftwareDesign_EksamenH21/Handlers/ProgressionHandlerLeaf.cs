using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    class ProgressionHandlerLeaf : IProgressionHandler<IFinishable>
    {
        public IFinishable Progressable { get; }

        public ProgressionHandlerLeaf(IFinishable progressable)
        {
            Progressable = progressable;
        }

        public double GetProgression()
        {
            if (Progressable.Published && Progressable.Finished)
            {
                return 1.00;
            }
            else
            {
                return 0.00;
            }
        }
    }
}

using PG332_SoftwareDesign_EksamenH21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ProgressionHandlerLeaf : IProgressionHandler<IProgressable>
    {
        public IProgressable Progressable { get; }

        public ProgressionHandlerLeaf(IFinishable progressable)
        {
            Progressable = progressable;
        }

        public double GetProgression()
        {
            IFinishable finishable = (IFinishable)Progressable;
            if (finishable.Published && finishable.Finished)
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

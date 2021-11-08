using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public interface IProgressionHandler<T> where T : IProgressable
    {
        public T Progressable { get; }

        public double GetPublishedPercent();

        public double GetFinishedPercent();

        public ProgressionWrapper GetProgression();
    }
}

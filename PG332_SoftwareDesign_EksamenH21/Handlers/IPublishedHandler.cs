using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public interface IPublishedHandler<T> where T: IPublishable
    {
        public IPublishable Publishable { get; }

        public double GetPublishedPercent();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Model
{
    public interface IFinishable : IProgressable
    {
        public bool Finished { get; set; }
    }
}

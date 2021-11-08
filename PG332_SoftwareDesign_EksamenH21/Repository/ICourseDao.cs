using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    interface ICourseDao : ICrudDao<Course>
    {
        Course retrieveByCode(string code);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public interface ISpecializationDao : ICrudDao<Specialization>
    {
        Specialization RetrieveByName(string name);
        Specialization RetrieveByCode(string code);
    }
}

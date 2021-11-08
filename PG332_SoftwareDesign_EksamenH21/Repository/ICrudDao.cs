using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public interface ICrudDao<TModel>
    {
        void Update(TModel m);

        void Save(TModel m);

        TModel RetrieveById(long id);
        List<TModel> ListAll();
        void Delete(long id);
        TModel RetrieveOneByField(Func<TModel, bool> predicate);
    }
}

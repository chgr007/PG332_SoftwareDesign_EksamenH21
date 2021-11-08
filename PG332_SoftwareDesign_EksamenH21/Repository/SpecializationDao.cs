using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public class SpecializationDao : ISpecializationDao
    {
        public void Update(Specialization m)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Update(m);
            trackerContext.SaveChanges();
        }

        public void Save(Specialization m)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Add(m);
            trackerContext.SaveChanges();
        }

        public Specialization RetrieveById(long id)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Specializations.Find(id);
        }

        public List<Specialization> ListAll()
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Specializations.ToList();
        }

        public void Delete(long id)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Specializations.Remove(trackerContext.Specializations.Find(id));
            trackerContext.SaveChanges();
        }

        public Specialization RetrieveOneByField(Func<Specialization, bool> predicate)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Specializations.FirstOrDefault(predicate);
        }

        public Specialization RetrieveByName(string name)
        {
            return RetrieveOneByField(s => s.Name == name);
        }

        public Specialization RetrieveByCode(string code)
        {
            return RetrieveOneByField(s => s.Code == code);
        }
    }
}

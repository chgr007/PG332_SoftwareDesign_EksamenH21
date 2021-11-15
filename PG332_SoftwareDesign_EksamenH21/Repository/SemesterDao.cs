using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    class SemesterDao : ICrudDao<Semester>
    {
        public void Update(Semester m)
        {
            using TrackerContext trackerContext = new();

            trackerContext.Semesters.Update(m);
            trackerContext.SaveChanges();

        }

        public void Save(Semester m)
        {
            using TrackerContext trackerContext = new();

            trackerContext.Semesters.Add(m);
            trackerContext.SaveChanges();
        }

        public Semester RetrieveById(long id)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Semesters.Find(id);
        }

        public List<Semester> ListAll()
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Semesters.ToList();
        }

        public void Delete(long id)
        {
            using TrackerContext trackerContext = new();
            trackerContext.Semesters.Remove(trackerContext.Semesters.Find(id));
            trackerContext.SaveChanges();
        }

        public Semester RetrieveOneByField(Func<Semester, bool> predicate)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Semesters.FirstOrDefault(predicate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using PG332_SoftwareDesign_EksamenH21.Model;

// TODO: Finne ut best practice rundt using. Gir mening at scope kun er i metoden dersom connection lukkes automatisk utenfor scope?
namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public class UserDao : IUserDao
    {
   
        public void Update(User m)
        {
            using TrackerContext trackerContext = new TrackerContext();
            trackerContext.Update(m);
            trackerContext.SaveChanges();
        }

        public void Save(User m)
        {
            using TrackerContext trackerContext = new TrackerContext();
            trackerContext.Add(m);
            trackerContext.SaveChanges();
        }

        public User RetrieveById(long id)
        {
            using TrackerContext trackerContext = new TrackerContext();
            return trackerContext.Find<User>(id);
        }

        public List<User> ListAll()
        {
            using TrackerContext trackerContext = new TrackerContext();
            return trackerContext.Users.ToList();

        }

        public void Delete(long id)
        {
            using TrackerContext trackerContext = new TrackerContext();
            trackerContext.Users.Remove(trackerContext.Users.Find(id));
            trackerContext.SaveChanges();
        }

        public User RetrieveByEmail(string email)
        {
            return RetrieveOneByField(u => u.Email == email);
        }

        public User RetrieveByLastName(string lastName)
        {
            return RetrieveOneByField(u => u.LastName == lastName);
        }

        public User RetrieveOneByField(Func<User,bool> predicate)
        {
            using TrackerContext trackerContext = new TrackerContext();

            return trackerContext.Users.FirstOrDefault(predicate);
        }
    }
}

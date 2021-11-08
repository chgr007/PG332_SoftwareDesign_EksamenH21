using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using PG332_SoftwareDesign_EksamenH21.Model;


namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public class UserDao : IUserDao
    {
        private readonly TrackerContext _trackerContext;

        public UserDao()
        {
            _trackerContext = new TrackerContext();
        }

        public void Update(User m)
        {
            _trackerContext.Update(m);
            _trackerContext.SaveChanges();

        }

        public void Save(User m)
        {
            _trackerContext.Add(m);
            _trackerContext.SaveChanges();
        }

        public User RetrieveById(long id)
        {
            return _trackerContext.Find<User>(id);
        }

        public List<User> ListAll()
        {
            return _trackerContext.Users.ToList();
        }

        public void Delete(long id)
        {
            _trackerContext.Users.Remove(_trackerContext.Users.Find(id));
            _trackerContext.SaveChanges();
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
            return _trackerContext.Users.FirstOrDefault(predicate);
        }
    }
}

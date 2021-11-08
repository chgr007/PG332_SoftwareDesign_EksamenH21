using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using Task = PG332_SoftwareDesign_EksamenH21.Task;

namespace Test
{
    class ModelTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SaveUserAndAggregatedClassesTest()
        {


            var task_A = new Task();
            var task_B = new Task();
            var task_C = new Task();

            var lecture = new Lecture();
            lecture.TaskSet.Tasks.Add(task_A);
            var course = new Course();
            course.Lectures.Add(lecture);


            Specialization specialization = new Specialization();
            User user = new()
            {
                Specialization = specialization
            };
            
            using (var db = new TrackerContext())
            {

                db.Add(user);
                db.SaveChanges();


                User userFromServer = db.Users
                    .OrderByDescending(s => s.Id)
                    .First();
                Console.WriteLine($"user id: {user.Id}");
                Console.WriteLine($"user id from server id: {userFromServer.Id}");

                Assert.AreEqual(user, userFromServer);
            }


        }

        [Test]
        public void UpdateUserInDB()
        {
            User user = new User()
            {
                FirstName = "Test",
                LastName = "Persson",
                Email = "test@persson.no"
            };

            UserDao userDao = new UserDao();
            userDao.Save(user);

            User userFromServer = userDao.RetrieveById(user.Id);
            Assert.AreEqual(user, userFromServer);

            user.Email = "persson@test.no";
            userDao.Update(user);
            Assert.AreEqual("persson@test.no", user.Email);
        }
        [Test]
        public void AddSpecializationToDB()
        {
            ISpecializationDao specializationDao = new SpecializationDao();
            Specialization s = new()
            {
                Name = "Prog",
                Code = "PGR123"
            };

            specializationDao.Save(s);

            Specialization fromServer = specializationDao.RetrieveById(s.Id);
            Assert.AreEqual(s, fromServer);
        }

    }
}

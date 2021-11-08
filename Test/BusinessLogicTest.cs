using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace Test
{
    class BusinessLogicTest
    {
        [Test]
        public void ShouldLoginUser()
        {
            User createdUser = new() { Id = 42069, FirstName = "G", LastName = "Bergesen", 
                Email = "gMail@email.no", password = HashPassword("password123")};
            var userDao = new UserDao();
         
            if (userDao.RetrieveById(42069) != null)
                userDao.Update(createdUser);
            else
                userDao.Save(createdUser);
            IUserInterface ui = new UserInterface();
            BusinessLogic businessLogic = new BusinessLogic(ui);
            
            businessLogic.StartProgram();
            var loggedInUser = businessLogic.GetLoggedInUser();
            
            Assert.AreEqual(createdUser.Id, loggedInUser.Id);
        }   
    }
}
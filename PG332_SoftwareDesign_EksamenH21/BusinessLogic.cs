using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class BusinessLogic
    {
        private IUserInterface UI { get; } = new UserInterface();
        private User User;
        
        
        public BusinessLogic(IUserInterface ui)
        {
            UI = ui;
        }

        public void StartProgram()
        {
            LoginUser();
            ExecuteUserChoice();
        }

        private void LoginUser()
        {
            var credentials = UI.GetLoginCredentials(); // Må først få bruker til å logge inn
            string email = credentials[0], password = credentials[1];
            while (!UserValid(email, password))
            {
                credentials = UI.GetLoginCredentials(); // Så lenge bruker ikke er gyldig ber vi dem prøve igjen.
                email = credentials[0];
                password = credentials[1];
            }
        }

        private bool UserValid(string email, string password)
        {
            UserDao dao = new UserDao();
            User retrieveByEmail = dao.RetrieveByEmail(email);
            if (retrieveByEmail is null) return false;
            
            if (Verify(password, retrieveByEmail.password))
            {
                User = retrieveByEmail;
                return true;
            }

            return false;
        }

        private void ExecuteUserChoice()
        {
            UI.ShowMenuOptions();
            UserChoice userChoice = UI.GetUserChoice();

            switch (userChoice)
            {
                case UserChoice.GetSemesterProgression:
                {
                    if (User.SpecializationId != null)
                        new SpecializationDao().RetrieveById((long) User.SpecializationId);
                    break;
                }
            }
        }

        public User GetLoggedInUser()
        {
            return User;
        }
    }
    
}
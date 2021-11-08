using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21
{
    public interface IUserInterface
    {
        public void ShowMenuOptions();
        public string[] GetLoginCredentials();
        public UserChoice GetUserChoice();
    }
}
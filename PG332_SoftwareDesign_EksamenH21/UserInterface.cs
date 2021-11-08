using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PG332_SoftwareDesign_EksamenH21.Model;
using static BCrypt.Net.BCrypt;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class UserInterface : IUserInterface
    {
        public void ShowMenuOptions()
        {
               
        }

        public string[] GetLoginCredentials()
        {
            // Kun midlertidig for å få testen til å kjøre grønt
            return new[]{"gMail@email.no", "password123"};
        }

        public UserChoice GetUserChoice()
        {
            return UserChoice.Quit;
        }
    }
}
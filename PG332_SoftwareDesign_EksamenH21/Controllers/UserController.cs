﻿using System;
using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Controllers
{
    public class UserController
    {
        public User User { get; set; }
        private OptionsHandler _optionsHandler;
        private MenuPrinter<IProgressable> MenuPrinter { get; set; } = new();
        private UserAuthenticator _userAuthenticator = new();
        
        public void Start()
        {
            User = _userAuthenticator.Authenticate();
            MenuPrinter.WelcomeMessage(GetFullName());
            
            
            Menu();
        }

        private void Menu()
        {
            _optionsHandler = OptionsHandlerFactory.MakeOptionsHandler(User);

            MenuPrinter.ShowMenu(_optionsHandler);
            while (true)
            {
                _optionsHandler = _optionsHandler.ChooseOption(Console.ReadLine()) as OptionsHandler;
                Console.Clear();
                MenuPrinter.ShowMenu(_optionsHandler);
                UserDao dao = new UserDao();
                dao.Update(User);
            }
        }


        public string GetFullName()
        {
            return $"{User.FirstName} {User.LastName}";
        }
    }
}
using System;
using System.Linq;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    class Program
    {

        static void Main(string[] args)
        {
           
            AddDummyData();
            IConsoleUi ui = new ConsoleUi();
            ui.start();
        }


        private static void AddDummyData()
        {
            ConfigFile cf = new();
            cf.AddDummyData();
        }
    }
}
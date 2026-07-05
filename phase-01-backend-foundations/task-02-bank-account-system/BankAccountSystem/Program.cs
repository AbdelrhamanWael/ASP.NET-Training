
using System;
using BankAccountSystem.UI; // This line connects your Program to the UI folder

namespace BankAccountSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of your menu
            ConsoleMenu menu = new ConsoleMenu();
            
            // Call the method to display the menu and start the app
            menu.ShowMenu();
        }
    }
}
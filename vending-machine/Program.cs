using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace vending_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var user = new User(view);
            var bank = new Bank(view);
            var vendingMachine = new VendingMachine(user, bank, view);
            vendingMachine.StartMenu();
        }
    }
}
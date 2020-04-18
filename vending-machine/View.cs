using System;
using System.Collections.Generic;

namespace vending_machine
{
    public class View
    {
        public void MainMenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("WELCOME TO THE VENDING MACHINE. PLEASE CHOOSE AN OPTION");
            Console.WriteLine("KEY 1: BUY GOODS ITEM");
            Console.WriteLine("KEY 2: GO TO BANK");
            Console.WriteLine("KEY 3: SEE YOUR GOODS ITEMS");
        }

        public void PressQToGoBack()
        {
            Console.WriteLine("PRESS 'Q' TO GO BACK");
            Console.Write("> ");
        }

        public void InvalidOption()
        {
            Console.WriteLine("INVALID OPTION. TRY AGAIN!");
        }

        public void NotANumber()
        {
            Console.WriteLine("YOU MUST ENTER A NUMBER. TRY AGAIN!");
            Console.WriteLine();
        }

        public void DisplayGoodsItems(GoodsItem item)
        {
            Console.WriteLine($"KEY {item.Id}: {item.Name} - ${item.Price} STOCK: {item.ItemsRemaining}");
        }

        public void AreYouSure()
        {
            Console.WriteLine("ARE YOU SURE YOU WANT TO BUY THIS ITEM? [Y/N]");
            Console.Write("> ");
        }

        public void PaymentDeclined()
        {
            Console.WriteLine("PAYMENT DECLINED");
            Console.WriteLine();
        }

        public void GoodsItemSummary(GoodsItem item)
        {
            Console.WriteLine($"YOU HAVE CHOSEN {item.Name} FOR A COST OF ${item.Price}");
        }

        public void TransferFromAnotherAccount()
        {
            Console.WriteLine("TRANSFER MONEY FROM ANOTHER ACCOUNT? [Y/N]");
            Console.WriteLine();
        }

        public void WhatDoYouWantToBuy()
        {
            Console.WriteLine("WHAT DO YOU WANT TO BUY?");
        }

        public void BankMenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("WELCOME TO YOUR BANK. HOW CAN WE HELP YOU?");
            Console.WriteLine("KEY 1: CHECK ACCOUNT BALANCE");
            Console.WriteLine("KEY 2: TRANSFER MONEY");
        }

        public void CurrentBalance(User user, int balance)
        {
            Console.WriteLine();
            Console.WriteLine($"YOUR CURRENT BALANCE IS {user.MoneyAvailable}");
            Console.WriteLine($"YOU HAVE {balance} ON YOUR SAVINGS ACCOUNT");
        }

        public void InvalidAmount()
        {
            Console.WriteLine("INVALID AMOUNT");
            Console.WriteLine();
        }

        public void HowMuchWithdraw()
        {
            Console.WriteLine();
            Console.WriteLine("HOW MUCH DO YOU WANT TO WITHDRAW?");
        }

        public void NotBoughtAnything()
        {
            Console.WriteLine("YOU HAVE NOT BOUGHT ANYTHING!");
        }

        public void BoughtItems(Dictionary<GoodsItem, int> itemsAvailable)
        {
            Console.WriteLine("YOU HAVE BOUGHT: ");
            foreach (var item in itemsAvailable)
            {
                Console.WriteLine($"{item.Key.Name} {item.Value}");
            }
        }

        public void VendedMessage(GoodsItem item)
        {
            Console.WriteLine($"{item.VendedMessage}");
            Console.WriteLine();
        }

        public void SoldOutMessage(GoodsItem item)
        {
            Console.WriteLine($"{item.SoldOutMessage}");
        }
    }
}
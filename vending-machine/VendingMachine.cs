using System;
using System.Collections.Generic;

namespace vending_machine
{
    public class VendingMachine
    {
        private readonly Chips _chips = new Chips("CHIPS", 3, 1, 3);
        private readonly Cola _cola = new Cola("COLA", 1, 2, 10);
        private readonly Peanut _peanuts = new Peanut("PEANUTS", 7, 3, 10);
        private readonly Chocolate _chocolate = new Chocolate("CHOCOLATE", 5, 4, 4);
        private Bank Bank { get; }
        private User User { get; }
        private View View { get; }

        public VendingMachine(User user, Bank bank, View view)
        {
            User = user;
            Bank = bank;
            View = view;
        }

        public void StartMenu()
        {
            while (true)
            {
                View.MainMenuOptions();
                View.PressQToGoBack();
                var userInput = Console.ReadLine();
                if (userInput != null && userInput.ToLower() == "q")
                    return;
                
                switch (userInput)
                {
                    case "1":
                        ChooseItem();
                        break;
                    case "2":
                        Bank.BankMenu(User);
                        break;
                    case "3":
                        User.ListUserInventory(User);
                        break;
                    default:
                        while (true)
                        {
                            View.InvalidOption();
                            View.PressQToGoBack();
                            userInput = Console.ReadLine();

                            if (userInput == null || userInput.ToLower() != "q") continue;
                            StartMenu();
                            return;
                        }
                   
                }
            }
        }

        private void ChooseItem()
        {
            View.WhatDoYouWantToBuy();
            while (true)
            {
                View.DisplayGoodsItems(_chips);
                View.DisplayGoodsItems(_cola);
                View.DisplayGoodsItems(_peanuts);
                View.DisplayGoodsItems(_chocolate);
                View.PressQToGoBack();

                var userInput = Console.ReadLine();
                if (userInput != null && userInput.ToLower() == "q")
                    return;
                
                var isNumber = Int32.TryParse(userInput, out var chosenItem);
                if (!isNumber)
                {
                    View.NotANumber();
                } 

                BuyItem(chosenItem);
                return;
            }
        }

        private void BuyItem(int itemId)
        {
            GoodsItem item = _chips;
            switch (itemId)
            {
                case 1:
                    item = _chips;
                    break;
                case 2:
                    item = _cola;
                    break;
                case 3:
                    item = _peanuts;
                    break;
                case 4:
                    item = _chocolate;
                    break;
                default:
                    View.InvalidOption();
                    ChooseItem();
                    break;
            }

            View.GoodsItemSummary(item);
            
            while (true)
            {
                View.AreYouSure();
                var userChoice = Console.ReadLine()?.ToLower();
                Console.WriteLine();
                switch (userChoice)
                {
                    case "y":
                        ValidatePayment(item);
                        break;
                    case "n":
                        ChooseItem();
                        break;
                    default:
                        View.InvalidOption();
                        break;
                }
                return;
            }
        }

        private void ValidatePayment(GoodsItem item)
        {
            if (item.Price > User.MoneyAvailable)
            {
                View.PaymentDeclined();
                while (true)
                {
                    View.TransferFromAnotherAccount();
                    var userChoice = Console.ReadLine()?.ToLower();
                    switch (userChoice)
                    {
                        case "y":
                            Bank.TransferMoney(User);
                            ChooseItem();
                            break;
                        case "n":
                            ChooseItem();
                            break;
                        default:
                            View.InvalidOption();
                            break;
                    }
                }
            }

            if (!item.RemoveGoodsItem())
            {
                View.SoldOutMessage(item);
                ChooseItem();
            }

            User.AddToUserInventory(User, item);
            Bank.WithdrawMoney(item.Price, User);
            View.VendedMessage(item);
            ChooseItem();
        }
    }
}
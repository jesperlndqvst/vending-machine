using System;
using System.Collections.Generic;

namespace vending_machine
{
    public class VendingMachine
    {
        public Chips chips = new Chips("CHIPS", 3, 1, 3);
        public Cola cola = new Cola("COLA", 1, 2, 10);
        public Peanut peanuts = new Peanut("PEANUTS", 7, 3, 10);
        public Bank Bank { get; set; }
        public User User { get; set; }
        public View View { get; set; }

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
                if (userInput.ToLower() == "q")
                    break;
                
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

                            if (userInput.ToLower() == "q")
                            {
                                StartMenu();
                                break;
                            }
                        }

                        break;
                }
            }
        }

        public void ChooseItem()
        {
            View.WhatDoYouWantToBuy();
            while (true)
            {
                View.DisplayGoodsItems(chips);
                View.DisplayGoodsItems(cola);
                View.DisplayGoodsItems(peanuts);
                View.PressQToGoBack();

                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "q")
                {
                    StartMenu();
                }

                var isNumber = Int32.TryParse(userInput, out var chosenItem);
                if (!isNumber)
                {
                    View.NotANumber();
                    ChooseItem();
                }

                BuyItem(chosenItem);
                return;
            }
        }

        public void BuyItem(int itemId)
        {
            GoodsItem item = chips;
            switch (itemId)
            {
                case 1:
                    item = chips;
                    break;
                case 2:
                    item = cola;
                    break;
                case 3:
                    item = peanuts;
                    break;
                default:
                    View.InvalidOption();
                    ChooseItem();
                    break;
            }

            View.GoodsItemSummary(item);
            var isSure = false;
            while (!isSure)
            {
                View.AreYouSure();
                var userChoice = Console.ReadLine()?.ToLower();
                Console.WriteLine();
                switch (userChoice)
                {
                    case "y":
                        isSure = true;
                        break;
                    case "n":
                        ChooseItem();
                        break;
                    default:
                        View.InvalidOption();
                        break;
                }
            }

            ValidatePayment(item);
        }

        public void ValidatePayment(GoodsItem item)
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
using System;

namespace vending_machine
{
    public class Bank
    {
        private int Balance { get; set; }
        private View View { get; }

        public Bank(View view)
        {
            View = view;
            Balance = 100;
        }

        public void BankMenu(User user)
        {
            while (true)
            {
                View.BankMenuOptions();
                View.PressQToGoBack();

                var userInput = Console.ReadLine();

                if (userInput.ToLower() == "q")
                    return;

                switch (userInput)
                {
                    case "1":
                        CheckBalance(user);
                        break;
                    case "2":
                        TransferMoney(user);
                        break;
                    default:
                        while (true)
                        {
                            View.InvalidOption();
                            View.PressQToGoBack();

                            userInput = Console.ReadLine();
                            if (userInput != null && userInput.ToLower() == "q")
                                break;
                        }

                        break;
                }
            }
        }

        private void CheckBalance(User user)
        {
            while (true)
            {
                View.CurrentBalance(user, Balance);
                View.PressQToGoBack();

                var userInput = Console.ReadLine();
                if (userInput != null && userInput.ToLower() == "q")
                    break;
            }
        }

        public void TransferMoney(User user)
        {
            View.HowMuchWithdraw();
            View.CurrentBalance(user, Balance);
            View.PressQToGoBack();

            var userInput = Console.ReadLine();

            if (userInput != null && userInput.ToLower() == "q")
            {
                BankMenu(user);
                return;
            }

            var isNumber = Int32.TryParse(userInput, out int amount);

            while (!isNumber)
            {
                View.InvalidAmount();
                userInput = Console.ReadLine();
                isNumber = Int32.TryParse(userInput, out amount);
            }

            if (amount > Balance || amount <= 0)
            {
                View.InvalidAmount();
                TransferMoney(user);
                return;
            }

            Balance -= amount;
            user.MoneyAvailable += amount;
            CheckBalance(user);
        }

        public void WithdrawMoney(int itemPrice, User user)
        {
            user.MoneyAvailable -= itemPrice;
        }
    }
}
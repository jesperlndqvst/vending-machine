using System;
using System.Collections.Generic;

namespace vending_machine
{
    public class User
    {
        private View View { get; set; }
        public int MoneyAvailable { get; set; }
        private readonly Dictionary<GoodsItem, int> _itemsAvailable = new Dictionary<GoodsItem, int>();

        public User(View view)
        {
            View = view;
            MoneyAvailable = 10;
        }

        public void AddToUserInventory(User user, GoodsItem item)
        {
            user._itemsAvailable.TryGetValue(item, out var currentCount);
            user._itemsAvailable[item] = currentCount + 1;
        }

        public void ListUserInventory(User user)
        {
            if (_itemsAvailable.Count == 0)
            {
                View.NotBoughtAnything();
            }
            else
            {
                View.BoughtItems(_itemsAvailable);
            }

            while (true)
            {
                View.PressQToGoBack();
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "q")
                    break;
            }
        }
    }
}
using System;
using System.Reflection.Metadata;

namespace vending_machine
{
    public abstract class GoodsItem
    { 
       public string Name { get; }
       public int Price { get; }
       public int Id { get; }
       public int ItemsRemaining { get; private set;}
       public string VendedMessage { get; }
       public string SoldOutMessage { get; }

       protected GoodsItem(string name, int price, int id, int itemsRemaining)
       {
           Name = name;
           Price = price;
           Id = id;
           ItemsRemaining = itemsRemaining;
           VendedMessage = $"HERE IS YOUR {Name}. THANK YOU AND COME AGAIN!";
           SoldOutMessage = $"{Name} IS SOLD OUT. PLEASE CHOOSE SOME THING ELSE!";
       }

       public bool RemoveGoodsItem()
       {
           if (ItemsRemaining <= 0)
               return false;
           ItemsRemaining--;
           return true;
       }
       
    }
}
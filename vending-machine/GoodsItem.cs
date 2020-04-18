using System;
using System.Reflection.Metadata;

namespace vending_machine
{
    public abstract class GoodsItem
    { 
       public string Name { get; set; }
       public int Price { get; set; }
       public int Id { get; set; }
       public int ItemsRemaining { get; set;}
       public string VendedMessage { get; set; }
       public string SoldOutMessage { get; set; }

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
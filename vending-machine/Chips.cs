namespace vending_machine
{
    public class Chips : GoodsItem
    {
        public Chips(string name, int price, int id, int itemsRemaining) :
            base(name, price, id, itemsRemaining)
        {
        }
    }
}
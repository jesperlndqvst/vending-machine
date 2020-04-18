namespace vending_machine
{
    public class Cola : GoodsItem
    {
        public Cola(string name, int price, int id, int itemsRemaining) :
            base(name, price, id, itemsRemaining)
        {
        }
    }
}
using System.Collections.Generic;

namespace Project.Models
{
    internal class Inventory
    {
        private List<Item> itemsList = new List<Item>();
        public List<Item> Items
        {
            get { return itemsList; }
            set { itemsList = value; }
        }
        public void AddItem(Item item)
        {
            itemsList.Add(item);
        }
        public void RemoveItem(Item item)
        {
            itemsList.Remove(item);
        }
    }
}

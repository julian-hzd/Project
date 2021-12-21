using System.Collections.Generic;

namespace Project.Models
{
    /*
        Names: Jeremy Oroc, Julian Hernandez
        Student IDs: 2034933 (Jeremy), 2093730 (Julian)
        Programming III - Fall 2021
    */
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

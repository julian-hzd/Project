using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Models
{
    internal class Inventory
    {
        private List<Item> itemsList = new List<Item>();
        public static List<Item> _shoppingList = new List<Item>();

        public List<Item> Items
        {
            get { return itemsList; }
            set { itemsList = value; } // not sure if we should have a set here
        }
        public void AddItem(Item item)
        {
            itemsList.Add(item);
            if(item.AvailableItemQty < item.MinItemQty)     //When an item is added check if it should go on the shopping list
                _shoppingList.Add(item);
        }
        public void RemoveItem(Item item)
        {
            itemsList.Remove(item);
        }
        public void GeneralReport()
        {
            foreach (Item item in itemsList)
            {


        
            }
        }
        /*
         General Report
         Shopping List
         Load Items
         Save Items

        Hint
        C# classes File and Directory offer many methods that provide 
        several functionalities. These can ease implementation in your app. 

        Reading and writing to files. 

        Creating files and deleting files. 

        Creating and deleting directories. 

        Checking content of directories. 
         */
    }
}

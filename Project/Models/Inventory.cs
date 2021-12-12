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
        private List<Item> _items = new List<Item>();

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; } // not sure if we should have a set here
        }
        public void AddItem(Item item)
        {
            _items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        /*
         Update item 
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

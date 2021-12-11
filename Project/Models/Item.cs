using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Models
{
    public enum categories
    {
        Pantry, Diary, Drinks, Frozen, Food, 
        Fruit_and_Vegetable, Bakery, Cleaning_Supplies, Other
    }
    internal class Item
    {
        private string _itemName;
        private static int _itemQty;
        private Supplier _supplier;
        private string _location;
        public Item() { }
        public Item(string itemName, string category)
        {
            _itemName = itemName;
            _itemQty++;
            _supplier = new Supplier();        
            _location = RandomLocation();
        }

        public string ItemName
        {
            get { return _itemName; }                           //No need to validate, it was already validate on the main window
            set { _itemName = value; }
        }
        public int ItemQty
        {
            get { return _itemQty; }
            set { _itemQty = ValidateQty(value); }
        }
        private int ValidateQty(int tempQty)
        {
            if (tempQty < 0)
                throw new ArgumentException("Quantity cannot be negative");
            return tempQty;
        }
        private string RandomLocation()
        {
            Random rnd = new Random();
            int randomIsle = rnd.Next(1,25); 
            return $"Isle number {randomIsle}";
        }
        //Category logic/functionality not implemented
    }
}

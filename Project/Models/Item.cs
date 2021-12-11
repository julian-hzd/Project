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
        private int _itemQty;
        private static int _minQty = 1; //static since it's a common variable that we will want
        private Supplier _supplier;
        private string _location;
        private string _category;
        public Item() { }
        public Item(string itemName, string category, int itemQty)
        {
            _itemName = itemName;
            _itemQty = itemQty;
            _supplier = new Supplier();
            _location = GetRandomLocation();
        }

        public string ItemName
        {
            get { return _itemName; } //No need to validate, it was already validate on the main window
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
        private string GetRandomLocation()
        {
            Random rnd = new Random();
            const int MIN_ISLE = 1, MAX_ISLE = 25;

            int randomIsle = rnd.Next(MIN_ISLE, MAX_ISLE);
            return $"Isle number {randomIsle}";
        }
        //Category logic/functionality not implemented
    }
}

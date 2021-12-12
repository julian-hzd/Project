using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Models
{
    public  class Item
    {
        private string _itemName;
        private int _itemQty;
        public static int _minQty = 1; //static since it's a common variable that we will want  ;   public so main window can access to it
        private Supplier _supplier;
        private int _isleNumber;
        private string _category;
        private string _supplierString;                                                     // To achieve binding
        public Item(string itemName, int itemQty)                                           // For an item to be added at, the minimum requirements are name and quantity
        {
            _itemName = itemName;
            _itemQty = itemQty;
        }
        /*
        public Item(string itemName, string category, int itemQty)
        {
            _itemName = itemName;
            _itemQty = itemQty;
            _supplier = new Supplier();
            _location = GetRandomLocation();
        }
        */
        public string SupplierString                                                        // To achieve binding
        {
            get { return _supplierString; } 
            set { _supplierString = value; }
        }
        public string CategoryString                                                        // To achieve binding
        {
            get { return _category; } 
            set { _category = value; }
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
        public Supplier Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        public int IsleNumber
        {
            get { return _isleNumber; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("Isles start from 0, negative values are not accepted");
                
                _isleNumber=value; 
            }
        }
        private int ValidateQty(int tempQty)
        {
            if (tempQty < 0)
                throw new ArgumentException("Quantity cannot be negative");

            return tempQty;
        }

        //Category logic/functionality not implemented
    }
}

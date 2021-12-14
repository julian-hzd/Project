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
        public const int MINQTY = 1;                                                  //static since it's a common variable that we will want  ;   public so main window can access to it
        private int _minItemQty;
        private static int maxIsle=100;
        private string _itemName;
        private int _itemQty;
       
        private int _isleNumber;

        private Category _category;
        private string _categoryString;

        private Supplier _supplier;
        private string _supplierString;                                                     // To achieve binding
        public Item(string itemName, int itemQty)                                           // For an item to be added at, the minimum requirements are name and quantity
        {
            _itemName = itemName;
            _itemQty = itemQty;
        }
        
        public Item(string itemName, int itemQty, Supplier supplier, int isleNumber, Category category)
        {
            _itemName = itemName;
            _itemQty = itemQty;
            _supplier = supplier;
            _isleNumber = isleNumber;
            _category = category;
        }
        public Supplier Supplierr
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        public Category Category
        {
            get { return _category; }//
            set { _category = value; }
        }
        public string SupplierString                                                        // To achieve binding
        {
            get { return _supplierString; } 
            set { _supplierString = value; }
        }
        public string CategoryString                                                        // To achieve binding
        {
            get { return _categoryString; } 
            set { _categoryString = value; }
        }
        public string ItemName
        {
            get { return _itemName; } //No need to validate, it was already validate on the main window
            set { _itemName = value; }
        }
        public int ItemQty
        {
            get { return _itemQty; }
            set 
            {
                if (value == 0)                                          // Force the value to 1
                    _itemQty = MINQTY;
                else
                _itemQty = ValidateQty(value); 
            }
        }
        public int MinItemQty
        {
            get { return _minItemQty; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("Minimum quantity cannot be negative");
                if (value ==0)
                    throw new ArgumentException("Minimum quantity is 1");
                _minItemQty = value;
            }
        }
        public int IsleNumber
        {
            get { return _isleNumber; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("Isles start from 0, negative values are not accepted");
                if (value > maxIsle)
                    _isleNumber = maxIsle;                                                          //  If isle number > 100 | force the value to be 100 (max number of isles)
                else
                _isleNumber=value; 
            }
        }
        private int ValidateQty(int tempQty)
        {
            if (tempQty < 0)
                throw new ArgumentException("Quantity cannot be negative");
            if (tempQty == 0)
                throw new ArgumentException("Minimum quantity is 1");
            return tempQty;
        }

        //Category logic/functionality not implemented
    }
}

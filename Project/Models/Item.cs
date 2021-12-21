using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Models
{
    public class Item
    {
        #region DATA FIELDS
        private string _itemName;
        private int _availableItemQty;
        private int _minItemQty = 1; //has default value
        private int _location; //Isle number
        private string _supplier;
        private string _category;

        private const int MAX_ISLE = 100;
        #endregion
        #region CONSTRUCTORS
        public Item()
        {
            _itemName = string.Empty;
            _availableItemQty = 0;
            _location = 0;
            _supplier = string.Empty;
            _category = string.Empty;
        }
        public Item(string itemName, int availableItemQty, int minItemQty, int location, string supplier, string category)
        {
            ItemName = itemName;
            AvailableItemQty = availableItemQty;
            MinItemQty = minItemQty;
            Location = location;
            Supplier = supplier;
            Category = category;
        }
        #endregion
        #region PROPERTIES
        public string ItemName
        {
            get { return _itemName; } //Validation on main window
            set { _itemName = value; }
        }
        public int AvailableItemQty
        {
            get { return _availableItemQty; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Available item quantity cannot be negative");
            }
        }
        public int MinItemQty
        {
            get { return _minItemQty; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Minimum quantity cannot be less than 1");

                _minItemQty = value;
            }
        }
        public int Location
        {
            get { return _location; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Isle number cannot be negative");

                if (value > MAX_ISLE)
                    throw new ArgumentException("Isle number cannot exceed " + MAX_ISLE);

                else
                    _location = value;
            }
        }
        public string Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        #endregion
    }
}

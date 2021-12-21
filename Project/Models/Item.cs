using System;

namespace Project.Models
{
    /*
        Names: Jeremy Oroc, Julian Hernandez
        Student IDs: 2034933 (Jeremy), 2093730 (Julian)
        Programming III - Fall 2021
    */
    public class Item
    {
        #region DATA FIELDS
        private string _itemName;
        private int _availableItemQty;
        private int _minItemQty = MIN_ITEM_QTY;
        private string _location;
        private string _supplier;
        private string _category;

        private const int MIN_ITEM_QTY = 1;
        #endregion
        #region CONSTRUCTORS
        public Item()                                                               // Default constructor
        {
            _itemName = string.Empty;
            _availableItemQty = 0;
            _location = string.Empty;
            _supplier = string.Empty;
            _category = string.Empty;
        }
        public Item(string itemName, int availableItemQty)                          //  Minimum arguments to create an instance of an item
        {
            ItemName = itemName;
            AvailableItemQty = availableItemQty;
            Location = string.Empty;
            Supplier = string.Empty;
            Category = string.Empty;
        }
        public Item(string itemName, int availableItemQty, int minItemQty, string location, string supplier, string category) // Sets all backing fields
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
            get 
            {
                if (_availableItemQty < 0)        // This validation it is needed to avoid anomalies when editing an item of the inventory list
                    return 0;

                return _availableItemQty; 
            }
            set
            {
                if (value < 0)                     // If user tries to set a negative quantity, the available quantity will be forced to 0
                    _availableItemQty = 0;

                _availableItemQty = value;
            }
        }
        public int MinItemQty
        {
            get 
            {
                if (_minItemQty < MIN_ITEM_QTY)     // This validation it is needed to avoid anomalies when editing an item of the inventory list
                    return MIN_ITEM_QTY;

                return _minItemQty; 
            }
            set
            {
                if (value < MIN_ITEM_QTY)                 // If user tries to set an inavlid <1 minimum quantity, this will be forced to 1
                    _minItemQty = MIN_ITEM_QTY;

                _minItemQty = value;
            }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
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
        #region METHODS
        public string GetCSVItem()
        {
            return string.Format($"{ItemName},{AvailableItemQty},{MinItemQty},{Location},{Supplier},{Category}");
        }
        public void SetCSVItem(string value) //note this only works from saved csv files from the program
        {
            string[] data = value.Split(',');

            try
            {
                ItemName = data[0];
                AvailableItemQty = int.Parse(data[1]);
                MinItemQty = int.Parse(data[2]);
                Location = data[3];
                Supplier = data[4];
                Category = data[5];
            }
            catch (Exception e)
            {
                throw new Exception("Data is not valid " + e.Message);
            }
        }
        #endregion
    }
}

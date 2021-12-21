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
        private int _minItemQty = MIN_ITEM_QTY;
        private string _location;
        private string _supplier;
        private string _category;

        private const int MIN_ITEM_QTY = 1;
        #endregion
        #region CONSTRUCTORS
        public Item()
        {
            _itemName = string.Empty;
            _availableItemQty = 0;
            _location = string.Empty;
            _supplier = string.Empty;
            _category = string.Empty;
        }
        public Item(string itemName, int availableItemQty)
        {
            ItemName = itemName;
            AvailableItemQty = availableItemQty;
            Location = string.Empty;
            Supplier = string.Empty;
            Category = string.Empty;
        }
        public Item(string itemName, int availableItemQty, int minItemQty, string location, string supplier, string category)
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
                if (_availableItemQty < 0)
                    return 0;

                return _availableItemQty; 
            }
            set
            {
                if (value < 0)
                    _availableItemQty = 0;

                _availableItemQty = value;
            }
        }
        public int MinItemQty
        {
            get 
            {
                if (_minItemQty < MIN_ITEM_QTY)
                    return MIN_ITEM_QTY;

                return _minItemQty; 
            }
            set
            {
                if (value < MIN_ITEM_QTY)
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
        public string GetCSVItem()
        {
            return string.Format($"{ItemName},{AvailableItemQty},{MinItemQty},{Location},{Supplier},{Category}");
        }
        public void SetCSVItem(string value)
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
        //public string CSVItem1
        //{
        //    get { return string.Format($"{ItemName},{AvailableItemQty},{MinItemQty},{Location},{Supplier},{Category}"); }
        //    set
        //    {
        //        string[] data = value.Split(',');

        //        try
        //        {
        //            ItemName = data[0];
        //            AvailableItemQty = int.Parse(data[1]);
        //            MinItemQty = int.Parse(data[2]);
        //            Location = data[3];
        //            Supplier = data[4];
        //            Category = data[5];
        //        }
        //        catch (Exception e)
        //        {
        //            throw new Exception("Data is not valid " + e.Message);
        //        }
        //    }
        //}
    }
}

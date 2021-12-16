using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Project.Models;

namespace Project
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        private Supplier _supplier = new Supplier();
        private string[] _suppliers;                            // In case the class fails
        private Inventory _inventory = new Inventory();

        private string[] _categories;

        private Item _item;
        public AddItem()
        {
            InitializeComponent();

            
            //read fields 
            //validate
            //create and return an item instance with the info provided


            cmbSuppliers.ItemsSource = _supplier.GetSuppliers();            // Supplier
            cmbCategories.ItemsSource = Category.CategoryInArr();           // Catergoeis

            if (cmbSuppliers.ItemsSource == null)                           // If null = binding failed
                cmbSuppliers.ItemsSource = Data.LoadSuppliers(); 
            
            if (cmbCategories.ItemsSource == null)
                cmbCategories.ItemsSource = Data.LoadCategories();
            
        }
        private bool CheckItemFields()                                              // Combo boxes can be null
        {
            bool numEntered = false;
            StringBuilder missingFields = new StringBuilder();

            
            if (string.IsNullOrEmpty(txtName.Text))
                missingFields.AppendLine("Name is a required field");

            if (!ValidateItemName(txtName.Text))                                    // if name valid returns true, t & f = f
                missingFields.AppendLine("Name can only contain letters");

            if (string.IsNullOrEmpty(qtyNumber.Text))
                 missingFields.AppendLine("Quantity is a required field");
            else { numEntered = true; }

            if (!ValidateQty(qtyNumber.Text))                                       // Check that quantity are numbers
                { missingFields.AppendLine("Quantity: only numbers are accepted"); numEntered = false; }

            if(numEntered)                                                          // If a number is entered
            {
                if (CheckNumber(qtyNumber.Text))
                    missingFields.AppendLine("Quantity can't be negative");
                if (int.Parse(qtyNumber.Text) == 0)
                    missingFields.AppendLine("Minimum quantity is 1");
            }
              

            if (string.IsNullOrEmpty(missingFields.ToString()))                     // if it is not empty, there are errors 
                return true;

            MessageBox.Show(missingFields.ToString(), "Required  Input", MessageBoxButton.OK, MessageBoxImage.Error);
            
            return false;
        }
        Item Item
        {
            get { return _item; } 
            set { _item = value; }
        }
        public Item GetItem()
        { return _item; }
        private bool CheckNumber(string numString)
        {
            if (int.Parse(numString) < 0)
                return true;

            return false;
        }
        private bool ValidateItemName(string itemName)  // "Eg2gs" is not valid
        {
            foreach (char letter in itemName)
            {
                if (!char.IsLetter(letter))
                    return false;
            }
            return true;
        }
        private bool ValidateQty(string qtyAsString)    //12Hi3 not valid
        {
            if (int.TryParse(qtyAsString, out _))
                return true;
            return false;
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {

            // if check items passed test
            if (CheckItemFields())
            {
                _item = new Item(txtName.Text, int.Parse(qtyNumber.Text))
                {
                    SupplierString = cmbSuppliers.SelectedItem as string,            // To string crashes when value is null
                    CategoryString = cmbCategories.SelectedItem as string
                };
                this.Close();
            }
            else
                MessageBox.Show("Beware that invalid items won't be added");
        }
    }
}

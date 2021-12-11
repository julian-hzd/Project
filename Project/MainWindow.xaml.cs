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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.Models;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Supplier _supplier=new Supplier();
        private string[] _suppliers;
        private Inventory _inventory = new Inventory();
        public MainWindow()
        {
            InitializeComponent();
            

            //Binding
            cmbSuppliers.ItemsSource = _supplier.GetSuppliers();
            lbItem.ItemsSource = _inventory.Items;

            //lbItem.ItemsSource = item;
            if (cmbSuppliers.ItemsSource == null)
            {
                LoadSuppliers();
                cmbSuppliers.ItemsSource = _suppliers; 
            }
        }
        private void LoadSuppliers()            // In case class supplier class fails, read from file at . level to get suplpiers
        {
            string[] temp = Data.GetSuppliers().Split(',');
            if (temp != null)
                _suppliers = temp;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckItemFields())
            {
                _inventory.AddItem(GetItem());
                lbItem.Items.Refresh(); 
            }
        }

        private bool CheckItemFields()
        {
            StringBuilder missingFields = new StringBuilder();
            if (string.IsNullOrEmpty(txtName.Text))
                missingFields.AppendLine("Name is a required field");

            if (!ValidateItemName(txtName.Text))                                    // if name valid returns true, t & f = f
                missingFields.AppendLine("Name can only contain letters");

            if (!ValidateQty(qtyNumber.Text))                                       // Check that quantity are numbers
                missingFields.AppendLine("Quantity: only numbers are accepted");

            if(cmbSuppliers.SelectedIndex == -1)                                    //Returns -1 if empty
                missingFields.AppendLine("A supplier must be selected");

            if(string.IsNullOrEmpty(qtyNumber.Text))
                missingFields.AppendLine("Quantity is a required field");

            if (string.IsNullOrEmpty(missingFields.ToString()))                     // if it is not empty, there are errors 
                return true;

            MessageBox.Show(missingFields.ToString(), "Required  Input", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        private bool ValidateItemName(string itemName)  // "Eg2gs" is not valid
        {
            foreach (char letter in itemName)
            {
                if(!char.IsLetter(letter))
                    return false;
            }
            return true;
        }
        private bool ValidateQty(string qtyAsString)    //12Hi3 not valid
        {
            if(int.TryParse(qtyAsString, out _))
                return true;
            return false;
        }
        private Item GetItem()
        {
            return new Item
            {
                ItemName = txtName.Text,
                ItemQty = int.Parse(qtyNumber.Text)
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for AddNewItem.xaml
    /// </summary>

    public partial class AddNewItem : Window
    {
        public AddNewItem()
        {
            InitializeComponent();

            //read fields
            //validate
            //create and return an item instance with the info provided

            cmbSuppliers.ItemsSource = SuppliersList.GetSuppliers(); //load suppliers from class
            cmbCategories.ItemsSource = CategoriesList.GetCategories(); //load category from class

            if (cmbSuppliers.ItemsSource == null) //backup
                cmbSuppliers.ItemsSource = Data.LoadSuppliers();

            if (cmbCategories.ItemsSource == null) //backup
                cmbCategories.ItemsSource = Data.LoadCategories();

        }
        private bool CheckItemFields() //Combo boxes can be null
        {
            try
            {
                StringBuilder missingFields = new StringBuilder();

                if (Validation.ValidateItemName(txtName.Text))
                    missingFields.AppendLine(Validation.Message);

                if (Validation.ValidateAvailableQuantity(availableQtyNumber.Text))
                    missingFields.AppendLine(Validation.Message);

                if (Validation.ValidateMinimumQuantity(minQtyNumber.Text))
                    missingFields.AppendLine(Validation.Message);

                if (string.IsNullOrEmpty(missingFields.ToString())) //if it's empty, no errors
                    return true;

                MessageBox.Show(missingFields.ToString(), "Required Input", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
           
        }
        private Item Item { get; set; }

        private void done_Click(object sender, RoutedEventArgs e)
        {

            // if check items passed test
            if (CheckItemFields())
            {
                Item = new Item()
                {
                    ItemName = txtName.Text,
                    AvailableItemQty = int.Parse(availableQtyNumber.Text),
                    MinItemQty = int.Parse(minQtyNumber.Text),
                    Location = int.Parse(locationNumber.Text),
                    Supplier = cmbSuppliers.SelectedItem.ToString(),
                    Category = cmbCategories.SelectedItem.ToString()
                };

                Close();
            }
            else
                MessageBox.Show("Invalid items won't be added");
        }
    }
}

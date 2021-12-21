using System;
using System.Text;
using System.Windows;
using Project.Models;

namespace Project
{
    /// <summary>
    /// Interaction logic for AddNewItem.xaml
    /// </summary>

    public partial class AddNewItem : Window
    {
        #region CONSTRUCTOR
        public AddNewItem()
        {
            InitializeComponent();

            cmbSuppliers.ItemsSource = SuppliersList.GetSuppliers(); //load suppliers from class
            cmbCategories.ItemsSource = CategoriesList.GetCategories(); //load category from class

            if (cmbSuppliers.ItemsSource == null) //backup
                cmbSuppliers.ItemsSource = Data.LoadSuppliers();

            if (cmbCategories.ItemsSource == null) //backup
                cmbCategories.ItemsSource = Data.LoadCategories();
        }
        #endregion
        #region VALIDATION
        private bool CheckItemFields() //Combo boxes can be null
        {
            try
            {
                StringBuilder missingFields = new StringBuilder();

                if (Validate.ValidateItemName(txtName.Text))
                    missingFields.AppendLine(Validate.Message);

                if (Validate.ValidateAvailableQuantity(availableQtyNumber.Text))
                    missingFields.AppendLine(Validate.Message);

                if(minQtyNumber.Text != string.Empty)
                {
                    if (Validate.ValidateMinimumQuantity(minQtyNumber.Text))
                        missingFields.AppendLine(Validate.Message);
                }

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
        #endregion
        #region ADDING ITEM
        public Item Item { get; set; }
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            // if check items passed test
            if (CheckItemFields())
            {
                bool temp = int.TryParse(minQtyNumber.Text, out _);
                const int defaultMin = 1;

                Item = new Item(txtName.Text, int.Parse(availableQtyNumber.Text))
                {
                    MinItemQty = temp ? int.Parse(minQtyNumber.Text) : defaultMin,
                    Location = locationNumber.Text,
                    Supplier = cmbSuppliers.SelectedItem as string,
                    Category = cmbCategories.SelectedItem as string
                };

                Close();
            }
            else
                return;
        }
        #endregion
    }
}

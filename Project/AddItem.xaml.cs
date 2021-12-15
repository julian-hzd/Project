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
        public AddItem()
        {
            InitializeComponent();
            //read fields 
            //validate
            //create and return an item instance with the info provided
            /*
            lbItems.ItemsSource= _inventory.Items; 

            cmbSuppliers.ItemsSource = _supplier.GetSuppliers();            // Supplier
            cmbCategories.ItemsSource = Category.CategoryInArr();           // Catergoeis

            if (cmbSuppliers.ItemsSource == null)                           // If null = binding fail
            {
                LoadSuppliers();
                cmbSuppliers.ItemsSource = _suppliers; 
            }
            if (cmbCategories.ItemsSource == null)
            {
                LoadCategories();
                cmbCategories.ItemsSource = _categories;
            }
            */
        }
    }
}

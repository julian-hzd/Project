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
    /// Interaction logic for ItemEdit.xaml
    /// </summary>
    public partial class ItemEdit : Window
    {
        public ItemEdit(Item item)
        {
            InitializeComponent();

            dgItems.DataContext = item;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (object obj in dgItems.Children)
            {
                if (obj is TextBox)
                    (obj as TextBox).Clear();
            }
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            if (CheckItemFields())
            {

            }
            else
                MessageBox.Show("Invalid changes won't be saved");

        }

        private bool CheckItemFields()
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
                Console.WriteLine(e);
                return false;
            }
        }
    }
}

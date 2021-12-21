using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Project.Models;
namespace Project
{
    /// <summary>
    /// Interaction logic for ItemEdit.xaml
    /// </summary>
    public partial class ItemEdit : Window
    {
        #region CONSTRUCTOR
        public ItemEdit(Item item)
        {
            InitializeComponent();

            dgItems.DataContext = item;
        }
        #endregion
        #region BUTTONS
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (object obj in dgItems.Children)
            {
                if (obj is TextBox)
                    (obj as TextBox).Clear();
            }
        }
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckItemFields();

            if (!valid)
                return;
            else
                Close();
        }
        #endregion
        #region VALIDATION
        private bool CheckItemFields()
        {
            try
            {
                StringBuilder missingFields = new StringBuilder();

                if (Validate.ValidateItemName(txtName.Text))
                    missingFields.AppendLine(Validate.Message);

                if (Validate.ValidateAvailableQuantity(availableQtyNumber.Text))
                    missingFields.AppendLine(Validate.Message);

                if (minQtyNumber.Text != string.Empty)
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
    }
}

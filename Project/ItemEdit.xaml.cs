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
    /// Interaction logic for ItemEdit.xaml
    /// </summary>
    public partial class ItemEdit : Window
    {
        private Supplier _supplier = new Supplier();
        public ItemEdit(Item item)
        {
            InitializeComponent();

            dgItems.DataContext=item;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (object obj  in dgItems.Children)
            {
                if(obj is TextBox)
                    (obj as TextBox).Clear();
            }
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            if(!CheckItemFields())                                                  // Gave them freedom to use numbers on the item name/supplier/category
                MessageBox.Show("Invalid changes won't be saved");
            
        }
        private bool CheckItemFields()                                              // Combo boxes can be null
        {
            try
            {
                bool numEntered = true;
                StringBuilder missingFields = new StringBuilder();


                if (!ValidateQty(qtyNum.Text))                                       // Check that quantity are numbers
                { missingFields.AppendLine("Quantity: only numbers are accepted"); numEntered = false; }

                if (!string.IsNullOrEmpty(qtyNum.Text) && numEntered)                                                          // If a number is entered
                {
                    if (CheckNumber(qtyNum.Text))
                        missingFields.AppendLine("Quantity can't be negative");
                  
                }


                if (string.IsNullOrEmpty(missingFields.ToString()))                     // if it is not empty, there are errors 
                    return true;

                MessageBox.Show(missingFields.ToString(), "Required  Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
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
        private bool CheckNumber(string numString)
        {
            if (int.Parse(numString) < 0)
                return true;
            return false;
        }
    }
}

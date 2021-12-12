﻿using System;
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
        private string[] _suppliers;                            // In case the class fails

        private Inventory _inventory = new Inventory();

        private string[] _categories;                            // In case class fails
        public MainWindow()
        {
            InitializeComponent();

            // Binding
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
        }
        private void LoadSuppliers()            // In case class supplier class fails, read from file at . level to get suplpiers
        {
            string[] temp = Data.GetSuppliers().Split(',');
            if (temp != null)
                _suppliers = temp;
        }
        private void LoadCategories()            // In case class supplier class fails, read from file at . level to get suplpiers
        {
            string[] temp = Data.GetCategories().Split(',');
            if (temp != null)
                _categories = temp;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckItemFields())
            {
                _inventory.AddItem(GetItem());
                lbItems.Items.Refresh(); 
            }
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
            return new Item(txtName.Text, int.Parse(qtyNumber.Text))
            {
                SupplierString = cmbSuppliers.SelectedItem as string,            // To string crashes when value is null
                CategoryString= cmbCategories.SelectedItem as string            
            };
        }
        private bool CheckNumber(string numString)
        {
            if (int.Parse(numString)<0)
                return true;

            return false;
        }
        private void EditClick(object sender, RoutedEventArgs e)            //Not working properly the item edit, I asked aref
        {
            Item temp = lbItems.SelectedItem as Item;                       //List box is visitor so no need to check
            ItemEdit editItemWindow = new ItemEdit(temp);   
            editItemWindow.ShowDialog();
            lbItems.Items.Refresh();
        }

        private void Dlt_Click(object sender, RoutedEventArgs e)
        {

            Item temp = lbItems.SelectedItem as Item;  
            
            if (temp != null)
            {
                if (temp.ItemQty != Item._minQty)                           // Not sure if this should be here
                {
                    _inventory.RemoveItem(temp);
                    lbItems.Items.Refresh();
                }
                else
                    MessageBox.Show("The minimum quantity is 1");
            }
        }
        
        private void QtyIncrease_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;
            if (temp == null)
                MessageBox.Show("Please select an item");
            else
            {
                temp.ItemQty++;
                lbItems.Items.Refresh();
            }
            
        }
        private void QtyDecrease_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;
            if(temp==null)
                MessageBox.Show("Please select an item");
          else if(temp.ItemQty!=1)
            {
                temp.ItemQty--;                                     //If button is clicked without selecting item, crashes fix, same above
                lbItems.Items.Refresh();
            }          

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _inventory.Items.Clear();
            lbItems.Items.Refresh();
        }
    }
}

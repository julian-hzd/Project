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
using Microsoft.Win32;
using System.IO;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Inventory inventory = new Inventory();
        private const string NO_SELECT = "Please select an item";
        private string saveLocation = string.Empty;
        private bool saved = true;
        public MainWindow()
        {
            InitializeComponent();

            lbItems.ItemsSource = inventory.Items;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddNewItem addItem = new AddNewItem(); // set combo boxes 
            addItem.ShowDialog();

            if (addItem.Item != null)
            {
                inventory.AddItem(addItem.Item);
                lbItems.Items.Refresh();
                saved = false;
            }
        }

        private void EditClick(object sender, RoutedEventArgs e)            //Not working properly the item edit, I asked aref
        {
            Item temp = lbItems.SelectedItem as Item;               //List box is visitor so no need to check

            if (temp != null)
            {
                ItemEdit editItemWindow = new ItemEdit(temp);

                editItemWindow.ShowDialog();
                lbItems.Items.Refresh();
                saved = false;
            }
            else
                MessageBox.Show(NO_SELECT, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Dlt_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;

            if (temp != null)
            {
                inventory.RemoveItem(temp);
                lbItems.Items.Refresh();
                saved = false;
            }
            else
                MessageBox.Show(NO_SELECT, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void QtyIncrease_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;

            if (temp == null)
                MessageBox.Show(NO_SELECT, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            else
            {
                temp.AvailableItemQty++;
                lbItems.Items.Refresh();
                saved = false;
            }

        }
        private void QtyDecrease_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;

            if (temp == null)
                MessageBox.Show(NO_SELECT, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            else if (temp.AvailableItemQty <= 0)
            {
                MessageBox.Show("Item Quantity cannot be negative", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else
            {
                temp.AvailableItemQty--;                                     //If button is clicked without selecting item, crashes fix, same above
                lbItems.Items.Refresh();
                saved = false;
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (lbItems.HasItems == true)
            {
                inventory.Items.Clear();
                lbItems.Items.Refresh();
                saved = false;
            }
            else
            {
                MessageBox.Show("There are no items in the inventory tracker", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (inventory.Items.Count == 0)
            {
                MessageBox.Show("There is nothing to save", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Save();
        }
        private void Save()
        {
            if (string.IsNullOrEmpty(saveLocation))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "CSV Files|*.csv";

                if (save.ShowDialog() == true)
                {
                    saveLocation = save.FileName;
                    txtStatusBar.Text = "File saved to " + saveLocation;
                }
                else
                    return;
            }

            SaveDataToFile();
        }
        private void SaveDataToFile()
        {
            if (!saved)
            {
                try
                {
                    StringBuilder itemsInfo = new StringBuilder();

                    foreach (Item item in inventory.Items)
                    {

                        itemsInfo.AppendLine(item.GetCSVItem());
                    }

                    File.WriteAllText(saveLocation, itemsInfo.ToString());
                    txtStatusBar.Text = "File saved to " + saveLocation;
                    saved = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSaved())
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "CSV Files|*.csv";

                if (open.ShowDialog() == true)
                {
                    saveLocation = open.FileName;
                    saved = true;
                    inventory.Items.Clear();

                    ReadItems();
                    lbItems.Items.Refresh();
                    txtStatusBar.Text = "File loaded from " + saveLocation;
                }
            }
        }
        private bool CheckIfSaved()
        {
            if (string.IsNullOrEmpty(saveLocation))
                return true;

            if (saved)
                return true;

            MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Unsaved Data", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return true;

            if (result == MessageBoxResult.Cancel)
                return false;

            if (result == MessageBoxResult.Yes)
                Save();

            return saved; //to check if user cancels or exits during saving process
        }
        private void ReadItems()
        {
            try
            {
                string[] values = File.ReadAllLines(saveLocation);
                foreach (string item in values)
                {
                    Item temp = new Item();
                    temp.SetCSVItem(item);
                    inventory.Items.Add(temp);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void generalReport_Click(object sender, RoutedEventArgs e)
        {
            GeneralReport generalReport = new GeneralReport(inventory.Items);
            generalReport.ShowDialog();
        }
        private void shoppingList_Click(object sender, RoutedEventArgs e)
        {
            ShoppingList shoppingList = new ShoppingList(inventory.Items);
            shoppingList.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CheckIfSaved();
        }
    }
}

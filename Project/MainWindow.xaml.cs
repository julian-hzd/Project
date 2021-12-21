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
        private bool saved = false;
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
                MessageBox.Show(NO_SELECT);
        }

        private void Dlt_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;

            if (temp != null)
            {
                inventory.RemoveItem(temp);
                lbItems.Items.Refresh();
            }
            else
                MessageBox.Show(NO_SELECT);
        }

        private void QtyIncrease_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;

            if (temp == null)
                MessageBox.Show(NO_SELECT);
            else
            {
                temp.AvailableItemQty++;
                lbItems.Items.Refresh();
            }

        }
        private void QtyDecrease_Click(object sender, RoutedEventArgs e)
        {
            Item temp = lbItems.SelectedItem as Item;

            if (temp == null)
                MessageBox.Show(NO_SELECT);

            else if (temp.AvailableItemQty <= 0)
            {
                MessageBox.Show("Item Quantity cannot be negative");
            }
            else
            {
                temp.AvailableItemQty--;                                     //If button is clicked without selecting item, crashes fix, same above
                lbItems.Items.Refresh();
            }

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (lbItems.HasItems == true)
            {
                inventory.Items.Clear();
                lbItems.Items.Refresh();
            }
            else
            {
                MessageBox.Show("There are no items in the inventory tracker");
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //check save location
            if (string.IsNullOrEmpty(saveLocation))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "CSV Files|*.csv";
                if(save.ShowDialog() == true)
                {
                    saveLocation = save.FileName;

                }
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbItems_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

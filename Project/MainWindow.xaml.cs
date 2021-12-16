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
        private string[] _suppliers;                            // In case the class fails

        private Inventory _inventory = new Inventory();

        private string[] _categories;                            // In case class fails
        public MainWindow()
        {
            InitializeComponent();

            // Binding
            
            lbItems.ItemsSource= _inventory.Items; 
            
        }
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
                AddItem addItem = new AddItem();    // set combo boxes 
                addItem.ShowDialog();
                if(addItem.GetItem()!=null)
                _inventory.AddItem(addItem.GetItem());
                lbItems.Items.Refresh(); 
            
            //  When user clicks add, the window AddItem will be called like the itemedit, and they will be able to enter the item info
            //  and the validation will be on its .cs as well, and it should return a user object that will be received and added here
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
                if (temp.ItemQty != Item.MINQTY)                           // Not sure if this should be here
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

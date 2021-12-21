using System.Collections.Generic;
using System.Windows;
using Project.Models;

namespace Project
{
    /// <summary>
    /// Interaction logic for ShoppingList.xaml
    /// </summary>
    public partial class ShoppingList : Window
    {
        public ShoppingList(List<Item> items)
        {
            InitializeComponent();

            List<Item> shoppingList = new List<Item>();

            foreach(var item in items)
            {
                if(item.AvailableItemQty < item.MinItemQty)
                    shoppingList.Add(item);
            }

            McDataGrid.ItemsSource = shoppingList;
        }
    }
}
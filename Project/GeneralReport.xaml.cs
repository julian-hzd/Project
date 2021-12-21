using System.Collections.Generic;
using System.Windows;
using Project.Models;

namespace Project
{
    /// <summary>
    /// Interaction logic for GeneralReport.xaml
    /// </summary>
    public partial class GeneralReport : Window
    {
        public GeneralReport(List<Item> items)
        {
            InitializeComponent();

            McDataGrid.ItemsSource = items;
        }
    }
}

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

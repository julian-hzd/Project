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
        
        private Supplier supplier=new Supplier();
        //private string[] suppliers;
        private string[] suppliers = { "Canada", "USA", "Other" };
        public MainWindow()
        {
            InitializeComponent();
            LoadSuppliers();

            //Binding
            cmbSuppliers.ItemsSource = supplier.GetSuppliers();
        }
        private void LoadSuppliers()            //In case class supplier class fails
        {
            string[] temp = Data.GetSuppliers();
            if (temp != null)
                suppliers = temp;
        }
    }
}

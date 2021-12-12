using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{

    internal class Supplier
    {
        private enum suppliersName
        {
            Adonis, Costco, Euro_Marche, IGA, Maxi, Metro, Provigo, Super_C, Walmart
        }

        private static int numberOfSuppliers = Enum.GetNames(typeof(suppliersName)).Length;         // Enum length
        private List<string> suppliers = new List<string>(numberOfSuppliers);                                                          


        public Supplier()
        {
            PopulateSuppliersList();
        }
        private void PopulateSuppliersList()
        {
            for (int i = 0; i < numberOfSuppliers; i++)
                suppliers.Add(((suppliersName)i).ToString());
        }
        public string[] GetSuppliers()
        {
            suppliers.Insert(0, "");                // "Null value", so it appears an empty option
            return suppliers.ToArray();
        }
    }
}

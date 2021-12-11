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
            Abc, Adonis, Costco, Euro_Marche, IGA, Maxi, Metro, Provigo, Super_C, Walmart
        }

        private static int numberOfSuppliers = Enum.GetNames(typeof(suppliersName)).Length; //Enum length
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
            return suppliers.ToArray();
        }
    }
}

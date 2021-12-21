using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{

    public static class SuppliersList
    {
        private enum suppliers
        {
            Adonis, Costco, Euro_Marche, IGA, Maxi, Metro, Provigo, Super_C, Walmart
        }

        private static List<string> suppliersList = new List<string>();
        private static int numberOfSuppliers = Enum.GetNames(typeof(suppliers)).Length; // Enum length

        public static string[] GetSuppliers() //Converted to arr for binding purposes 
        {
            for (int i = 0; i < numberOfSuppliers; i++)
            {
                suppliersList.Add(((suppliers)i).ToString().Replace('_', ' ')); //each value from enum becomes a string and replace occurences of underscore with space
            }

            suppliersList.Insert(0, ""); //first value is null
            return suppliersList.ToArray();
        }

        //private static int numberOfSuppliers = Enum.GetNames(typeof(suppliersName)).Length; // Enum length
        //private List<string> suppliers = new List<string>();                                                          

        //public SuppliersList()
        //{
        //    PopulateSuppliersList(); //when supplier object created, use the default values
        //}

        //private void PopulateSuppliersList()
        //{
        //    for (int i = 0; i < numberOfSuppliers; i++)
        //    {
        //        suppliers.Add(((suppliersName)i).ToString().Replace('_', ' ')); //each value from enum becomes a string and replace occurences of underscore with space
        //    }
        //}
        //public string[] GetSuppliers()
        //{
        //    suppliers.Insert(0, ""); //"Null value", so it appears an empty option
        //    return suppliers.ToArray(); //convert list to array
        //}

        //public string[] AddSupplier(string newSupplier) //if the user adds a supplier not in the list
        //{
        //    suppliers.Add(newSupplier); //add new supplier to list
        //    return suppliers.ToArray(); //convert list to array
        //}
    }
}

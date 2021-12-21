using System;
using System.Collections.Generic;

namespace Project.Models
{
    /*
        Names: Jeremy Oroc, Julian Hernandez
        Student IDs: 2034933 (Jeremy), 2093730 (Julian)
        Programming III - Fall 2021
    */
    public static class SuppliersList
    {
        private enum Suppliers
        {
            Adonis, Costco, Euro_Marche, IGA, Maxi, Metro, Provigo, Super_C, Walmart
        }

        private static List<string> suppliersList = new List<string>();                 // Suppliers in an array of strings, to achieve binding
        private static int numberOfSuppliers = Enum.GetNames(typeof(Suppliers)).Length; // Enum length

        public static string[] GetSuppliers() //Converted to arr for binding purposes 
        {
            if(suppliersList.Count == 0)
            {
                for (int i = 0; i < numberOfSuppliers; i++)
                {
                    suppliersList.Add(((Suppliers)i).ToString().Replace('_', ' ')); //each value from enum becomes a string and replace occurences of underscore with space
                }

                suppliersList.Insert(0, ""); //first value is null
            }

            return suppliersList.ToArray();
        }
    }
}

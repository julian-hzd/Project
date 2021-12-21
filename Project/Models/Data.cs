using System;
using System.IO;

namespace Project.Models
{
    /*
        Names: Jeremy Oroc, Julian Hernandez
        Student IDs: 2034933 (Jeremy), 2093730 (Julian)
        Programming III - Fall 2021
    */
    internal static class Data // Static, Utility class, no instances need to be created
    {
        #region FETCHING INFO FROM FILE
        private static string GetSuppliers(string fileName = "../TestFiles/Suppliers.csv") // No need to let these methods public, they are accessed on loadsuppliers
        {
            if (File.Exists(fileName))
            {
                try
                {
                    return File.ReadAllText(fileName);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        private static string GetCategories(string fileName = "../TestFiles/Categories.csv")
        {
            if (File.Exists(fileName))
            {
                try
                {
                    return File.ReadAllText(fileName);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        #endregion
        #region LOADING INFO
        public static string[] LoadSuppliers() //In case supplier class fails, read from Suppliers.csv
        {
            string[] suppliers = GetSuppliers().Split(',');

            if (suppliers != null)
                return suppliers;

            return null;
        }
        public static string[] LoadCategories() //In case category class fails, read from Categories.csv
        {
            string[] categories = GetCategories().Split(',');

            if (categories != null)
                return categories;

            return null;
        }
        #endregion
    }
}

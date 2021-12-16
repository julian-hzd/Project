using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project.Models
{
    internal static class Data                                                      // Static, Utility class, no instances need to be created
    {
        private static string GetSuppliers(string fileName = "./Suppliers.txt")     // No need to let these methods public, they are accessed on loadsuppliers
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
        private static string GetCategories(string fileName = "./Categories.txt")
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
        public static string[] LoadSuppliers()            // In case class supplier class fails, read from file at . level to get suplpiers
        {
            string[] suppliers = Data.GetSuppliers().Split(',');
            if (suppliers != null)
                return suppliers;
            return null;
        }
        public static string[] LoadCategories()            // In case class supplier class fails, read from file at . level to get suplpiers
        {
            string[] categories = Data.GetCategories().Split(',');
            if (categories != null)
                return categories;
            return null;

        }
    }
}

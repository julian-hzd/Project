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
        public static string GetSuppliers(string fileName = "./Suppliers.txt")
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
        public static string GetCategories(string fileName = "./Categories.txt")
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
    }
}

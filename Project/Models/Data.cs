using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project.Models
{
    internal class Data
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
    }
}

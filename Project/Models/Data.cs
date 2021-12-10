﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project.Models
{
    internal class Data
    {
        public static string[] GetSuppliers(string fileName = "./Countries.txt")
        {
            if (File.Exists(fileName))
            {
                try
                {
                    return File.ReadAllLines(fileName);
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

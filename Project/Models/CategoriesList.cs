using System;
using System.Collections.Generic;

namespace Project.Models
{
    public static class CategoriesList
    {
        private enum Categories
        {
           Pantry, Diary, Drinks, Frozen, Food, Fruits_and_Vegetables, Bakery, Cleaning_Supplies, Other
        }

        private static List<string> categoriesList = new List<string>();
        private static int numberOfCategories = Enum.GetNames(typeof(Categories)).Length; // Enum length

        public static string[] GetCategories() //Converted to arr for binding purposes 
        {
            for (int i = 0; i < numberOfCategories; i++)
            {
                categoriesList.Add(((Categories)i).ToString().Replace('_', ' ')); //each value from enum becomes a string and replace occurences of underscore with space
            }

            categoriesList.Insert(0, ""); //first value is null
            return categoriesList.ToArray();
        }
    }
}

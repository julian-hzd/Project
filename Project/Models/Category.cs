using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    internal class Category
    {
        private enum _categories
        {
            Pantry, Diary, Drinks, Frozen, Food,
            Fruit_and_Vegetable, Bakery, Cleaning_Supplies, Other
        }
        public static string[] CategoryInArr()
        {            
            var valuesAsArray = Enum.GetNames(typeof(_categories));
            return valuesAsArray;
        }
    }
}

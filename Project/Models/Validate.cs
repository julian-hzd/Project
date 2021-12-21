namespace Project.Models
{
    public static class Validate
    {
        public static string Message { get; set; }
        #region PUBLIC METHODS
        public static bool ValidateItemName(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                Message = "Name is a required field";
                return true;
            }
            else if (!ValidateString(itemName))
            {
                Message = "Name can only contain letters";
                return true;
            }
            return false;
        }
        public static bool ValidateAvailableQuantity(string quantity)
        {
            if (string.IsNullOrEmpty(quantity))
            {
                Message = "Available Quantity is a required field";
                return true;
            }
            else if (ValidateNumber(quantity))
            {
                Message = "Available Quantity must be a number";
                return true;
            }
            else if (CheckNegativeNumber(quantity))
            {
                Message = "Available Quantity can't be negative";
                return true;
            }

            return false;
        }
        public static bool ValidateMinimumQuantity(string quantity)
        {
            if (quantity == string.Empty)
                return false;

            else
            {
                if (ValidateNumber(quantity))
                {
                    Message = "Minimum Quantity must be a number";
                    return true;
                }
                else if (CheckNegativeNumber(quantity))
                {
                    Message = "Minimum Quantity can't be negative";
                    return true;
                }
                else if (ValidateMinQty(quantity))
                {
                    Message = "Minimum Quantity can't be less than 1";
                    return true;
                }
            }
            
            return false;
        }
        #endregion
        #region PRIVATE METHODS
        private static bool ValidateString(string string_)  // "Eg2gs" is not valid
        {
            foreach (char letter in string_)
            {
                if (!char.IsLetter(letter))
                {
                    if (letter == ' ')
                        return true;

                    return false;
                }
            }
            return true;
        }
        private static bool ValidateNumber(string number)
        {
            if (int.TryParse(number, out _)) //if number is integer
                return false;

            return true;
        }
        private static bool CheckNegativeNumber(string number)
        {
            if (int.Parse(number) < 0) //if number is negative
                return true;

            return false;
        }
        private static bool ValidateMinQty(string number)
        {
            if (int.Parse(number) > 0)
                return false;

            return true;
        }
        #endregion
    }
}

using System;
using System.Text.RegularExpressions;

namespace BookStore.Helper
{
    public static class PrimitiveHelper
    {
        public static string ReadString(string caption, bool allowIsNullOrEmpty = false)
        {
            string income;

            string regex = "^[a-zA-Z\\s]*$";
        l1:
            ColorChange.ColorChangeToGreen(caption);

            income = Console.ReadLine();


            if (allowIsNullOrEmpty == false && string.IsNullOrWhiteSpace(income))
            {
                ColorChange.ColorChangeToRed("Enter text please.");
                goto l1;
            }

            if (Regex.IsMatch(income, regex) == false)
            {
                ColorChange.ColorChangeToRed("Enter only text characters.");
                goto l1;
            }

            return income;
        }

        public static int ReadInt(string caption, int min = 0, int max = 0)
        {
            string? income;
        l1:
            if (max == min && max == 0)
            {
                ColorChange.ColorChangeToRed("Press 0 to return to main menu.");
                income = Console.ReadLine();
                if(int.TryParse(income,out int value2) == false)
                {
                    ColorChange.ColorChangeToRed("Enter digits only.");
                    goto l1;
                }
                if (value2 != 0)
                {
                   ColorChange.ColorChangeToRed("It is not 0.");
                    goto l1;
                }
            }
            else
            {
                ColorChange.ColorChangeToGreen($"{caption}");
                income = Console.ReadLine();
            }

            if(int.TryParse(income,out int value) == false)
            {
                ColorChange.ColorChangeToRed("Enter digits only.");
                goto l1;
            }

            if(value>max||value<min)
            {
                ColorChange.ColorChangeToRed($"Please enter a number between {min}-{max}");
                goto l1;
            }

            return value;
        }

        public static decimal ReadDecimal(string caption, decimal min = 0m, decimal max = 0m)
        {
            string? income;
        l1:
            if (max == min && max == 0m)
            {
                ColorChange.ColorChangeToRed("Press 0 to return to main menu.");
                income = Console.ReadLine();
                if (decimal.TryParse(income, out decimal value2) == false)
                {
                    ColorChange.ColorChangeToRed("Enter digits only.");
                    goto l1;
                }
                if (value2 != 0)
                {
                    ColorChange.ColorChangeToRed("It is not 0.");
                    goto l1;
                }
            }
            else
            {
                ColorChange.ColorChangeToGreen($"{caption}");
                income = Console.ReadLine();
            }

            if (decimal.TryParse(income, out decimal value) == false)
            {
                ColorChange.ColorChangeToRed("Enter digits only.");
                goto l1;
            }

            if (value > max || value < min)
            {
                ColorChange.ColorChangeToRed($"Please enter a number between {min}-{max}");
                goto l1;
            }

            return value;
        }
    }
}


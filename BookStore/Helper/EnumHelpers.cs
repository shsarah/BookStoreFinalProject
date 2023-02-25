using System;
namespace BookStore.Helper
{
    public static class EnumHelpers
    {
        public static T ReadEnum<T>(string caption)
            where T : Enum
        {
            var menu = Enum.GetValues(typeof(T));

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                Type uType = Enum.GetUnderlyingType(typeof(T));
                object? id = Convert.ChangeType(item, uType);
                Console.WriteLine($"{id.ToString().PadLeft(2, ' ')}. {item} ");
            }

            string? income;
        l1:
            ColorChange.ColorChangeToGreen(caption);

            income = Console.ReadLine();

            if (Enum.TryParse(typeof(T), income, out object? value)==false) 
            {
                ColorChange.ColorChangeToRed("Contains text characters, try again.");
                goto l1;
            }

            if(Enum.IsDefined(typeof(T), value) == false)
            {
                ColorChange.ColorChangeToRed("Number is not defined,try again.");
                goto l1;
            }


            return (T)value;

        }
    }
}


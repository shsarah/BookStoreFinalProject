using System;
namespace BookStore.Helper
{
    public static class ColorChange
    {
		public static void ColorChangeToRed(string caption)
		{
			var oldColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(caption);
			Console.ForegroundColor = oldColor;
		}

        public static void ColorChangeToGreen(string caption)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(caption);
            Console.ForegroundColor = oldColor;
        }
    }
}


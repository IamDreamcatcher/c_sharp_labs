using System;
using System.Globalization;

namespace Task8
{
    public class Reader
    {
        public static CultureInfo ReadCulture()
        {
            CultureInfo culture;
            Console.WriteLine("Enter culture:");
            while (true)
            {
                string inputCulture = Console.ReadLine();
                try
                {
                    culture = CultureInfo.CreateSpecificCulture(inputCulture);
                    return culture;
                }
                catch (CultureNotFoundException)
                {
                    Console.WriteLine("Wrong format, enter the correct cultute.");
                }
            }
        }
    }
}

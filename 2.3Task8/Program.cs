using System;
using System.Globalization;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture =  Reader.ReadCulture();
            DateTime someDate = new DateTime();
            for (int index = 0; index < 12; index++)
            {
                Console.WriteLine(someDate.AddMonths(index).ToString("MMMM", culture));
            }
        }
    }
}
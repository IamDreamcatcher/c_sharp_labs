using System;

namespace Task4
{
    class Program
    {
        static ulong Solve(ulong number)
        {
            ulong amount = 0;
            ulong pow = 2;
            for (int i = 1; i < 64; i++)
            {
                amount += number / pow;
                pow *= 2;
            }
            return amount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first natural number:");
            ulong a = Reader.ReadUlong();
            Console.WriteLine("Enter second natural number:");
            ulong b = Reader.ReadUlong();
            while (b < a)
            {
                Console.WriteLine("The first number must be less than the second!");
                b = Reader.ReadUlong();
            }
            Console.WriteLine("Answer is: {0}", Solve(b) - Solve(a - 1));
        }
    }
}
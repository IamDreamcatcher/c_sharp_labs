using System;
using System.Runtime.InteropServices;

namespace UnmanagedCode
{
    class Program
    {
        [DllImport("ArrayLib.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int SumOfArray(int[] a, int size);

        [DllImport("ArrayLib.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int MaxInArray(int[] a, int size);

        [DllImport("ArrayLib.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int MinInArray(int[] a, int size);

        [DllImport("ArrayLib.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Average(int[] a, int size);
        static void Main(string[] args)
        {
            int[] myArray = new int[] { 10, 20, 30, 40, 50};
            Console.WriteLine("Sum of Array: {0}", SumOfArray(myArray, 5));
            Console.WriteLine("Min in Array: {0}", MinInArray(myArray, 5));
            Console.WriteLine("Max in Array: {0}", MaxInArray(myArray, 5));
            Console.WriteLine("Average in Array: {0}", Average(myArray, 5));

        }
    }
}

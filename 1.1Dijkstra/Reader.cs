using System;
using System.Collections.Generic;

namespace Dijkstra
{
    public class Reader
    {
        public static int ReadInt()
        {
            int numberOfRoutes;
            while (!int.TryParse(Console.ReadLine(), out numberOfRoutes)
                || numberOfRoutes < 1 || numberOfRoutes > 100000)
            {
                Console.Write("Wrong format, enter the correct number.\n");
            }
            return numberOfRoutes;
        }
        public static City ReadName(HashSet<string> cities)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (cities.Contains(input))
                {
                    return new City(input);
                }
                Console.Write("Wrong format, enter the correct city:\n");
            }
        }
        public static Road[] ReadArray(int length, HashSet<string> cities)
        {
            Road[] roads = new Road[length];
            for (int index = 0; index < length; index++)
            {
                while (true)
                {
                    string[] input = Console.ReadLine().Split(' ');
                    int cost;
                    if (input.Length == 3 && int.TryParse(input[2], out cost) && cost > 0 && cost < 100000)
                    {
                        City firstCity = new City(input[0]);
                        City secondCity = new City(input[1]);
                        roads[index] = new Road(firstCity, secondCity, cost);
                        if (!cities.Contains(input[0]))
                        {
                            cities.Add(input[0]);
                        }
                        if (!cities.Contains(input[1]))
                        {
                            cities.Add(input[1]);
                        }
                        break;
                    }
                    Console.Write("Wrong format, enter correct route\n");
                }
            }
            return roads;
        }
    }
}

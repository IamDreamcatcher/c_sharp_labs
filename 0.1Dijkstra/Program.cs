using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter the number of routes:\n");
            int NumberOfRoutes = Reader.ReadInt();
            Console.Write("Enter info about routes in format: start finish cost\n");
            HashSet<string> cities = new HashSet<string>();
            Road[] roads = Reader.ReadArray(NumberOfRoutes, cities);
            int numberOfCities = cities.Count;
            Dictionary<City, List<Road>> edges = new Dictionary<City, List<Road>>();
            for (int i = 0; i < NumberOfRoutes; i++) {
                if (!edges.ContainsKey(roads[i].firstCity)) {
                    edges.Add(roads[i].firstCity, new List<Road>());
                }
                edges[roads[i].firstCity].Add(roads[i]);
            }

            Console.Write("Enter the name of the starting point:\n");
            City startCity = Reader.ReadName(cities);
            Console.Write("Enter the name of the finishing point:\n");
            City finishCity = Reader.ReadName(cities);

            SortedSet<Tuple<int, City>> q = new SortedSet<Tuple<int, City>>(new DistanceComparer());
            HashSet<City> marks = new HashSet<City>();
            Dictionary<City, int> distance = new Dictionary<City, int>();
            Dictionary<City, City> ancestor = new Dictionary<City, City>();
            q.Add(new Tuple<int, City>(0, startCity));
            distance.Add(startCity, 0);

            while (q.Count != 0) {
                while (q.Count != 0 && marks.Contains(q.First().Item2)) {
                    q.Remove(q.First());
                }
                if (q.Count == 0) {
                    break;
                }
                Tuple<int, City> current = q.First();
                marks.Add(current.Item2);
                q.Remove(q.First());

                if (!edges.ContainsKey(current.Item2)) {
                    continue;
                }
                for (int i = 0; i < edges[current.Item2].Count; i++) {
                    int weight = edges[current.Item2][i].cost;
                    City to = edges[current.Item2][i].secondCity;
                    if (!distance.ContainsKey(to)) {
                        distance.Add(to, (int)2e9);
                    } 

                    if (distance[to] > distance[current.Item2] + weight) {
                        if (q.Contains(new Tuple<int, City>(distance[to], to))) {
                            q.Remove(new Tuple<int, City>(distance[to], to));
                        }
                        distance[to] = distance[current.Item2] + weight;
                        ancestor[to] = current.Item2;
                        q.Add(new Tuple<int, City>(distance[to], to));
                    }
                }
            }

            if (!distance.ContainsKey(finishCity)) {
                Console.WriteLine("The way does not exist");
                Console.WriteLine("Press any key to exit");
                Console.Read();
                Environment.Exit(0);
            }

            int totalCost = distance[finishCity];
            List<string> answer = new List<string>();
            while (finishCity != startCity) {
                answer.Add(finishCity.name);
                finishCity = ancestor[finishCity];
            }
            answer.Add(finishCity.name);
            answer.Reverse();

            Console.WriteLine("The cheapest way:");
            foreach (string currentCity in answer) {
                Console.WriteLine("{0}", currentCity);
            }
            Console.WriteLine("Total cost:{0}",totalCost);
            Console.Write("Press any key to exit");
            Console.Read();
            Environment.Exit(0);
        }
    }
}

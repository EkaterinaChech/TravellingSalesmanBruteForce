using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace The_travelling_salesman
{
    public class BruteForce
    {
        /// <summary>
        /// Best (the lightest) way
        /// </summary>
        private Way bestWay = new Way();

        /// <summary>
        /// Compares parameter way and best way. Changes best way if needed.
        /// </summary>
        /// <param name="newWay"></param>
        public void AppendBestWay(Way newWay)
        {
            if (bestWay.GetWeight() > newWay.CountWeight())
            {
                bestWay.path = newWay.path;
                bestWay.CountWeight();
                //bestWay.FullPrint();            //Prints best way if it was appended
            }
        }

        /// <summary>
        /// Main recursive brute Force method. Iterates over all possible paths.
        /// </summary>
        /// <param name="param">Indicator for recursion</param>
        /// <param name="list">List of visited nodes</param>
        public void Generate(int param, ref List<int> list)
        {
            if (param == Properties.CityCount - 1) //if we visited all cities
            {
                Way way = new Way(true);
                way.path.Add(0);

                for (int i = 1; i < Properties.CityCount; i++)
                {
                    way.path.Add(list[i]);
                }

                way.path.Add(0);
                AppendBestWay(way);
            }
            else
            {
                //if there is some possible movements
                for (int j = param + 1; j < Properties.CityCount; j++)
                {
                    Swap(param + 1, j, ref list);
                    Generate(param + 1, ref list);
                    Swap(param + 1, j, ref list);
                }
            }
        }

        /// <summary>
        /// Main recursive brute Force method but optimized. Iterates over all possible paths.
        /// Saves time on adding new elements in list and appending best way.
        /// </summary>
        /// <param name="param">Indicator for recursion</param>
        /// <param name="list">List of visited nodes</param>
        public void GenerateWithOptimization(int param, ref List<int> list)
        {
            if (param == Properties.CityCount - 1) //if we visited all cities
            {
                Way way = new Way(true);
                way.path.Add(0);
                for (int i = 1; i < Properties.CityCount; i++)
                {
                    way.path.Add(list[i]);
                    if (i % 5 == 0 && way.CountWeight() > bestWay.GetWeight())
                        return;
                }

                way.path.Add(0);
                AppendBestWay(way);
            }
            else
            {
                //if there is some possible movements
                for (int j = param + 1; j < Properties.CityCount; j++)
                {
                    Swap(param + 1, j, ref list);
                    GenerateWithOptimization(param + 1, ref list);
                    Swap(param + 1, j, ref list);
                }
            }
        }

        /// <summary>
        /// Swaps two elements in list
        /// </summary>
        /// <param name="a">First element</param>
        /// <param name="b">Second element</param>
        /// <param name="list">List in which we swap elements</param>
        public void Swap(int a, int b, ref List<int> list)
        {
            int t = list[a];
            list[a] = list[b];
            list[b] = t;
        }

        /// <summary>
        /// Main running method. Compares two methods: without and with optimization.
        /// </summary>
        public void Run()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Properties.CityCount; i++) //our first path: from 0 to CityCount
            {
                list.Add(i);
            }

            DateTime start1 = DateTime.Now;
            Generate(0, ref list);
            TimeSpan finish1 = DateTime.Now - start1; //time of method without optimization

            bestWay.path.Clear();
            bestWay.ClearWeight();
            list.Clear();
            for (int i = 0; i < Properties.CityCount; i++) //return our list to initial state
            {
                list.Add(i);
            }

            bestWay = new Way();
            Console.WriteLine("-----------------------------------------------------------");

            DateTime start2 = DateTime.Now;
            GenerateWithOptimization(0, ref list);
            TimeSpan finish2 = DateTime.Now - start2; //time of method with optimization

            Console.WriteLine("Best way:");
            bestWay.FullPrint();
            Console.WriteLine();
            Console.WriteLine($"Time spent on Program without optimization\t = {finish1.TotalMilliseconds} ms");
            Console.WriteLine($"Time spent on Program with optimization\t\t = {finish2.TotalMilliseconds} ms");
        }
    }
}
using System;
using System.Collections.Generic;

namespace The_travelling_salesman
{
    /// <summary>
    /// Represents convenient container to keep path
    /// </summary>
    public class Way
    {
        /// <summary>
        /// List of visited nodes
        /// </summary>
        public List<int> path;

        /// <summary>
        /// Weight of path
        /// </summary>
        private int weight = 0;

        /// <summary>
        /// Generates random Hamiltonian cycle 
        /// </summary>
        /// <param name="count">Count of Nodes(cities)</param>
        public void Generate(int count)
        {
            Random rand = new Random();
            path[0] = 0;
            path[count] = 0;
            for (int i = 1; i < count; i++)
            {
                int index = rand.Next(Properties.CityCount) + 1;
                while (path[index] != -1)
                {
                    index = rand.Next(Properties.CityCount) + 1;
                }

                path[index] = i;
            }

            CountWeight();
        }

        /// <summary>
        /// Prints path with it's weight
        /// </summary>
        public void FullPrint()
        {
            Console.WriteLine($"[{GetWeight()}]    {GetStringPath()}");
        }

        /// <summary>
        /// Counts full weight of the way
        /// </summary>
        public int CountWeight()
        {
            weight = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                int mock = Properties.Matrix[path[i], path[i + 1]];
                weight += mock;
            }

            return weight;
        }

        /// <summary>
        /// Returns string with full path
        /// </summary>
        /// <returns></returns>
        public string GetStringPath()
        {
            string str = "";
            foreach (var i in path)
            {
                str += $"{i} ";
            }

            return str;
        }

        /// <summary>
        /// Returns weight
        /// </summary>
        /// <returns></returns>
        public int GetWeight()
        {
            return weight;
        }

        /// <summary>
        /// Prints path in console
        /// </summary>
        public void PrintPath()
        {
            foreach (int i in path)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        /// <summary>
        /// Clears weight
        /// </summary>
        public void ClearWeight()
        {
            weight = 0;
        }

        /// <summary>
        /// Constructor. Creates empty way
        /// </summary>
        /// <param name="flag">Mock that indicates that we need to create empty way</param>
        public Way(bool flag)
        {
            path = new List<int>();
            weight = 0;
        }

        /// <summary>
        /// Constructor. Creates randomly generated way.
        /// </summary>
        public Way()
        {
            path = new List<int>();
            for (int i = 0; i < Properties.CityCount + 1; i++)
                path.Add(-1);
            Generate(Properties.CityCount);
        }

        /// <summary>
        /// Constructor. Creates path according to List and counts it's weight
        /// </summary>
        /// <param name="path">List of visited nodes(cities)</param>
        public Way(List<int> path)
        {
            this.path = new List<int>();
            foreach (var p in path)
            {
                this.path.Add(p);
            }

            CountWeight();
        }
    }
}
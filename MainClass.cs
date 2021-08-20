using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_travelling_salesman
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Brute Force Method.");
            BruteForce b = new BruteForce();
            b.Run();
        }
    }
}
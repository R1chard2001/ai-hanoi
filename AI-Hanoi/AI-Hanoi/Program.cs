using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DepthFirst d = new DepthFirst(3);
            d.Solve();
            Console.WriteLine("Steps: {0}", d.Path.Depth);
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine();
            BreadthFirst b = new BreadthFirst(3);
            b.Solve();
            Console.WriteLine("Steps: {0}", b.Path.Depth);

            Console.ReadLine();
        }
    }
}

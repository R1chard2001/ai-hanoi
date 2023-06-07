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
            ASolver s = new TrialAndError();
            s.Solve();
            Console.ReadLine();
        }
    }
}

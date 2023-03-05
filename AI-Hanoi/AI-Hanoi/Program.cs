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
            State state = new State(3);
            Console.WriteLine(state);
            do
            {
                int from = getInput("From: ");
                int to = getInput("To: ");
                Operator o = new Operator(from - 1, to - 1);
                Console.WriteLine("--------------------");
                if (o.IsAplicable(state))
                {
                    state = o.Apply(state);
                    Console.WriteLine(state);
                }
                else
                {
                    Console.WriteLine("The given operator is not aplicable.");
                    Console.WriteLine("--------------------");
                    Console.WriteLine(state);
                }
            } while (!state.IsTargetState());
            Console.WriteLine("+--------------------+");
            Console.WriteLine("|  Congratulations!  |");
            Console.WriteLine("+--------------------+");
            Console.ReadLine();
        }
        private static int getInput(string s = "")
        {
            int i;
            while (true)
            {
                Console.Write("From: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out i))
                    return i;
                Console.WriteLine("Incorrect input!");
            }
        }
    }
}

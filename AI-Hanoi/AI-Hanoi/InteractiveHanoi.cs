using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal static class InteractiveHanoi
    {
        public static void main()
        {
            State state = new State(3);
            Console.WriteLine(state);
            string input;
            do
            {
                int from;
                int to;
                while (true)
                {
                    Console.Write("From: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out from))
                        break;
                    Console.WriteLine("Incorrect input!");
                }
                while (true)
                {
                    Console.Write("To: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out to))
                        break;
                    Console.WriteLine("Incorrect input!");
                }
                Operator o = new Operator(from - 1, to - 1);
                Console.WriteLine("--------------------");
                if (o.IsApplicable(state))
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
        }
    }
}

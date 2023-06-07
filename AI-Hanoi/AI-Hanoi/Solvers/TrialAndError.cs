using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class TrialAndError : ASolver
    {
        private Random random = new Random();
        public State CurrentState;

        public TrialAndError() : base()
        {
        }
        private int[] getRandomIndexArray()
        {
            List<int> result = new List<int>();
            while (result.Count < Operators.Count)
            {
                int number;
                do
                {
                    number = random.Next(Operators.Count);
                } while (result.Contains(number));
                result.Add(number);
            }
            return result.ToArray();
        }

        public override Operator SelectOperator()
        {
            int[] indexArray = getRandomIndexArray();
            foreach (int index in indexArray)
            {
                if (Operators[index].IsApplicable(CurrentState))
                {
                    return Operators[index];
                }
            }
            throw new Exception("Dead end");
        }
        public override void Solve()
        {
            int step = 0;
            CurrentState = new State();
            Console.WriteLine("Step {0}", step++);
            Console.WriteLine(CurrentState);
            while (!CurrentState.IsTargetState())
            {
                Operator o = SelectOperator();
                CurrentState = o.Apply(CurrentState);
                Console.WriteLine("-----------------");
                Console.WriteLine("Step {0}", step++);
                Console.WriteLine(CurrentState);
            }
        }
    }
}

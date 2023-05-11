using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class TrialAndErrorWithRestart : ASolver
    {
        private Random random = new Random();
        public State StartState;
        public State CurrentState;
        public int MaxRestarts;
        public TrialAndErrorWithRestart(int numberOfDisks, int maxRestarts) : base()
        {
            StartState = new State(numberOfDisks);
            MaxRestarts = maxRestarts;
        }
        public override Operator SelectOperator()
        {
            List<int> indexList = GetRandomIndexList();
            foreach (int index in indexList)
            {
                if (Operators[index].IsApplicable(CurrentState))
                {
                    return Operators[index];
                }
            }
            return null;
        }
        private List<int> GetRandomIndexList()
        {
            List<int> indexList = new List<int>();
            do
            {
                int index = random.Next(Operators.Count);
                while (indexList.Contains(index))
                {
                    index = random.Next(Operators.Count);
                }
                indexList.Add(index);
            } while (indexList.Count < Operators.Count);
            return indexList;
        }
        public override void Solve()
        {
            int step = 0;
            int currentRestarts = 0;
            CurrentState = (State)StartState.Clone();
            Console.WriteLine("Step {0}", step++);
            Console.WriteLine(CurrentState);
            while (currentRestarts < MaxRestarts && !CurrentState.IsTargetState())
            {
                Operator o = SelectOperator();
                if (o == null)
                {
                    currentRestarts++;
                    step = 0;
                    CurrentState = (State)StartState.Clone();
                    Console.WriteLine("+----------------------------+");
                    Console.WriteLine("| Dead end found, restarting |");
                    Console.WriteLine("+----------------------------+\n");
                }
                else
                {
                    CurrentState = o.Apply(CurrentState);
                }
                Console.WriteLine("-----------------");
                Console.WriteLine("Step {0}", step++);
                Console.WriteLine(CurrentState);
            }
            if (CurrentState.IsTargetState())
                Console.WriteLine("Solved");
            else
                Console.WriteLine("Failed to solve");
        }
    }
}

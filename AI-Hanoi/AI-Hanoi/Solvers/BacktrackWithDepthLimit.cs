using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class BacktrackWithDepthLimit : ASolver
    {
        public int NumberOfDiscs;
        public int DepthLimit;
        public BacktrackWithDepthLimit(int numberOfDiscs, int depthLimit)
        {
            NumberOfDiscs = numberOfDiscs;
            DepthLimit = depthLimit;
        }
        public Node CurrentNode;
        public override Operator SelectOperator()
        {
            int index = CurrentNode.OperatorIndex++;
            while (index < Operators.Count)
            {
                if (Operators[index].IsAplicable(CurrentNode.State))
                {
                    return Operators[index];
                }
                index = CurrentNode.OperatorIndex++;
            }
            return null;
        }

        public override void Solve()
        {
            CurrentNode = new Node(new State(NumberOfDiscs));
            while (CurrentNode != null && !CurrentNode.IsTargetNode())
            {
                if (CurrentNode.Depth >= DepthLimit)
                {
                    CurrentNode = CurrentNode.Parent;
                }
                Operator so = SelectOperator();
                if (so != null)
                {
                    State newState = so.Apply(CurrentNode.State);
                    CurrentNode = new Node(newState, CurrentNode);
                }
                else
                {
                    CurrentNode = CurrentNode.Parent;
                }
            }
            if (CurrentNode == null)
            {
                Console.WriteLine("Cannot solve!");
            }
            else
            {
                Console.WriteLine("Solved:");
                Console.WriteLine(CurrentNode);
            }
        }
    }
}

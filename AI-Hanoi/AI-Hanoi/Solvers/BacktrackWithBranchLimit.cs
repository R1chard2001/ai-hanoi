using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class BacktrackWithBranchLimit : ASolver
    {
        public int NumberOfDiscs;
        public int DepthLimit;
        public BacktrackWithBranchLimit(int numberOfDiscs, int depthLimit)
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
        public Node Path;
        private void CheckCurrentNode()
        {
            if (CurrentNode.IsTargetNode())
            {
                if (Path == null || Path.Depth > CurrentNode.Depth)
                {
                    Path = CurrentNode;
                    currentDepthLimit = Path.Depth;
                    CurrentNode = CurrentNode.Parent;
                }
            }
        }
        private int currentDepthLimit;
        public override void Solve()
        {
            currentDepthLimit = DepthLimit;
            Path = null;
            CurrentNode = new Node(new State(NumberOfDiscs));
            while (CurrentNode != null)
            {
                if (CurrentNode.HasLoop() ||
                    CurrentNode.Depth >= currentDepthLimit)
                {
                    CurrentNode = CurrentNode.Parent;
                    continue;
                }
                Operator so = SelectOperator();
                if (so != null)
                {
                    State newState = so.Apply(CurrentNode.State);
                    CurrentNode = new Node(newState, CurrentNode);
                    CheckCurrentNode();
                }
                else
                {
                    CurrentNode = CurrentNode.Parent;
                }
            }
            if (Path == null)
            {
                Console.WriteLine("Cannot solve!");
            }
            else
            {
                Console.WriteLine("Solved:");
                Console.WriteLine(Path);
            }
        }
    }
}

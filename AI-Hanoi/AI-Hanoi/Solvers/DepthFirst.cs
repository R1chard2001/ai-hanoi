using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class DepthFirst : ASolver
    {
        public Stack<Node> OpenNodes = new Stack<Node>();
        public List<Node> ClosedNodes = new List<Node>();
        public int NumberOfDiscs;
        public DepthFirst(int numberOfDiscs) : base()
        {
            NumberOfDiscs = numberOfDiscs;
        }
        public override Operator SelectOperator()
        {
            int index = CurrentNode.OperatorIndex++;
            while (index < Operators.Count)
            {
                if (Operators[index].IsApplicable(CurrentNode.State))
                {
                    return Operators[index];
                }
                index = CurrentNode.OperatorIndex++;
            }
            return null;
        }
        Node CurrentNode;
        public Node Path;

        public override void Solve()
        {
            OpenNodes.Clear();
            ClosedNodes.Clear();
            Path = null;
            OpenNodes.Push(new Node(new State(NumberOfDiscs)));
            while (0 < OpenNodes.Count)
            {
                CurrentNode = OpenNodes.Pop();
                ClosedNodes.Add(CurrentNode);
                Operator selectedOperator = SelectOperator();
                while (selectedOperator != null)
                {
                    State newState = selectedOperator.Apply(CurrentNode.State);
                    Node newNode = new Node(newState, CurrentNode);
                    if (newNode.IsTargetNode())
                    {
                        Path = newNode;
                        break;
                    }
                    if (!OpenNodes.Contains(newNode) && !ClosedNodes.Contains(newNode))
                    {
                        OpenNodes.Push(newNode);
                    }
                    selectedOperator = SelectOperator();
                }
                
            }
            if (Path != null)
            {
                Console.WriteLine("Found a path to targetstate.");
                Console.WriteLine("----------------------------");
                Console.WriteLine(Path);
            }
            else
            {
                Console.WriteLine("Cant solve the problem!");
            }
        }
    }
}

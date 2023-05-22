using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class BreadthFirst : ASolver
    {
        public Queue<Node> OpenNodes = new Queue<Node>();
        public List<Node> ClosedNodes = new List<Node>();
        public int NumberOfDiscs;
        public BreadthFirst(int numberOfDiscs) : base()
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
            OpenNodes.Enqueue(new Node(new State(NumberOfDiscs)));
            while (0 < OpenNodes.Count)
            {
                CurrentNode = OpenNodes.Dequeue();
                ClosedNodes.Add(CurrentNode);
                if (CurrentNode.IsTargetNode())
                {
                    Path = CurrentNode;
                    break;
                }
                Operator selectedOperator = SelectOperator();
                while (selectedOperator != null)
                {
                    State newState = selectedOperator.Apply(CurrentNode.State);
                    Node newNode = new Node(newState, CurrentNode);
                    
                    if (!OpenNodes.Contains(newNode) && !ClosedNodes.Contains(newNode))
                    {
                        OpenNodes.Enqueue(newNode);
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

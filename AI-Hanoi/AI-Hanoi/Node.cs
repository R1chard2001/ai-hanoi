using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class Node
    {
        public State State;
        public int Depth;
        public Node Parent;
        public int OperatorIndex;
        public Node(State state, Node parent = null)
        {
            Parent = parent;
            State = state;
            OperatorIndex = 0;
            if (Parent == null)
            {
                Depth = 0;
            }
            else
            {
                Depth = Parent.Depth + 1;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Node)) return false;
            Node other = obj as Node;
            return State.Equals(other.State);
        }
        public bool IsTargetNode()
        {
            return State.IsTargetState();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Parent != null)
            {
                sb.AppendLine(Parent.ToString());
                sb.AppendLine("---------------------");
            }
            sb.Append(State.ToString());
            return sb.ToString();
        }
    }
}

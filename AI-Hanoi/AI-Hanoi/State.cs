using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class State:ICloneable
    {
        public int NumberOfDiscs;
        public int[] Discs;
        public State(int numberOfDiscs)
        {
            this.NumberOfDiscs = numberOfDiscs;
            Discs = new int[numberOfDiscs];
        }

        public object Clone()
        {
            State newState = new State(NumberOfDiscs);
            for (int i = 0; i < NumberOfDiscs; i++)
            {
                newState.Discs[i] = Discs[i];
            }
            return newState;
        }
        public bool IsTargetState()
        {
            foreach (int pole in Discs)
            {
                if (pole != 2)
                {
                    return false;
                }
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder poleA = new StringBuilder("Pole 1: ");
            StringBuilder poleB = new StringBuilder("\nPole 2: ");
            StringBuilder poleC = new StringBuilder("\nPole 3: ");
            for (int i = NumberOfDiscs - 1; i >= 0; i--)
            {
                switch (Discs[i])
                {
                    case 0:
                        poleA.Append($"{i + 1} ");
                        break;
                    case 1:
                        poleB.Append($"{i + 1} ");
                        break;
                    case 2:
                        poleC.Append($"{i + 1} ");
                        break;
                    default:
                        throw new Exception();
                }
            }
            return poleA.Append(poleB).Append(poleC).ToString();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class Operator
    {
        public int From;
        public int To;
        public Operator(int from, int to)
        {
            this.From = from;
            this.To = to;
        }

        public bool IsAplicable(State state)
        {
            return From != To &&
                FromPoleHasAnyDisc(state) && 
                !toPoleHasSmallerDisc(state);
        }
        private int GetFromIndex(State state)
        {
            for (int i = 0; i < state.NumberOfDiscs; i++)
            {
                if (state.Discs[i] == From)
                    return i;
            }
            return -1;
        }
        private bool FromPoleHasAnyDisc(State state)
        {
            return GetFromIndex(state) > -1;
        }
        private bool toPoleHasSmallerDisc(State state)
        {
            for (int i = GetFromIndex(state) - 1; i >= 0; i--)
            {
                if (state.Discs[i] == To)
                {
                    return true;
                }
            }
            return false;
        }
        public State Apply(State state)
        {
            State newState = (State)state.Clone();
            newState.Discs[GetFromIndex(state)] = To;
            return newState;
        }
    }
}

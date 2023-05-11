using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal class Operator
    {
        public int from;
        public int to;
        public Operator(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public bool IsApplicable(State state)
        {
            return from != to &&
                fromPoleHasAnyDisc(state) && 
                !toPoleHasSmallerDisc(state);
        }
        private int getFromIndex(State state)
        {
            for (int i = 0; i < state.NumberOfDiscs; i++)
            {
                if (state.Discs[i] == from)
                    return i;
            }
            return -1;
        }
        private bool fromPoleHasAnyDisc(State state)
        {
            return getFromIndex(state) > -1;
        }
        private bool toPoleHasSmallerDisc(State state)
        {
            for (int i = getFromIndex(state) - 1; i >= 0; i--)
            {
                if (state.Discs[i] == to)
                {
                    return true;
                }
            }
            return false;
        }
        public State Apply(State state)
        {
            State newState = (State)state.Clone();
            newState.Discs[getFromIndex(state)] = to;
            return newState;
        }
    }
}

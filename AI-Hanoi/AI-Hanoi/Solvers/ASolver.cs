using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Hanoi
{
    internal abstract class ASolver
    {
        protected List<Operator> Operators = new List<Operator>();
        private void GenerateOperators()
        {
            // restartos próbahiba teszteléséhez, ha zsákutcába ér, akkor újraindul
            //Operators.Add(new Operator(0, 1));
            //Operators.Add(new Operator(0, 2));

            // előző sorokhoz belerakva a végtelenségig megy, nem indul újra
            //Operators.Add(new Operator(1, 0));
            //Operators.Add(new Operator(1, 2));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != j)
                    {
                        Operators.Add(new Operator(i, j));
                    }
                }
            }
        }
        public ASolver()
        {
            GenerateOperators();
        }
        public abstract Operator SelectOperator();
        public abstract void Solve();
    }
}

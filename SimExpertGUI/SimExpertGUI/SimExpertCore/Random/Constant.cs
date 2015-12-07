using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Constant : SystemRandom
    {
        private double _val;

        public double Val
        {
            get { return _val; }
            set { _val = value; }
        }

        public Constant(double Val)
            : base()
        {
            this.Val = Val;
        }
        public override double NextDouble()
        {
            return _val;
        }
    }
}

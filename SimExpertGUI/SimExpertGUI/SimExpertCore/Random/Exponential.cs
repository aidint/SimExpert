using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Exponential : SystemRandom
    {
        public double Mean { get; private set; }
        public Exponential(double mean)
            : base()
        {
            Mean = mean;
        }

        public Exponential(double mean, int seed)
            : base(seed)
        {
            Mean = mean;
        }

        public override double NextDouble()
        {
            return -Math.Log(1 - random.NextDouble()) * Mean;
        }
    }
}

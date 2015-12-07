using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Uniform : SystemRandom
    {
        public double UpperBound { get; private set; }
        public double LowerBound { get; private set; }
        public Uniform(double lower_bound, double upper_bound)
            : base()
        {
            LowerBound = lower_bound;
            UpperBound = upper_bound;
        }

        public Uniform(double lower_bound, double upper_bound, int seed)
            : base(seed)
        {
            LowerBound = lower_bound;
            UpperBound = upper_bound;
        }

        public override double NextDouble()
        {
            return LowerBound + (UpperBound - LowerBound) * random.NextDouble();
        }
    }
}

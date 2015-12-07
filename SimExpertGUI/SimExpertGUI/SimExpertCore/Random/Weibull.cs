using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Weibull : SystemRandom
    {
        public double Beta { get; private set; }
        public double Alpha { get; private set; }
        public Weibull(double alpha, double beta)
            : base()
        {
            Alpha = alpha;
            Beta = beta;
        }

        public Weibull(double alpha, double beta, int seed)
            : base(seed)
        {
            Alpha = alpha;
            Beta = beta;
        }

        public override double NextDouble()
        {
            return Alpha * Math.Pow(-Math.Log(1 - random.NextDouble()), 1 / Beta);
        }
    }
}

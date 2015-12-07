using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Triangular : SystemRandom
    {
        public double High { get; private set; }
        public double Low { get; private set; }
        public double? Mode { get; private set; }
        public Triangular(double low, double high, double? mode=null)
            : base()
        {
            Low = low;
            High = high;
            Mode = mode;
        }

        public Triangular(double low, double high, int seed, double? mode = null)
            : base(seed)
        {
            Low = low;
            High = high;
            Mode = mode;
        }

        public override double NextDouble()
        {
            var u = random.NextDouble();
            double c = Mode==null? 0.5: ((double)Mode - Low) / (High - Low);
            if (u > c)
                return High + (Low - High) * Math.Sqrt(((1.0 - u) * (1.0 - c)));
            return Low + (High - Low) * Math.Sqrt(u * c);
        }
    }
}

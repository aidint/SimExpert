using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class Cauchy : SystemRandom
    {
        public double X0 { get; private set; }
        public double Gamma { get; private set; }
        public Cauchy(double x0, double gamma)
            : base()
        {
            X0 = x0;
            Gamma = gamma;
        }

        public Cauchy(double x0, double gamma, int seed)
            : base(seed)
        {
            X0 = x0;
            Gamma = gamma;
        }

        public override double NextDouble()
        {
            return X0 + Gamma * Math.Tan(Math.PI * (random.NextDouble() - 0.5));
        }
    }
}

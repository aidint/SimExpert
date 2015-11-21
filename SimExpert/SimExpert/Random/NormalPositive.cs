using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class NormalPositive : SystemRandom
    {
        public double Mu { get; private set; }
        public double Sigma { get; private set; }
        private Normal NormalRand;
        public NormalPositive(double mu, double sigma)
            : base()
        {
            Mu = mu;
            Sigma = sigma;
            NormalRand = new Normal(mu, sigma);
        }

        public NormalPositive(double mu, double sigma, int seed)
            : base(seed)
        {
            Mu = mu;
            Sigma = sigma;
            NormalRand = new Normal(mu, sigma, seed);
        }

        public override double NextDouble()
        {
            double val;
            do
            {
                val = NormalRand.NextDouble();
            } while (val <= 0);
            return val;
        }
    }
}

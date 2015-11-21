using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class LogNormal : SystemRandom
    {
        public double Mu { get; private set; }
        public double Sigma { get; private set; }
        private Normal NormalRand;
        public LogNormal(double mu, double sigma)
            : base()
        {
            Mu = mu;
            Sigma = sigma;
            NormalRand = new Normal(mu, sigma);
        }

        public LogNormal(double mu, double sigma, int seed)
            : base(seed)
        {
            Mu = mu;
            Sigma = sigma;
            NormalRand = new Normal(mu, sigma, seed);
        }

        public override double NextDouble()
        {
            return Math.Exp(NormalRand.NextDouble());
        }
    }
}

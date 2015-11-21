using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class Normal : SystemRandom
    {
        protected static readonly double NormalMagicConst = 4 * Math.Exp(-0.5) / Math.Sqrt(2.0);
        public double Mu { get; private set; }
        public double Sigma { get; private set; }
        public Normal(double mu, double sigma)
            : base()
        {
            Mu = mu;
            Sigma = sigma;
        }

        public Normal(double mu, double sigma, int seed)
            : base(seed)
        {
            Mu = mu;
            Sigma = sigma;
        }

        public override double NextDouble()
        {
            double z, zz, u1, u2;
            do
            {
                u1 = random.NextDouble();
                u2 = 1 - random.NextDouble();
                z = NormalMagicConst * (u1 - 0.5) / u2;
                zz = z * z / 4.0;
            } while (zz > -Math.Log(u2));
            return Mu + z * Sigma;
        }
    }
}

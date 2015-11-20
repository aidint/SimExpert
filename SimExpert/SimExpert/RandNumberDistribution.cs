using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class RandNumberDistribution
    {
        public RandNumberDistribution(int RandomSeed = 0){
            randomSeed = RandomSeed;
            Random = new SystemRandom(randomSeed);
        }
        protected static readonly double NormalMagicConst = 4 * Math.Exp(-0.5) / Math.Sqrt(2.0);
        
        private int randomSeed;
        
        
        protected IRandom Random { get; set; }
        
        public double RandUniform(double a, double b)
        {

            return a + (b - a) * Random.NextDouble();
        }

        public double RandTriangular(double low, double high)
        {
            var u = Random.NextDouble();
            if (u > 0.5)
                return high + (low - high) * Math.Sqrt(((1.0 - u) / 2));
            return low + (high - low) * Math.Sqrt(u / 2);
        }

        public double RandTriangular(double low, double high, double mode)
        {
            var u = Random.NextDouble();
            var c = (mode - low) / (high - low);
            if (u > c)
                return high + (low - high) * Math.Sqrt(((1.0 - u) * (1.0 - c)));
            return low + (high - low) * Math.Sqrt(u * c);
        }

        public double RandExponential(double mean)
        {
            return -Math.Log(1 - Random.NextDouble()) * mean;
        }

        public double RandNormal(double mu, double sigma)
        {
            double z, zz, u1, u2;
            do
            {
                u1 = Random.NextDouble();
                u2 = 1 - Random.NextDouble();
                z = NormalMagicConst * (u1 - 0.5) / u2;
                zz = z * z / 4.0;
            } while (zz > -Math.Log(u2));
            return mu + z * sigma;
        }

        public double RandNormalPositive(double mu, double sigma)
        {
            double val;
            do
            {
                val = RandNormal(mu, sigma);
            } while (val <= 0);
            return val;
        }

        public double RandNormalNegative(double mu, double sigma)
        {
            double val;
            do
            {
                val = RandNormal(mu, sigma);
            } while (val >= 0);
            return val;
        }

        public double RandLogNormal(double mu, double sigma)
        {
            return Math.Exp(RandNormal(mu, sigma));
        }

        public double RandCauchy(double x0, double gamma)
        {
            return x0 + gamma * Math.Tan(Math.PI * (Random.NextDouble() - 0.5));
        }

        public double RandWeibull(double alpha, double beta)
        {
            return alpha * Math.Pow(-Math.Log(1 - Random.NextDouble()), 1 / beta);
        }

        public double RandDiscrete(double[] V, double[] P)
        {
            double r = RandUniform(0, 1);
            double[] prob = new double[V.Length];
            double result = 0;
            for (int i = 0; i < prob.Length; i++ )
            {
                prob[i]=result;
                result += P[i];
            }
            for (int i = 1; i < P.Length; i++)
            {
                if (r < prob[i] && r > prob[i - 1]) return V[i - 1];
            }
            return V[V.Length];
        }
        
    }
}

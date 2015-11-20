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

        public TimeSpan RandUniform(TimeSpan a, TimeSpan b)
        {
            return TimeSpan.FromSeconds(RandUniform(a.TotalSeconds, b.TotalSeconds));
        }

        public double RandTriangular(double low, double high)
        {
            var u = Random.NextDouble();
            if (u > 0.5)
                return high + (low - high) * Math.Sqrt(((1.0 - u) / 2));
            return low + (high - low) * Math.Sqrt(u / 2);
        }

        public TimeSpan RandTriangular(TimeSpan low, TimeSpan high)
        {
            return TimeSpan.FromSeconds(RandTriangular(low.TotalSeconds, high.TotalSeconds));
        }

        public double RandTriangular(double low, double high, double mode)
        {
            var u = Random.NextDouble();
            var c = (mode - low) / (high - low);
            if (u > c)
                return high + (low - high) * Math.Sqrt(((1.0 - u) * (1.0 - c)));
            return low + (high - low) * Math.Sqrt(u * c);
        }

        public TimeSpan RandTriangular(TimeSpan low, TimeSpan high, TimeSpan mode)
        {
            return TimeSpan.FromSeconds(RandTriangular(low.TotalSeconds, high.TotalSeconds, mode.TotalSeconds));
        }

       
        public double RandExponential(double mean)
        {
            return -Math.Log(1 - Random.NextDouble()) * mean;
        }

       
        public TimeSpan RandExponential(TimeSpan mean)
        {
            return TimeSpan.FromSeconds(RandExponential(mean.TotalSeconds));
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

        public TimeSpan RandNormal(TimeSpan mu, TimeSpan sigma)
        {
            return TimeSpan.FromSeconds(RandNormal(mu.TotalSeconds, sigma.TotalSeconds));
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

        public TimeSpan RandNormalPositive(TimeSpan mu, TimeSpan sigma)
        {
            return TimeSpan.FromSeconds(RandNormalPositive(mu.TotalSeconds, sigma.TotalSeconds));
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

        public TimeSpan RandNormalNegative(TimeSpan mu, TimeSpan sigma)
        {
            return TimeSpan.FromSeconds(RandNormalNegative(mu.TotalSeconds, sigma.TotalSeconds));
        }

        public double RandLogNormal(double mu, double sigma)
        {
            return Math.Exp(RandNormal(mu, sigma));
        }

        public TimeSpan RandLogNormal(TimeSpan mu, TimeSpan sigma)
        {
            return TimeSpan.FromSeconds(RandLogNormal(mu.TotalSeconds, sigma.TotalSeconds));
        }

        public double RandCauchy(double x0, double gamma)
        {
            return x0 + gamma * Math.Tan(Math.PI * (Random.NextDouble() - 0.5));
        }

        public TimeSpan RandCauchy(TimeSpan x0, TimeSpan gamma)
        {
            return TimeSpan.FromSeconds(RandCauchy(x0.TotalSeconds, gamma.TotalSeconds));
        }

        public double RandWeibull(double alpha, double beta)
        {
            return alpha * Math.Pow(-Math.Log(1 - Random.NextDouble()), 1 / beta);
        }

        public TimeSpan RandWeibull(TimeSpan mu, TimeSpan sigma)
        {
            return TimeSpan.FromSeconds(RandWeibull(mu.TotalSeconds, sigma.TotalSeconds));
        }

        public int RandDiscrete(List<int> V, List<double> P)
        {
            double r = RandUniform(0, 1);
            List<double> prob = new List<double>();
            double result = 0;
            foreach(double d in P){
                prob.Add(result);
                result += d; 
            }
            for (int i = 1; i < P.Count; i++)
            {
                if (r > prob[i - 1] && r < prob[i]) return V[i - 1];
            }
            return V.Last();
        }
        
    }
}

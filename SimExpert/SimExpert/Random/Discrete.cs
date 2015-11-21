using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class Discrete : SystemRandom
    {
        public List<Tuple<double,double>> Probabilities { get; private set; }
        private Uniform Uni_Rand { get; set; }
        public Discrete(List<double> values, List<double> cumulative_probabilities)
            : base()
        {
            if (values.Count != cumulative_probabilities.Count)
                throw new Exception("Values and Probabilities sizes are different");
            Probabilities = new List<Tuple<double, double>>();
            double last_prob = 0;
            for (int i = 0; i < values.Count; i++)
            {
                if (cumulative_probabilities[i] <= last_prob)
                    throw new Exception("Probabilities are not in correct format");
                Probabilities.Add(new Tuple<double, double>(values[i], cumulative_probabilities[i]));
            }
            Uni_Rand = new Uniform(0, 1);
        }

        public Discrete(List<double> values, List<double> cumulative_probabilities, int seed)
            : base(seed)
        {
            if (values.Count != cumulative_probabilities.Count)
                throw new Exception("Values and Probabilities sizes are different");
            Probabilities = new List<Tuple<double, double>>();
            double last_prob = 0;
            for (int i = 0; i < values.Count; i++)
            {
                if (cumulative_probabilities[i] <= last_prob)
                    throw new Exception("Probabilities are not in correct format");
                Probabilities.Add(new Tuple<double, double>(values[i], cumulative_probabilities[i]));
            }
            Uni_Rand = new Uniform(0, 1,seed);
        }

        public override double NextDouble()
        {
            double r = Uni_Rand.NextDouble();
            for (int i = 0; i < Probabilities.Count; i++)
            {
                if (r < Probabilities[i].Item2)
                    return Probabilities[i].Item1;
            }
            return Probabilities[Probabilities.Count - 1].Item1;
        }
    }
}

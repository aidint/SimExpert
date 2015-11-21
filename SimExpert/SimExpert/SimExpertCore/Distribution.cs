using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Distribution
    {
        private SystemRandom Rand;
        public Distribution(SystemRandom Rand)
        {
            this.Rand = Rand;
        }
        public TimeSpan Next_Time()
        {
            return TimeSpan.FromSeconds(Rand.Next());
        }
    }
}

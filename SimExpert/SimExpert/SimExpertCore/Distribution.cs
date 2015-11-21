using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Distribution
    {
        private int Time;
        public Distribution(int time)
        {
            Time = time;
        }
        public TimeSpan Next_Time()
        {
            return TimeSpan.FromSeconds(Time);
        }
    }
}

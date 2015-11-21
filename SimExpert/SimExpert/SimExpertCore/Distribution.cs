using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Distribution
    {
        public TimeSpan Next_Time()
        {
            return TimeSpan.FromSeconds(1);
        }
    }
}

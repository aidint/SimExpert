using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore
{
    class Enviroment
    {
        private TimeSpan system_Time = new TimeSpan(0, 0, 0);
        public TimeSpan System_Time { get { return system_Time; } set { system_Time = value;} }
    }
}

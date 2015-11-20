using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore
{
    class Enviroment
    {
        private TimeSpan system_Time = new TimeSpan(0);
        public TimeSpan System_Time { get; set; }

        private SimActor Sim_Actors { get; set; }
        public Enviroment(TimeSpan System_Time,SimActor Sim_Actors,)
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Environment
    {
        public DateTime System_Time { get; set; }
        public EventQueue FEL { get; set; }
        public SimActor Sim_Actors { get; set; }
        public Environment()
        {
        }
    }
}

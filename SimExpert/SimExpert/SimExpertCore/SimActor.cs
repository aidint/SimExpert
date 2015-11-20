using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimExpert
{
    public class SimActor
    {
        public Dictionary<Int64,Actor> Sim_Actors { get; set; }
        public Actor getActor(Int64 Id)
        {
            return Sim_Actors[Id];
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimExpert
{
    public class SimActor
    {
        public Create Sim_Create { get; set; }
        public Dispose Sim_Dispose { get; set; }
        public List<Actor> Sim_Actors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore.Actors
{
    class Resource : Actor
    {
        public int Capacity { get; set; }
        public Distribution Activity_Distribution { get; set; }
        public override void Process(EventEx.Type T, Entity E)
        {
            
        }

    }
}

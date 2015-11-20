using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class Resource : Actor
    {
        public Resource(Environment env) : base(env) { }
        public int Capacity { get; set; }
        public Distribution Activity_Distribution { get; set; }
        public override void Process(Event.Type T, Entity E)
        {
            
        }

    }
}

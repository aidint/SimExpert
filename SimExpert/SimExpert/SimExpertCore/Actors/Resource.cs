using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Resource : Actor
    {
        public Resource(Environment env, Int64 Id) : base(env, Id) { }
        public int Capacity { get; set; }
        public Distribution Activity_Distribution { get; set; }
        public override void Process(Event.Type T, Entity E)
        {
            
        }
        public override void GenerateEvent(Entity E)
        {
            throw new NotImplementedException();
        }

    }
}

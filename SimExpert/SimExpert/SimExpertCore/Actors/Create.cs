using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Create : Actor
    {
        public Create(Environment env) : base(env) { }
        public Distribution Create_Distribution { get; set; }
        public override void Process(Event.Type T, Entity E)
        {

        }
    }
}

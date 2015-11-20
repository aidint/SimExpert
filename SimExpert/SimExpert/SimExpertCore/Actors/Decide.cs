using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Decide : Actor
    {
        public Decide(Environment env) : base(env) { }
        public Condition Cond { get; set;}
        public override void Process(Event.Type T, Entity E)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore.Actors
{
    class Decide : Actor
    {
        public Condition.Condition Cond { get; set;}
        public override void Process(EventEx.Type T, Entity E)
        {

        }
    }
}

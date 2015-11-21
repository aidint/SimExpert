using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class EQCond : Condition
    {
        private Actor actor1;
        private Actor actor2;
        private Actor.StateType state;
        public EQCond(Int64 ownerId, Actor actor1, Actor actor2)
        {
            this.actor1 = actor1;
            this.actor2 = actor2;
        }
        public EQCond(Int64 ownerId, Actor actor1, Actor.StateType state)
        {
            this.actor1 = actor1;
            this.state = state;
        }
        public override void exhast()
        {
            base.exhast();
        }

        public override bool eval()
        {
            if (actor2 == null)
            {
                return actor1.State == actor2.State;
            }
            else
            {
                return actor1.State == state;
            }

        }
    }
}

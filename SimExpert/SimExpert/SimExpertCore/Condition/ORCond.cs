using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class ORCond : Condition
    {
        private Condition cond1;
        private Condition cond2;
        public ORCond(Int64 ownerId, Condition cond1, Condition cond2)
        {
            this.cond1 = cond1;
            this.cond2 = cond2;
        }
        public override void exhast()
        {
            base.exhast();
        }

        public override bool eval()
        {
            return cond1.eval() || cond2.eval();
        }
    }
}

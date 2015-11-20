using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore
{
    public abstract class Actor
    {
        public bool Is_Finished { get; set; }
        public bool Is_Busy { get; set; }
        public bool Is_Idle { get { return !Is_Busy;} set{ Is_Busy = !value;} }
        public abstract void Process(EventEx.Type T, Entity E);

    }
}

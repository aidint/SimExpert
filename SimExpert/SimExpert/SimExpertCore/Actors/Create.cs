using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore.Actors
{
    class Create : Actor
    {
        public Distribution Create_Distribution { get; set; }
        public override void Process(EventEx.Type T, Entity E)
        {

        }
    }
}

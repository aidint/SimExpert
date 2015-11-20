using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore.Actors
{
    class Queue : Actor
    {
        public int Capacity { get; set; }
        public int Queue_Length { get; set; }
        public override void Process(EventEx.Type T, Entity E)
        {

        }
    }
}

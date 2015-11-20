using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class Queue : Actor
    {
        public Queue(Environment env) : base(env) { }
        public int Capacity { get; set; }
        public int Queue_Length { get; set; }
        public override void Process(Event.Type T, Entity E)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Entity
    {
        public DateTime Arrival_Time { get; set;}
        public TimeSpan InterArrival_Time { get; set; }
        public TimeSpan Fail_Time { get; set; }
        public TimeSpan Delay { get; set; }
        public Int64 Id { get; set; }
        public DateTime Last_Queue_Time_In { get; set; }
        public DateTime Last_Resource_Time_In { get; set; }
    }
}

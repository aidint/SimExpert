using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class ResourceStatistic
    {
        private double _total_service_time;

        public double TotalServiceTime
        {
            get { return _total_service_time; }
            set { _total_service_time = value; }
        }

        public Int64 ResourceId { get; set; }
        
    }
}

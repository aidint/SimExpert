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
        private Dictionary<Int64, ResourceOtherStatistics[]> _other_statistics = new Dictionary<Int64,ResourceOtherStatistics[]>();

        public Dictionary<Int64, ResourceOtherStatistics[]> OtherStatistics
        {
            get { return _other_statistics; }
            set { _other_statistics = value; }
        }
        public double TotalServiceTime
        {
            get { return _total_service_time; }
            set { _total_service_time = value; }
        }
        public Int64 ResourceId { get; set; }

        private Int64 _total_service_number = 0;

        public Int64 TotalServiceNumber
        {
            get { return _total_service_number; }
            set { _total_service_number = value; }
        }

        
        
    }
}

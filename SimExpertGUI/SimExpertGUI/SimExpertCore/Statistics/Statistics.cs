using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Statistics
    {
        public Statistics()
        {

        }
        public List<StatisticObj> EntityStatistics { get; set; }
        public List<ResourceStatistic> ResourceStatistics { get; set; }
        public List<ResourceStatistic> InventoryStatistics { get; set; }
    }
}

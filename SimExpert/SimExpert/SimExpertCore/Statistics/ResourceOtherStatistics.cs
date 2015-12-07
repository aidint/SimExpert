using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimExpert
{
    public class ResourceOtherStatistics
    {
        private string _statistic_title;

        public string StatisticTitle
        {
            get { return _statistic_title; }
            set { _statistic_title = value; }
        }
        private Object _statistic_value;

        public Object StatisticValue
        {
            get { return _statistic_value; }
            set { _statistic_value = value; }
        }
    }
}

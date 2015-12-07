using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class StatisticObj
    {
        private double _arrival_time;

        public double Arrival
        {
            get { return _arrival_time; }
            set { _arrival_time = value; }
        }

        private double _departure_time;

        public double Departure
        {
            get { return _departure_time; }
            set { _departure_time = value; }
        }

        private double _interarrival;

        public double InterArrival
        {
            get { return _interarrival; }
            set { _interarrival = value; }
        }

        private Int64 _entityId;

        public Int64 EntityId
        {
            get { return _entityId; }
            set { _entityId = value; }
        }

        private Dictionary<Int64,double> _queue_delays = new Dictionary<long,double>();

        public Dictionary<Int64,double> QueueDelays
        {
            get { return _queue_delays; }
            set { _queue_delays = value; }
        }

        public void Add_Queue_Delay(Int64 queueId, double delay)
        {
            if (QueueDelays.ContainsKey(queueId))
                QueueDelays[queueId] += delay;
            else
                QueueDelays.Add(queueId, delay);
        }

        private Dictionary<Int64, double> _resource_delays = new Dictionary<long, double>();

        public Dictionary<Int64, double> ResourceDelays
        {
            get { return _resource_delays; }
            set { _resource_delays = value; }
        }

        public void Add_Resource_Delay(Int64 resourceId, double delay)
        {
            if (ResourceDelays.ContainsKey(resourceId))
                ResourceDelays[resourceId] += delay;
            else
                ResourceDelays.Add(resourceId, delay);
        }


        public double TotalQueueDelay
        {
            get { return QueueDelays.Count==0?0:QueueDelays.Values.Sum(); }
        }

        public double TotalResourceDelay
        {
            get { return ResourceDelays.Count == 0 ? 0 : ResourceDelays.Values.Sum(); }
        }

        public Int64 TestService { get; set; }//Remove Later
    }
}

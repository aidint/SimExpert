using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Resource : Actor
    {
        public Resource(Environment env, Int64 Id, int Capacity, Distribution dist, Queue Queue = null, List<double> CumulativeNext = null)
            : base(env, Id, CumulativeNext)
        { 
            this.Capacity = Capacity;
            this.Activity_Distribution = dist;
            this.Statistics = new ResourceStatistic();
            this.Statistics.ResourceId = this.AID;
            this.Statistics.TotalServiceTime = 0;
            this.RQueue = Queue == null ? new Queue(env, -100, 0) : Queue;
            this.Actor_Type = Actor.AType.Resource;
            this.Env.resource_statistics.Add(this.Statistics);
            
        }
        public ResourceStatistic Statistics { get; set; }
        public int Capacity { get; set; }
        public int Seized { get; set; }

        public Queue RQueue { get; set; }
        
        public Distribution Activity_Distribution { get; set; }
        public override void Process(Event.Type T, Entity E,Actor C = null)
        {
            base.CallNext(E);

            Seized--;
            Check_Busy();
            if (this.RQueue != null && !this.RQueue.Is_Empty)
            {
                Env.FEL.Enqueue(Env.System_Time, new Event(Event.Type.OUT, Env.System_Time, this.RQueue, Env, E,this));
            }
        }
        public override void GenerateEvent(Entity E)
        {
            this.Statistics.TotalServiceNumber++;
            Check_Busy();

            if (this.Is_Idle && (this.RQueue.Queue_Length == 0 || this.RQueue.Head_Entity == E))
            {
                
                Seized++;
                Check_Busy();
                //Console.WriteLine(string.Format("Entity {0} in Res{2} at {1}", E.Id, Env.Seconds_From,this.AID));
                TimeSpan Activity_Time = Activity_Distribution.Next_Time();
                E.Last_Resource_Time_In = Env.System_Time;
                E.statistic.Add_Resource_Delay(this.AID, Activity_Time.TotalSeconds);
                this.Statistics.TotalServiceTime += Activity_Time.TotalSeconds;
                Env.FEL.Enqueue(Env.System_Time + Activity_Time, new Event(Event.Type.R, Env.System_Time + Activity_Time, this, Env, E));
                if (RQueue.Queue_Length > 0) 
                { 
                    RQueue.AQueue.Dequeue();
                    E.statistic.Add_Queue_Delay(RQueue.AID, (Env.System_Time - E.Last_Queue_Time_In).TotalSeconds);
                }
            }
            else
                Env.FEL.Enqueue(Env.System_Time, new Event(Event.Type.IN, Env.System_Time, this.RQueue, Env, E));




        }

        private void Check_Busy()
        {
            this.Is_Busy = this.Seized == Capacity ? true : false;
            if (this.Is_Busy)
            {
                this.State = StateType.Busy;
            }
            else
            {
                this.State = StateType.Idle;
            }
        }

    }
}

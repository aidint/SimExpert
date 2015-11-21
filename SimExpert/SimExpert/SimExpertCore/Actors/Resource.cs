using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Resource : Actor
    {
        public Resource(Environment env, Int64 Id, int Capacity, Distribution dist,Queue Queue = null) : base(env, Id) { this.Capacity = Capacity;
            this.Activity_Distribution = dist;
            this.RQueue = Queue;
        }
        public int Capacity { get; set; }
        public int Seized { get; set; }
        public Queue RQueue { get; set; }
        
        public Distribution Activity_Distribution { get; set; }
        public override void Process(Event.Type T, Entity E)
        {
            Actor NextActor = Env.Sim_Actors[Next_AID.First().Value];
            NextActor.GenerateEvent(E);

            Seized--;
            if (this.RQueue != null)
                Env.FEL.Enqueue(Env.System_Time, new Event(Event.Type.OUT, Env.System_Time, this.RQueue, Env, E));
        }
        public override void GenerateEvent(Entity E)
        {
            this.Is_Busy = this.Seized == Capacity ? true : false;
            if (this.Is_Idle)
            {
                Seized++;
                Console.WriteLine(string.Format("Entity {0} in Res at {1}", E.Id, Env.System_Time.ToString()));
                TimeSpan Activity_Time = Activity_Distribution.Next_Time();
                Env.FEL.Enqueue(Env.System_Time + Activity_Time,new Event(Event.Type.R,Env.System_Time + Activity_Time,this,Env,E));
            }
            else
            {
                if (this.RQueue != null)
                {
                    Env.FEL.Enqueue(Env.System_Time, new Event(Event.Type.IN, Env.System_Time, this.RQueue, Env, E));
                }
                else
                {
                    Actor System_Dispose = Env.Sim_Actors.Values.Where(t => t.AType == Actor.Type.D).First();
                    Env.FEL.Enqueue(Env.System_Time, new Event(Event.Type.F, Env.System_Time, System_Dispose, Env, E));
                }
            }
        }

    }
}

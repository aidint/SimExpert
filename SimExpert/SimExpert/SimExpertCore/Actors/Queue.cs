using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Queue : Actor
    {
        public Queue(Environment env, Int64 Id) : base(env, Id) { AQueue = new Queue<Entity>(); this.Capacity = 10000; this.Queue_Length = 0; }
        public int Capacity { get; set; }
        public int Queue_Length { get; set; }
        public System.Collections.Generic.Queue<Entity> AQueue { get; set; }
        public override void Process(Event.Type T, Entity E)
        {
            if (T == Event.Type.IN)
            {
                if (Capacity > Queue_Length)
                {
                    E.Last_Queue_Time_In = Env.System_Time;
                    AQueue.Enqueue(E);
                }
                else
                {
                    Env.FEL.Enqueue(Env.System_Time, new Event(Event.Type.F, Env.System_Time, Env.System_Dispose.First(), Env, E));
                }

            }
            else
            {
                Entity e = AQueue.Dequeue();
                e.Delay = Env.System_Time.Subtract(e.Last_Queue_Time_In);
                Actor NextActor = Env.Sim_Actors[Next_AID.First().Value];
                NextActor.GenerateEvent(E);
            }
        }
        public override void GenerateEvent(Entity E)
        {
            throw new NotImplementedException();
        }
    }
}

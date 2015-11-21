using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Queue : Actor
    {
        public Queue(Environment env, Int64 Id,int Capacity=10000) : base(env, Id) {
            AQueue = new Queue<Entity>();
            this.Capacity = Capacity;
            this.Actor_Type = Actor.AType.Queue;
            
        }
        public int Capacity { get; set; }
        public int Queue_Length { get { return AQueue.Count;} }
        public Entity Head_Entity { get { return AQueue.First(); } }
        public bool Is_Empty { get { return Queue_Length == 0 ? true:false;} }
        public System.Collections.Generic.Queue<Entity> AQueue { get; set; }
        public override void Process(Event.Type T, Entity E)
        {
            if (T == Event.Type.IN)
            {
                if (Capacity > Queue_Length)
                {
                    E.Last_Queue_Time_In = Env.System_Time;
                    AQueue.Enqueue(E);
                    Console.WriteLine(string.Format("Entity {0} enqueued in Queue{2} at {1}", E.Id, Env.Seconds_From,this.AID));
                }
                else
                {
                    Env.FEL.Enqueue(Env.System_Time, new Event(Event.Type.F, Env.System_Time, Env.System_Dispose.First(), Env, E));
                }

            }
            else
            {
                Entity e = AQueue.First();
                e.Delay += Env.System_Time.Subtract(e.Last_Queue_Time_In);
                Actor NextActor = Env.Sim_Actors[Next_AID.First().Value];
                NextActor.GenerateEvent(e);
            }
        }
        public override void GenerateEvent(Entity E)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Create : Actor
    {
        public int Number_Of_Entities { get; set; }
        public Distribution Create_Distribution { get; set; }
        private int current_number = 2;
        public Create(Environment env,Int64 Id, int Num, Distribution dist) : base(env,Id) { this.Number_Of_Entities = Num;
            this.Create_Distribution = dist;
            Env.System_Create.Add(this);
        }
        
        public override void Process(Event.Type T, Entity E)
        {
            this.Is_Busy = true;
            E.Arrival_Time = Env.System_Time;
            E.Delay = TimeSpan.FromSeconds(0);
            Console.WriteLine(string.Format("Entity {0} entered the system at {1}", E.Id, Env.System_Time.ToString()));
            Actor NextActor = Env.Sim_Actors[Next_AID.First().Value];
            NextActor.GenerateEvent(E);
            if (current_number <= Number_Of_Entities)
            {
                Entity en = new Entity();
                en.InterArrival_Time = Create_Distribution.Next_Time();
                en.Id = current_number;
                Env.FEL.Enqueue(Env.System_Time.Add(en.InterArrival_Time),
                    new Event(Event.Type.C, Env.System_Time.Add(en.InterArrival_Time), this, Env, en));
                current_number++;
            }
            else
            {
                this.Is_Finished = true;
            }
            this.Is_Busy = false;
            
        }

        public override void GenerateEvent(Entity E)
        {
            throw new Exception("'Create' must be first in cycle");
        }
    }
}

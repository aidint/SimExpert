using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Create : Actor
    {
        private List<Int64> _entity_amount;

        public List<Int64> EntityAmount
        {
            get { return _entity_amount; }
            set { _entity_amount = value; }
        }
        public int Number_Of_Entities { get; set; }
        public Distribution Create_Distribution { get; set; }
        private int current_number = 2;
        public Create(Environment env,Int64 Id, int Num, Distribution dist,List<Int64> EntityAmount = null) : base(env,Id) {
            this.Number_Of_Entities = Num;
            this.Actor_Type = Actor.AType.Create;
            this.Create_Distribution = dist;
            this.EntityAmount = EntityAmount;
            Env.System_Create.Add(this);
        }

        public override void Process(Event.Type T, Entity E, Actor C = null)
        {
            this.Is_Busy = true;
            E.Arrival_Time = Env.System_Time;
            E.Delay = TimeSpan.FromSeconds(0);
            Console.WriteLine(string.Format("Entity {0} entered the system at {1}", E.Id, Env.Seconds_From));
            Actor NextActor = Env.Sim_Actors[Next_AID.First().Value];
            NextActor.GenerateEvent(E);
            if (current_number <= Number_Of_Entities)
            {
                Entity en = new Entity();
                en.InterArrival_Time = Create_Distribution.Next_Time();
                en.Id = current_number;
                en.Amount = EntityAmount != null ? EntityAmount[current_number-1] : 1;
                en.statistic.EntityId = en.Id;
                en.statistic.Arrival = Env.Seconds_From + en.InterArrival_Time.TotalSeconds;
                en.statistic.InterArrival = en.InterArrival_Time.TotalSeconds;
                
                Env.Statistics.Add(en.statistic);
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

        public override void GenerateEvent(Entity E = null)
        {
            Entity e = new Entity();
            e.InterArrival_Time = TimeSpan.FromSeconds(0);
            e.Id = 1;
            e.Amount = EntityAmount != null ? EntityAmount[current_number-1] : 1;
            e.statistic.EntityId = e.Id;
            Env.Statistics.Add(e.statistic);
            Event ev = new Event(Event.Type.C, Env.System_Time, this, Env , e);
            Env.FEL.Enqueue(Env.System_Time, ev);
        }
    }
}

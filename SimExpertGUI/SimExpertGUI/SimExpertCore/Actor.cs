using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public abstract class Actor
    {
        public enum AType
        {
            Create,
            Decide,
            Dispose,
            Queue,
            Resource
        }
        public bool Is_Finished { get; set; }
        public bool Is_Busy { get; set; }
        public bool Is_Idle { get { return !Is_Busy; } set { Is_Busy = !value; } }
        public AType Actor_Type { get; set; }
        public enum StateType
        {
            Idle,
            Busy,
            Finished,
        }
        public StateType State { get; set; }
        public Environment Env { get; set; }
        public Dictionary<string, Int64> Next_AID { get; set; }
        public Int64 AID { get; set; }
        private List<double> _cumulative_next;

        public List<double> CumulativeNext
        {
            get { return _cumulative_next; }
            set { _cumulative_next = value; }
        }
        private Discrete _next_disc;

        public Discrete NextDiscrete
        {
            get { return _next_disc; }
            set { _next_disc = value; }
        }
        protected Actor(Environment Env, Int64 AID, List<double> CumulativeNext = null)
        {
            this.Env = Env;
            this.AID = AID;
            this.Env.Sim_Actors.Add(AID, this);
            this.Next_AID = new Dictionary<string, long>();
            this.Is_Busy = false;
            this.Is_Finished = false;
            this.CumulativeNext = CumulativeNext;
            
            

        }

        public abstract void Process(Event.Type T, Entity E, Actor C = null);
        public abstract void GenerateEvent(Entity E);

        public void CallNext(Entity E)
        {
            if (this.CumulativeNext != null && this.CumulativeNext.Count != this.Next_AID.Count) this.CumulativeNext = null;
            if (this.CumulativeNext != null)
            {
                NextDiscrete = new Discrete(this.Next_AID.Values.ToList(), this.CumulativeNext);
            }

            if (NextDiscrete != null)
            {
                Int64 nextAID = NextDiscrete.NextLong();
                Actor NextActor = Env.Sim_Actors[nextAID];
                NextActor.GenerateEvent(E);
            }
            else
            {
                Actor NextActor = Env.Sim_Actors[Next_AID.First().Value];
                NextActor.GenerateEvent(E);
            }
        }
    }
}

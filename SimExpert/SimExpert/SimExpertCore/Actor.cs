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
        public bool Is_Idle { get { return !Is_Busy;} set{ Is_Busy = !value;} }
        public AType Actor_Type { get; set; }
        public enum StateType
        {
            Idle,
            Busy,
            Finished,
        }
        public StateType State { get; set; }
        public Environment Env { get; set; }
        public Dictionary<string,Int64> Next_AID { get; set; }
        public Int64 AID { get; set; }
        protected Actor(Environment Env,Int64 AID)
        {
            this.Env = Env;
            this.AID = AID;
            this.Env.Sim_Actors.Add(AID, this);
            this.Next_AID = new Dictionary<string, long>();
            this.Is_Busy = false;
            this.Is_Finished = false;
            
        }

        public abstract void Process(Event.Type T, Entity E,Actor A = null);


        public abstract void GenerateEvent(Entity E);
    }
}

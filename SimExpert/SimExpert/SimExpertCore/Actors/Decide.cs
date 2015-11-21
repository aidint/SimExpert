using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Decide : Actor
    {
        public Decide(Environment env,Int64 Id) : base(env,Id) 
        {
            this.Actor_Type = Actor.AType.Decide;
        }
        private List<Condition> _Conds = new List<Condition>();
        public List<Condition> Conds { get {return _Conds;} private set{ _Conds = value;}}
        public Dictionary<int, Int64> _CondToTarget = new Dictionary<int,long>();
        public Dictionary<int, Int64> CondToTarget { get { return _CondToTarget; } private set { _CondToTarget = value; } }
        private int index = 0;
        public void AddCondition(Condition cond, Int64 target)
        {
            Conds.Add(cond);
            CondToTarget.Add(index, target);
            index++;
        }
        public void AddElse(Int64 target)
        {
            CondToTarget.Add(index, target);
            index++;
        }
        public override void Process(Event.Type T, Entity E)
        {
            index = 0;
            while (index < Conds.Count)
            {
                if (Conds[index].eval())
                {
                    Env.Sim_Actors[CondToTarget[index]].GenerateEvent(E);
                    return;
                }
                index++;
            }
            Env.Sim_Actors[CondToTarget[index]].GenerateEvent(E);

        }
        public override void GenerateEvent(Entity E)
        {
            Event e = new Event(Event.Type.C, Env.System_Time, this, Env, E);
            Env.FEL.Enqueue(e.Time,e);
        }
    }
}

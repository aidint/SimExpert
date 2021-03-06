﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Dispose : Actor
    {
        public Dispose(Environment env, Int64 Id) : base(env, Id) {
            this.Actor_Type = Actor.AType.Dispose;
            Env.System_Dispose.Add(this); 
        }
        public override void Process(Event.Type T, Entity E,Actor C = null)
        {
            if (T == Event.Type.D){
                Console.WriteLine(string.Format("Entity {0} left system at {1}", E.Id, Env.Seconds_From));
                E.statistic.Departure = Env.Seconds_From;
            }
            else
                Console.WriteLine(string.Format("Entity {0} failed at {1}", E.Id, Env.Seconds_From));
            
        }
        public override void GenerateEvent(Entity E)
        {
            Env.FEL.Enqueue(Env.System_Time,new Event(Event.Type.D, Env.System_Time, this, Env, E));
        }

        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Dispose : Actor
    {
        public Dispose(Environment env, Int64 Id) : base(env, Id) { Env.System_Dispose.Add(this); }
        public override void Process(Event.Type T, Entity E)
        {
            if (T == Event.Type.D)
                Console.WriteLine(string.Format("Entity {0} left system at {1}", E.Id, Env.System_Time.ToString()));
            else
                Console.WriteLine(string.Format("Entity {0} failed at {1}", E.Id, Env.System_Time.ToString()));
            
        }
        public override void GenerateEvent(Entity E)
        {
            Env.FEL.Enqueue(Env.System_Time,new Event(Event.Type.D, Env.System_Time, this, Env, E));
        }
    }
}

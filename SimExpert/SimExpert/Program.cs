using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple Simulation
            //Samples.SimpleSimulation ss = new Samples.SimpleSimulation();
            //ss.run();
            /////////
            //Simple Decide
            Environment env = new Environment();

            //dist
            Uniform d = new Uniform(1, 1, 0);
            
            //dist1
            Uniform n = new Uniform(2, 2, 0);
            Distribution dist = new Distribution(d);
            Distribution dist1 = new Distribution(n);

            Create c = new Create(env, 0, 40, dist);

            Dispose di = new Dispose(env, 10);

            Queue q = new Queue(env, 3);
            q.Capacity = 10;
            Resource r = new Resource(env, 1, 1, dist1, q);

            Queue q2 = new Queue(env, 4);
            q2.Capacity = 10;
            Resource r2 = new Resource(env, 2, 1, dist1, q2);

            Decide de = new Decide(env, 5);
            //Condition
            EQCond cond = new EQCond(0, r, Actor.StateType.Busy);
            de.AddCondition(cond, r2.AID);
            de.AddElse(r.AID);


            c.Next_AID.Add("First", 5);
            r.Next_AID.Add("First", 10);
            r2.Next_AID.Add("First", 10);

            env.System_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Start_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Setup_Simulation();
            env.Simulate();
            
            Console.Read();
            //
        }

        
    }
}

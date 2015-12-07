using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.Samples
{
    class Chain : Sample
    {
        public override void run()
        {
            Environment env = new Environment();

            //
            List<double> valueList = new List<double>() { 1, 2, 3, 4, 5 };
            List<double> distribution = new List<double>() { 0.5, 0.6, 0.7, 0.8, 1.0 };
            Discrete discrete = new Discrete(valueList, distribution, 0);
            //
            Uniform uniform = new Uniform(1, 3, 0);
            Distribution CreateDist = new Distribution(discrete);
            Distribution ResDist = new Distribution(uniform);

            Create c = new Create(env, 0, 4, CreateDist);

            Dispose dispose = new Dispose(env, 10);

            Queue q = new Queue(env, 5);
            q.Capacity = 10;
            Resource r = new Resource(env, 1, 1, ResDist, q);

            Queue q2 = new Queue(env, 6);
            q2.Capacity = 10;
            Resource r2 = new Resource(env, 2, 1, ResDist, q2);

            Queue q3 = new Queue(env, 7);
            q3.Capacity = 10;
            Resource r3 = new Resource(env, 3, 1, ResDist, q3);

            Queue q4 = new Queue(env, 8);
            q4.Capacity = 10;
            Resource r4 = new Resource(env, 4, 1, ResDist, q4);

            c.Next_AID.Add("First", 1);
            r.Next_AID.Add("First", 2);
            r2.Next_AID.Add("First", 3);
            r3.Next_AID.Add("First", 4);
            r4.Next_AID.Add("First", 2);

            env.System_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Start_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Setup_Simulation(TimeSpan.FromSeconds(300));
            env.Simulate();
        }
    }
}

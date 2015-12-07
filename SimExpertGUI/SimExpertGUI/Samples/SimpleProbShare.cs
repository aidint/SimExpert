using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.Samples
{
    class SimpleProbShare:Sample
    {
        public override void run()
        {
            Environment env = new Environment();

            //dist
            List<double> valueList = new List<double>() { 1, 2, 3, 4, 5 };
            List<double> distribution = new List<double>() { 0.5, 0.6, 0.7, 0.8, 1.0 };
            Discrete d = new Discrete(valueList, distribution, 0);
            //dist1
            Uniform n = new Uniform(1, 3, 0);
            Distribution dist = new Distribution(d);
            Distribution dist1 = new Distribution(n);

            Create c = new Create(env, 0, 10000, dist,null,new List<double>(){0.3,0.8,1.0});

            Dispose di = new Dispose(env, 1);

            Queue q = new Queue(env, 3);
            q.Capacity = 1;
            Resource r = new Resource(env, 2, 1, dist1, q);

            Queue q2 = new Queue(env,5);
            q2.Capacity = 1;
            Resource r2 = new Resource(env, 6, 1, dist1, q2);

            Queue q3 = new Queue(env, 10);
            q3.Capacity = 1;
            Resource r3 = new Resource(env, 7, 1, dist1, q3);

            c.Next_AID.Add("First", 2);
            c.Next_AID.Add("Second", 6);
            c.Next_AID.Add("Third", 7);
            
            r.Next_AID.Add("First", 1);
            r2.Next_AID.Add("First", 1);
            r3.Next_AID.Add("First", 1);

            env.System_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Start_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Setup_Simulation();
            env.Simulate();
        }
    }
}

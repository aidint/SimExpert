using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.Samples
{
    class SimpleSimulation
    {
        public void run()
        {
            Environment env = new Environment();

            //dist
            List<double> valueList = new List<double>() { 1, 2, 3, 4, 5 };
            List<double> distribution = new List<double>() { 0.5, 0.1, 0.1, 0.1, 0.1 };
            Discrete d = new Discrete(valueList, distribution, 0);
            //dist1
            Uniform n = new Uniform(1, 3, 0);
            Distribution dist = new Distribution(d);
            Distribution dist1 = new Distribution(n);

            Create c = new Create(env, 0, 20, dist);

            Dispose di = new Dispose(env, 1);

            Queue q = new Queue(env, 3);
            q.Capacity = 1;
            Resource r = new Resource(env, 2, 1, dist1, q);



            c.Next_AID.Add("First", 2);
            r.Next_AID.Add("First", 1);

            env.System_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Start_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Setup_Simulation();
            env.Simulate();
        }
    }
}

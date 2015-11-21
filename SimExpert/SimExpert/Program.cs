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
            
            //A Test; Simple Simulation, Resource without queue
            

            Environment env = new Environment();

            Distribution dist = new Distribution(1);
            Distribution dist1 = new Distribution(2);

            Create c = new Create(env,0,20,dist);

            Dispose d = new Dispose(env,1);
            Queue q = new Queue(env,3);
            q.Capacity = 10;
            Resource r = new Resource(env, 2,1,dist1,q);

            
           
            c.Next_AID.Add("First", 2);
            r.Next_AID.Add("First", 1);

            env.System_Time = new DateTime(1970,1,1,0,0,0);
            env.Setup_Simulation();
            env.Simulate();
            Console.Read();
            //
        }

        
    }
}

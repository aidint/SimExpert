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
            
            //A Test
            

            Environment env = new Environment();

            Distribution dist = new Distribution();
            Create c = new Create(env,0,20,dist);

            Dispose d = new Dispose(env,1);
           
            c.Next_AID.Add("First", 1);

            env.System_Time = new DateTime(1970,1,1,0,0,0);
            env.Setup_Simulation();
            env.Simulate();
            Console.Read();
            //
        }

        
    }
}

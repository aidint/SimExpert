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
            //Samples.SimpleDecide sd = new Samples.SimpleDecide();
            //sd.run();
            /////////
            //Simple Shared Queue
            //Samples.SimpleSharedQueue ssd = new Samples.SimpleSharedQueue();
            //ssd.run();
            //Able and Baker
            //Samples.AbleBaker ab = new Samples.AbleBaker();
            //ab.run();
            ///////
            //Chain Maybe
            Samples.Chain chain = new Samples.Chain();
            chain.run();
            ///////
            Console.Read();
            //
        }

        
    }
}

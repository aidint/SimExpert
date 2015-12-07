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
            //Samples.Chain chain = new Samples.Chain();
            //chain.run();
            ///////
            //Inventory Sample
            Samples.InventorySample inv = new Samples.InventorySample();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < 15; i++)
                dict.Add((20 * i).ToString() + "-" + (20 * (i + 1)).ToString(), 0);
            List<string> keys = dict.Keys.ToList();
            double sum = 0;
            for (int i = 0; i < 400; i++)
            {
                double a = inv.run();
                sum += a;
                int j = (int)a / 20;
                dict[keys[j]] = dict[keys[j]] + 1;

            }
            sum = sum / 400;
            Console.Read();
            //
            
        }

        
    }
}

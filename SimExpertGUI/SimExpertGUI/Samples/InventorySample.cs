using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.Samples
{
    class InventorySample : Sample
    {
        public override void run()
        {
            Environment env = new Environment();

            //dist for Create 
            Constant Const = new Constant(1);
            Distribution CreateDist = new Distribution(Const);
            //distributions for Inventory
            List<double> States = new List<double>() { 1, 2, 3 }; //1 for good, 2 for fair, 3 for poor
            List<double> States_Prob = new List<double>() { 0.35, 0.80, 1.00 };
            Discrete StatesDisc = new Discrete(States, States_Prob);

            List<double> State1 = new List<double>() { 40, 50, 60, 70, 80, 90, 100 };
            List<double> State1_Prob = new List<double>() { 0.03, 0.08, 0.23, 0.43, 0.78, 0.93, 1.00 };
            Discrete State1Disc = new Discrete(State1, State1_Prob);

            List<double> State2 = new List<double>() { 40, 50, 60, 70, 80, 90, 100 };
            List<double> State2_Prob = new List<double>() { 0.10, 0.28, 0.68, 0.88, 0.96, 1.00, 1.00 };
            Discrete State2Disc = new Discrete(State2, State2_Prob);

            List<double> State3 = new List<double>() { 40, 50, 60, 70, 80, 90, 100 };
            List<double> State3_Prob = new List<double>() { 0.44, 0.66, 0.82, 0.94, 1.00, 1.00, 1.00 };
            Discrete State3Disc = new Discrete(State3, State3_Prob);

            Dictionary<double, Discrete> Demand = new Dictionary<double, Discrete>();
            Demand.Add(1, State1Disc);
            Demand.Add(2, State2Disc);
            Demand.Add(3, State3Disc);

            List<Int64> Amount = new List<Int64>();
            for (int i = 0; i < 20; i++) Amount.Add(70);

            Create create = new Create(env, 0, 20, CreateDist, Amount);

            Dispose dispose = new Dispose(env, 2);

            Inventory inv = new Inventory(env, 1, new TimeSpan(1), 70, StatesDisc, Demand, 0.33, 0.50, true, 0.05);



            create.Next_AID.Add("First", 1);
            inv.Next_AID.Add("First", 2);


            env.System_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Start_Time = new DateTime(1970, 1, 1, 0, 0, 0);

            env.Setup_Simulation();
            env.Simulate();

            
            

        }
    }
}

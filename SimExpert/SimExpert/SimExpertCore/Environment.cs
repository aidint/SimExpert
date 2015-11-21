using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Environment
    {
        public DateTime System_Time { get; set; }
        public EventQueue FEL { get; set; }
        public Nullable<TimeSpan> Simulation_Time { get; set; }
        public Dictionary<Int64, Actor> Sim_Actors = new Dictionary<long, Actor>();
        public Environment()
        {

        }

        public void Setup_Simulation(Nullable<TimeSpan> Simulation_Time = null)
        {
            this.Simulation_Time = Simulation_Time;
            
            FEL = new EventQueue(10000);
            Actor[] clist = Sim_Actors.Values.Where(t => t.Is_Create).ToArray();
            foreach (Actor a in clist)
            {
                
                Entity E = new Entity();
                E.InterArrival_Time = TimeSpan.FromSeconds(0);
                E.Id = 1;

                Event ev = new Event(Event.Type.C, System_Time, a, this, E);
                FEL.Enqueue(System_Time,ev);
            }
        }

        public void Simulate()
        {
            
            while (FEL.Count > 0)
            {
                FEL.Dequeue().Event.Run();
            }
        }
    }
}

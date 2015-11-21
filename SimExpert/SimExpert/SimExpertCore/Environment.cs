using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Environment
    {
        public List<Actor> System_Dispose { get; set; }
        public List<Actor> System_Create { get; set; }
        public DateTime System_Time { get; set; }
        public EventQueue FEL { get; set; }
        public Nullable<TimeSpan> Simulation_Time { get; set; }
        public Dictionary<Int64, Actor> Sim_Actors { get; set; }
        public bool _env_state_changed = false;
        public bool EnvStateChanged { get { return _env_state_changed; } set { _env_state_changed = value; } }
        public HashSet<Int64> ImportantActorIds = new HashSet<long>();
        public List<Int64> ActorsStateChanges = new List<long>();
        public Dictionary<Int64, HashSet<Int64>> ActorStateToActors = new Dictionary<long,HashSet<long>>();
        public List<StatisticObj> statistics = new List<StatisticObj>();
        public List<ResourceStatistic> resource_statistics = new List<ResourceStatistic>();
        public DateTime Start_Time { get; set; }
        public double Seconds_From
        {
            get
            {
                return System_Time.Subtract(Start_Time).TotalSeconds;
            }
        }
        public Environment()
        {
            Sim_Actors = new Dictionary<long, Actor>();
            System_Create = new List<Actor>();
            System_Dispose = new List<Actor>();
        }

        public void Setup_Simulation(Nullable<TimeSpan> Simulation_Time = null)
        {
            this.Simulation_Time = Simulation_Time;
            
            FEL = new EventQueue(10000);
            
            foreach (Actor a in System_Create)
            {
                
                Entity E = new Entity();
                E.InterArrival_Time = TimeSpan.FromSeconds(0);
                E.Id = 1;
                E.statistic.EntityId = E.Id;
                this.statistics.Add(E.statistic);
                Event ev = new Event(Event.Type.C, System_Time, a, this, E);
                FEL.Enqueue(System_Time,ev);
            }
        }

        public void Simulate()
        {
            
            while (FEL.Count > 0)
            {
                Event e = FEL.Dequeue().Event;
                if (Simulation_Time != null && Start_Time.Add((TimeSpan)Simulation_Time) <= e.Time) break;
                e.Run();
            }
            Console.WriteLine("End Of Simulation(EOS)|");
            GenerateResults();
        }

        public void GenerateResults()
        {
            using (StreamWriter w = new StreamWriter(@"entities.csv"))
            {
                w.WriteLine("Id,Arrival,InterArrival,Departure,Delay,Service");
                foreach (StatisticObj s in statistics)
                {
                    w.WriteLine(s.EntityId.ToString() + "," + s.Arrival.ToString() + "," + s.InterArrival + "," + s.Departure + "," + s.TotalQueueDelay + "," + s.TotalResourceDelay);
                }

            }

            using (StreamWriter w = new StreamWriter(@"resources.csv"))
            {
                w.WriteLine("Id,Total Service Time, Utilization");
                foreach (ResourceStatistic s in resource_statistics)
                {
                    w.WriteLine(s.ResourceId + "," + s.TotalServiceTime + "," + s.TotalServiceTime / Seconds_From);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Event
    {
        public Environment Env { get; set; }
        public enum Type
        {
            A,//Arrival
            S,//Seize
            R,//Release
            D,//Depart
            C,//Condition
            IN,//Enqueue
            OUT,//Dequeue
            F//Fail
        };
        private Type T;//Event Type
        private DateTime time;//Event Time
        public DateTime Time
        {
            get { return time; }
            set { time = value; }//
        }
        private Entity E;//Entity assigned to Event
        private Actor A;//Actor assigned to Event
        public Event(Type T, DateTime Time,  Actor A,Environment Env,Entity E = null)//Constructor // E = Null for Arrival Event
        {
            this.T = T;
            this.time = Time;
            this.E = E;
            if (E == null)
            {
                this.E = new Entity();
            }
            this.A = A;
            this.Env = Env;
            
        }
        public void Run()//Trigger Event
        {
            A.Process(T, E);//Call the correct Process
            Env.System_Time = Time; //Add Event Time to System Time
        }
    }
}

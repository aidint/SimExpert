using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.SimExpertCore
{
    class EventEx
    {
        enum Type
        {
            A,//Arrival
            S,//Seize
            R,//Release
            D,//Depart
            C,//Condition
            IN,//Enqueue
            OUT//Dequeue
        };
        private Type T;
        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }
        private Entity E;
        private Actor A;

        public EventEx(Type T, TimeSpan Time, Entity E, Actor A)
        {
            this.T = T;
            this.time = Time;
            this.E = E;
            this.A = A;
        }
        public void Run()
        {
            switch (T)
            {
                case Type.A:
                    break;
                case Type.C:
                    break;
                case Type.D:
                    break;
                case Type.IN:
                    break;
                case Type.OUT:
                    break;
                case Type.R:
                    break;
                case Type.S:
                    break;
                case default:
                    break;
            }
        }
    }
}

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
            Create c = new Create(env);
            env.System_Time = new DateTime(1970,1,1,0,0,0);
            Event e = new Event(Event.Type.C, DateTime.Parse("1/1/1970 12:24:14 AM"), c, env, new Entity());
            Event e1 = new Event(Event.Type.C, DateTime.Parse("1/1/1970 12:24:15 AM"), c, env, new Entity());
            Event e2 = new Event(Event.Type.C, DateTime.Parse("1/1/1970 12:24:15 AM"), c, env, new Entity());
            Event e3 = new Event(Event.Type.C, DateTime.Parse("1/1/1970 12:24:14 AM"), c, env, new Entity());
            Event e4 = new Event(Event.Type.C, DateTime.Parse("1/2/1970 12:24:14 AM"), c, env, new Entity());
            env.FEL = new EventQueue(10000);
            env.FEL.Enqueue(e.Time, e);
            env.FEL.Enqueue(e1.Time, e1);
            
            env.FEL.Enqueue(e3.Time, e3);
            env.FEL.Enqueue(e4.Time, e4);
            env.FEL.Enqueue(e2.Time, e2);
            while(env.FEL.Count != 0)
                Console.WriteLine(env.FEL.Dequeue().Event);
            Console.Read();
            //
        }

        
    }
}

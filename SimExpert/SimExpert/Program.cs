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
            Event e = new Event(Event.Type.C, TimeSpan.FromMinutes(3), c, env, new Entity());
            Event e1 = new Event(Event.Type.C, TimeSpan.FromMinutes(5), c, env, new Entity());
            Event e2 = new Event(Event.Type.C, TimeSpan.FromMinutes(2), c, env, new Entity());
            Event e3 = new Event(Event.Type.C, TimeSpan.FromMinutes(1), c, env, new Entity());
            Event e4 = new Event(Event.Type.C, TimeSpan.FromMinutes(0), c, env, new Entity());
            e.Run();
            e1.Run();
            e2.Run();
            e3.Run();
            e4.Run();
            Console.WriteLine(env.System_Time);
            Console.Read();
            //
        }

        
    }
}

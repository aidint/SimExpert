using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert.Samples
{
    class AbleBaker:Sample
    {
        public override Statistics run()
        {
            Environment env = new Environment();

            //dist for Create 
            Uniform CreateDist = new Uniform(1, 5, 0);

            //dist for Able
            Uniform AbleDist = new Uniform(4, 6, 0);

            //dist for Baker
            Uniform BakerDist = new Uniform(2, 5, 0);

            Distribution DistCreate = new Distribution(CreateDist);
            Distribution DistAble = new Distribution(AbleDist);
            Distribution DistBaker = new Distribution(BakerDist);

            Create create = new Create(env, 0, 100, DistCreate);

            Dispose dispose = new Dispose(env, 10);

            Queue SharedQueue = new Queue(env, 3);

            Resource Able = new Resource(env, 1, 1, DistAble, SharedQueue);


            Resource Baker = new Resource(env, 2, 1, DistBaker, SharedQueue);

            Decide decide = new Decide(env, 5);
            //Condition
            EQCond cond = new EQCond(0, Able, Actor.StateType.Idle);
            decide.AddCondition(cond, Able.AID);
            decide.AddElse(Baker.AID);


            create.Next_AID.Add("First", 5);
            Able.Next_AID.Add("First", 10);
            Baker.Next_AID.Add("First", 10);

            env.System_Time = new DateTime(1970, 1, 1, 0, 0, 0);
            env.Start_Time = new DateTime(1970, 1, 1, 0, 0, 0);

            env.Setup_Simulation();
            return env.Simulate();
            
            
        }
    }
}

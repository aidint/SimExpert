using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Condition
    {

        virtual public bool eval() { return true; }
        virtual public void exhast() { }

    }
}

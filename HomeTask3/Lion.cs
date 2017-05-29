using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3
{
    public class Lion : Animal
    {
        public Lion()
        {
            Helth = MaxHelth = 5;
            State = State.full;
        }
    }
}

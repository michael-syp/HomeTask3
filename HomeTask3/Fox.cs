using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3
{
    public class Fox : Animal
    {
        public Fox()
        {
            Helth = MaxHelth = 3;
            State = State.full;
        }
    }
}

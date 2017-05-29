using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3
{
    public class Wolf : Animal
    {
        public Wolf()
        {
            Helth = MaxHelth = 4;
            State = State.full;
        }
    }
}

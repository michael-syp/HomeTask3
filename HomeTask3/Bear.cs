using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3
{
    public class Bear : Animal
    {
        public Bear()
        {
            Helth = MaxHelth = 6;
            State = State.full;
        }
    }
}

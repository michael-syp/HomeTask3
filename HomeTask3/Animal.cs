using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3
{
    public enum State { full, hungry, ill, dead };
    public class Animal
    {
        public int Helth { get; set; }
        public int MaxHelth { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
    }

}

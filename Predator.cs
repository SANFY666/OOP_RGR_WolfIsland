using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
    public class Predator : Animal
    {
        public bool IsFemale { get; private set; }
        public double Energy { get; set; }

        public Predator(int x, int y, bool isFemale) : base(x, y)
        {
            IsFemale = isFemale;
            Energy = 1.0;
        }
    }
}

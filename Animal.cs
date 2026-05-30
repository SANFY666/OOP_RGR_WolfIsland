using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
    public abstract class Animal
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Animal(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

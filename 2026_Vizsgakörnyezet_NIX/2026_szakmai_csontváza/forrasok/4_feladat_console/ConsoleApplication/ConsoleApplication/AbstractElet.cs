using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public abstract class AbstractElet
    {
        public abstract bool Halott { get; set; }
        public abstract int Y {  get; set; }
        public abstract int X { get; set; }
        public abstract int LepesY { get; set; }
        public abstract int LepesX { get; set; }

    }
}

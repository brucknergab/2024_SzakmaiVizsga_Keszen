using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    public class Jatekos : AbstractElet, IMozoghat
    {
        public override bool Halott { get; set; }
        public override int Y { get; set; }
        public override int X { get; set; }
        public override int LepesY { get; set; }
        public override int LepesX { get; set; }

        public int KezdoY { get; set; }
        public int KezdoX { get; set; }

        public void Mozog()
        {
            throw new NotImplementedException();
        }
    }
}

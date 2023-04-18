using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelirovanie_Kurs
{
    internal class Variables
    {
        public ushort A { get; set; } = 0;
        public ushort B { get; set; } = 0;
        public uint AM { get; set; } = 0;
        public uint C { get; set; } = 0;

        public char[] ToCharArray (uint value) => Convert.ToString(value, toBase: 2).ToCharArray();
        
    }
}

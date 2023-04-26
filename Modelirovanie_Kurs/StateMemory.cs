using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelirovanie_Kurs
{
    internal class StateMemory
    {
        public bool[] ArrStateA { get; set; }

        public void setCurrentState(bool[] stateCode)
        {
            ArrStateA = new bool[4];
            byte currentStateIndex = 0;
            if (stateCode[0])
                currentStateIndex += 1;
            if (stateCode[1])
                currentStateIndex += 2;
            ArrStateA[currentStateIndex] = true;
        }
    }
}

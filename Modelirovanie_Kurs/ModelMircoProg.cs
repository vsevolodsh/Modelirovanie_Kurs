﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelirovanie_Kurs
{
    internal class ModelMircoProg
    {
        Variables _variables;
        public byte Count { get; private set; }
        public bool X0 { get; set; }
        public bool[] ArrStateA { get; set; } = new bool[4] { true, false, false, false };

        public ModelMircoProg(Variables variables)
        {
            _variables = variables;
        }

        public Variables ExecuteTact()
        {
            if (ArrStateA[0])
            {
                if (!X0)
                {

                }
                else if ((_variables.A & 0x7fff) == 0 || (_variables.B & 0x7fff) == 0)
                {
                    _variables.C = 0;
                }
                else
                {
                    _variables.C = 0;
                    _variables.AM = (uint)((_variables.A << 15) >> 1);
                    Count = 0xF;
                    ArrStateA[0] = false;
                    ArrStateA[1] = true;
                }
            }
            else if (ArrStateA[1])
            {
               OneCycleIteration();
                ArrStateA[1] = false;
                ArrStateA[2] = true;
            }
            else if (ArrStateA[2])
            {
                if (Count == 0)
                {
                    if ((_variables.C & 0x4000) != 0)
                    {
                        //AHTUNG!!!!!!!!!!!!!!!!
                        ArrStateA[2] = false;
                        ArrStateA[3] = true;
                    }
                    else if ((_variables.A >> 15 ^ _variables.B >> 15) == 1)
                    {
                        _variables.C |= 0x80000000;
                    }
                    ArrStateA[2] = false;
                    ArrStateA[0] = true;
                }
                else
                {
                    OneCycleIteration();          
                }
            }
            else if (ArrStateA[3])
            {
                if ((_variables.A >> 15 ^ _variables.B >> 15) == 1)
                {
                    _variables.C |= 0x80000000;
                }
                ArrStateA[3] = false;
                ArrStateA[0] = true;
            }
            return _variables;
        }

        private void OneCycleIteration()
        {
            if ((_variables.B & 0x4000) != 0)
            {
                _variables.C += _variables.AM;
                _variables.B = (ushort)(((_variables.B << 1) & 0x7fff) | (_variables.B & 0x8000));
                _variables.AM >>= 1;
                Count--;
            }
            else
            {
                _variables.B = (ushort)(((_variables.B << 1) & 0x7fff) | (_variables.B & 0x8000));
                _variables.AM >>= 1;
                Count--;
            }
        }
    }
}

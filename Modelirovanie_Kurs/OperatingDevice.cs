namespace Modelirovanie_Kurs
{
    internal class OperatingDevice
    {
        Variables _variables;
        public bool[] ConditionsX = new bool[7];
        readonly Action[] _doOperationsY;
        Form1 form1;

        public OperatingDevice(Variables variables, Form1 form1)
        {
            _variables = variables;
            this.form1 = form1;
            _doOperationsY = new Action[]
            {
             () => {_variables.C = 0;}, //y1
             () => { _variables.AM = (uint)_variables.A  << 14 & 0x1FFFFFFF;}, //y2
             () => { _variables.AM &= 0xFFFFC000; }, //y3
             () => { _variables.Count = 0xF; }, //y4
             () => {_variables.C += (_variables.AM << 2) >> 2;}, //y5
             () => { _variables.B = (ushort)(((_variables.B << 1) & 0x7fff) | (_variables.B & 0x8000));}, //y6
             () => {_variables.AM >>= 1;}, //y7
             () => {_variables.Count--;}, //y8
             () => {_variables.C = ((_variables.C + 0x8000) & 0x3FFFFFFF) << 1;}, //y9
             () => {_variables.C |= 0x80000000;} //y10
             };
        }
        public void FillConditionsXArray()
        {
            ConditionsX[0] = form1.checkBoxX0.Checked;
            ConditionsX[1] = (_variables.A & 0x7fff) == 0;
            ConditionsX[2] = (_variables.B & 0x7fff) == 0;
            ConditionsX[3] = (_variables.B & 0x4000) != 0;
            ConditionsX[4] = (_variables.Count) == 0;
            ConditionsX[5] = (_variables.C & 0x4000) != 0;
            ConditionsX[6] = (_variables.A >> 15 ^ _variables.B >> 15) == 1;
        }

        public void ExecuteTact(bool[] operationsY)
        {
            for (int i = 0; i < _doOperationsY.Length; i++)
            {
                if (operationsY[i])
                {
                    _doOperationsY[i]();
                }
            }
            FillConditionsXArray();
        }
    }
}

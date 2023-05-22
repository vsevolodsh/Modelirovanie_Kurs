namespace Modelirovanie_Kurs
{
    internal class ModelMircoProg
    {
        Variables _variables;
        Form1 _form1;
        public bool[] ArrStateA { get; set; } = new bool[4] { true, false, false, false };
        public bool RightCircleBranch { get; set; } // true - выполняем правую ветку цикла в алгоритме, false - наоборот
        public bool IsCSet0 { get; set; } = false; // true - выполняем операцию y1 и переходим в состояние А0
        public bool IsCNegative { get; set; } = false; // true - ставим знаковый разряд равный 1 и переходим в состояние А0
        public ModelMircoProg(Variables variables, Form1 form1)
        {
            _variables = variables;
            _form1 = form1;
        }

        public Variables ExecuteTact()
        {
            if (ArrStateA[0])
            {
                if (!_form1.checkBoxX0.Checked) //Если х0 = истина, остаемся в такте А0
                {
                }
                else if ((_variables.A & 0x7fff) == 0 || (_variables.B & 0x7fff) == 0)
                {
                    //Если А или В равны 0
                    _variables.C = 0; //C равен 0, остаемся в А0
                    IsCSet0 = true;
                }
                else
                {
                    _variables.C = 0; // C = 0
                    _variables.AM = (uint)_variables.A  << 14 & 0x1FFFFFFF; 
                    _variables.Count = 0xF; // Счетсчик = 15
                    ArrStateA[0] = false;
                    ArrStateA[1] = true; //Переходим в А1
                }
            }
            else if (ArrStateA[1])
            {
               OneCycleIteration(); // Выполняем одну итерацию цикла
                ArrStateA[1] = false;
                ArrStateA[2] = true; //Переходим в А2
            }
            else if (ArrStateA[2])
            {
                if (_variables.Count == 0) 
                {
                    if ((_variables.C & 0x4000) != 0) // Если 14 разряд С равен 1
                    {
                        _variables.C = ((_variables.C + 0x8000) & 0x3FFFFFFF) << 1; // к 15 разряду числа С прибавляем 1
                        ArrStateA[2] = false;
                        ArrStateA[3] = true; // Переходим в А3
                    }
                    else if ((_variables.A >> 15 ^ _variables.B >> 15) == 1) // иначе если А положит., а В отриц., или наоборот
                    {
                        IsCNegative = true;
                        _variables.C |= 0x80000000; // знаковый разряд С становится равным 1
                        ArrStateA[2] = false;
                        ArrStateA[0] = true; //переходим в сосотяние А0, окончание алгоритма
                    }
                    else
                    {
                        ArrStateA[2] = false;
                        ArrStateA[0] = true; //переходим в сосотяние А0, окончание алгоритма
                    }
                }
                else // Если счетсчмк > 0, делаем еще одну итерацию цикла
                {
                    OneCycleIteration();          
                }
            }
            else if (ArrStateA[3])
            {
                if ((_variables.A >> 15 ^ _variables.B >> 15) == 1)
                {
                    IsCNegative = true;
                    _variables.C |= 0x80000000;
                }
                ArrStateA[3] = false;
                ArrStateA[0] = true;
            }
            return _variables;
        }

        private void OneCycleIteration()
        {
            if ((_variables.B & 0x4000) != 0) // если 14 разряд В равен 1 
            {
                _variables.C += (_variables.AM << 2) >> 2; // прибавляем к С первые 30 разрядов числа АМ
                _variables.B = (ushort)(((_variables.B << 1) & 0x7fff) | (_variables.B & 0x8000)); // сдвиг влево числа В,
                // знаковый разряд остается на своем месте.
                _variables.AM >>= 1; // сдвиг АМ на 1 разряд вправо
                _variables.Count--; //Уменьшаем счетчик на 1
                RightCircleBranch = true;
            }
            else
            {
                _variables.B = (ushort)(((_variables.B << 1) & 0x7fff) | (_variables.B & 0x8000));
                _variables.AM >>= 1;
                _variables.Count--;
                RightCircleBranch = false;
            }
        }
    }
}

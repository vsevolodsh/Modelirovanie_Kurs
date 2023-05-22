namespace Modelirovanie_Kurs
{
    internal class StateAndConditionsMemory
    {
        private bool[] _arrStateA; // поле для хранения текущего состояния
        public bool[] ArrStateA { get { return _arrStateA; } private set { _arrStateA = ArrStateA; } } 
        private bool[] _currentStateCode = new bool[2]; // поле для хранения кода текущего состояния
        public bool[] CurrentStateCode
        {
            set
            {
                value.CopyTo(_currentStateCode, 0);
                Decoder();
            }
            get { return _currentStateCode; }
        }
        public bool[] ConditionsX { get; set; } = new bool[7]; //Поле для хранения значений условий на текущем такте
        private void Decoder() // Дешифратор
        {
            _arrStateA = new bool[4];
            byte currentStateIndex = 0; // Номер состояния
            if (CurrentStateCode[0]) // Если на первом D тригерре единица
                currentStateIndex += 1;
            if (CurrentStateCode[1]) // Если на втором D тригерре единица
                currentStateIndex += 2;
            _arrStateA[currentStateIndex] = true; 
        }
    }
}

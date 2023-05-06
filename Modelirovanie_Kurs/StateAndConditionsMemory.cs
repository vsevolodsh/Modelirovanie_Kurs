namespace Modelirovanie_Kurs
{
    internal class StateAndConditionsMemory
    {
        private bool[] _arrStateA;
        public bool[] ArrStateA { get { return _arrStateA; } private set { _arrStateA = ArrStateA; } }
        private bool[] _currentStateCode = new bool[2];
        public bool[] CurrentStateCode
        {
            set
            {
                value.CopyTo(_currentStateCode, 0);
                Decoder();
            }
            get { return _currentStateCode; }
        }
        public bool[] ConditionsX { get; set; } = new bool[7];
        private void Decoder()
        {
            _arrStateA = new bool[4];
            byte currentStateIndex = 0;
            if (CurrentStateCode[0])
                currentStateIndex += 1;
            if (CurrentStateCode[1])
                currentStateIndex += 2;
            _arrStateA[currentStateIndex] = true;
        }
    }
}

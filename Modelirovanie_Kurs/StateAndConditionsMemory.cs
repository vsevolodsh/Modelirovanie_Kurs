namespace Modelirovanie_Kurs
{
    internal class StateAndConditionsMemory
    {
        private bool[] _stateCode = new bool[2];
        public bool[] StateCode { 
            set { _stateCode = value; }
            get {
                bool[] _arrStateA = new bool[4];
                byte currentStateIndex = 0;
                if (_stateCode[0])
                    currentStateIndex += 1;
                if (_stateCode[1])
                    currentStateIndex += 2;
                _arrStateA[currentStateIndex] = true;
                return _arrStateA; 
            } 
        }
        public bool[] ConditionsX { get; set; } = new bool[7];
    
    }
}

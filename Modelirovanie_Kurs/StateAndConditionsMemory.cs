namespace Modelirovanie_Kurs
{
    internal class StateAndConditionsMemory
    {
        private bool[] _arrStateA;
        public bool[] ArrStateA
        {
            set
            {
                _arrStateA = new bool[4];
                byte currentStateIndex = 0;
                if (value[0])
                    currentStateIndex += 1;
                if (value[1])
                    currentStateIndex += 2;
                _arrStateA[currentStateIndex] = true;
            }
            get { return _arrStateA; }
        }
        public bool[] ConditionsX { get; set; } = new bool[7];
    
    }
}

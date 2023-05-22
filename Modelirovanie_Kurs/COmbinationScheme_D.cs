namespace Modelirovanie_Kurs
{
    internal class CombinationScheme_D
    {
        public bool[] NextStateCode  { get; private set; } = new bool[2];

        public void setNextStateCode(bool[] statesA, bool[] conditionsX) // Формируем код следующего состояния
        {
            for (int i = 0; i < NextStateCode.Length; i++)
            {
                NextStateCode[i] = false;
            }
            if (statesA[0] && conditionsX[0] && !conditionsX[1] && !conditionsX[2])
                NextStateCode[0] = true;
            else if (statesA[1] && conditionsX[3] || statesA[1] && !conditionsX[3] || statesA[2] && !conditionsX[4] && conditionsX[3] 
                || statesA[2] && !conditionsX[4] && !conditionsX[3])
                NextStateCode[1] = true;
            else if (statesA[2] && conditionsX[4] && conditionsX[5])
            {
                NextStateCode[0] = true;
                NextStateCode[1] = true;
            }
            
        }
    }
}

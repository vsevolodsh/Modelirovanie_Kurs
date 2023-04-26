namespace Modelirovanie_Kurs
{
    internal class CombinationScheme_Y
    {
        public bool[] OperationsY { private set; get; } = new bool[10];

        public void SetCurrentOperationsY(bool[] statesA, bool[] conditionsX)
        {
            for (int i = 0; i < OperationsY.Length; i++)
            {
                OperationsY[i] = false;
            }
            if (statesA[0] && conditionsX[0] && conditionsX[1] || statesA[0] && conditionsX[0] && !conditionsX[1] && conditionsX[2])
            {
                OperationsY[0] = true;
            }
            else if (statesA[1] && conditionsX[0] && !conditionsX[1] && !conditionsX[2])
            {
                OperationsY[0] = true;
                OperationsY[1] = true;
                OperationsY[2] = true;
                OperationsY[3] = true;
            }
            else if (statesA[1] && conditionsX[3] || statesA[2] && !conditionsX[4] && conditionsX[3])
            {
                OperationsY[4] = true;
                OperationsY[5] = true;
                OperationsY[6] = true;
                OperationsY[7] = true;
            }
            else if (statesA[1] && !conditionsX[3] || statesA[2] && !conditionsX[4] && !conditionsX[3])
            {
                OperationsY[5] = true;
                OperationsY[6] = true;
                OperationsY[7] = true;
            }
            else if (statesA[2] && conditionsX[4] && conditionsX[5])
            {
                OperationsY[8] = true;
            }
            else if (statesA[2] && conditionsX[4] && !conditionsX[5] && conditionsX[6] || statesA[3] && conditionsX[6])
            {
                OperationsY[9] = true;
            }
        }
    }
}

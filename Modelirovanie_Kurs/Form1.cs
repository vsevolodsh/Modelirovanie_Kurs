namespace Modelirovanie_Kurs
{
    public partial class Form1 : Form
    {
        Variables variables = new();
        ModelMircoProg mmp;
        bool isFirstMode = true; 
        Label[] arrStartValueA;
        Label[] arrStartValueB;
        Label[] arrResValueB;
        Label[] arrResValueAM;
        Label[] arrResValueC;
        string strValueA = "";
        string strValueB = "";
        public Form1()
        {
            InitializeComponent();
            mmp = new ModelMircoProg(variables);

            arrStartValueA = new Label[] {labelStartValueA0, labelStartValueA1, labelStartValueA2, labelStartValueA3, labelStartValueA4, labelStartValueA5,
                labelStartValueA6, labelStartValueA7, labelStartValueA8, labelStartValueA9, labelStartValueA10, labelStartValueA11, labelStartValueA12,
                labelStartValueA13, labelStartValueA14, labelStartValueA15};

            arrStartValueB = new Label[] {labelStartValueB0, labelStartValueB1, labelStartValueB2, labelStartValueB3, labelStartValueB4, labelStartValueB5,
                labelStartValueB6, labelStartValueB7, labelStartValueB8, labelStartValueB9, labelStartValueB10, labelStartValueB11,labelStartValueB12,
                labelStartValueB13, labelStartValueB14, labelStartValueB15};

            arrResValueB = new Label[] {labelResValueB15, labelResValueB14, labelResValueB13, labelResValueB12, labelResValueB11, labelResValueB10,
                labelResValueB9, labelResValueB8, labelResValueB7, labelResValueB6, labelResValueB5, labelResValueB4,labelResValueB3,
                labelResValueB2, labelResValueB1, labelResValueB0};
        }

        private void labelStartValue_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Text = lbl.Text.Equals("0") ? "1" : "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = arrStartValueA.Length-1; i >= 0; i--)
            {
                strValueA += arrStartValueA[i].Text;
                strValueB += arrStartValueB[i].Text;
            }
            ushort a = Convert.ToUInt16(strValueA, 2);
            ushort b = Convert.ToUInt16(strValueB, 2);
            MessageBox.Show($"a = {a},  " + strValueA + $"\n b = {b}, " + strValueB);
            strValueA = "";
            strValueB = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ìîäåëèðîâàíèåÍàÓðîâíåÌèêðîïðîãðàììûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isFirstMode = true;
        }

        private void ìîäåëèðîâàíèåÍàÓðîâíåÂçàèìîäåéñòâèÿÓÀÈÎÀToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isFirstMode = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonTact.Enabled = true;
            mmp.X0 = true;
            for (int i = arrStartValueA.Length - 1; i >= 0; i--)
            {
                strValueA += arrStartValueA[i].Text;
                strValueB += arrStartValueB[i].Text;
            }
            variables.A = Convert.ToUInt16(strValueA, 2);
            variables.B = Convert.ToUInt16(strValueB, 2);
            strValueA = "";
            strValueB = "";
        }

        private void buttonTact_Click(object sender, EventArgs e)
        {
            if (isFirstMode)
            {
                mmp.ExecuteTact();
                UpdateVar();
            }
            
        }

        private void UpdateVar()
        {
            char[] arrChar = variables.ToCharArray(variables.B);
            for (int i = 0; i < arrChar.Length; i++)
            {
                arrResValueB[i].Text = arrChar[i].ToString();
            }
        }
    }
}
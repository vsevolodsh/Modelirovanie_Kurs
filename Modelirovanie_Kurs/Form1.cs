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
        Label[] arrResValueA;
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

            arrResValueA = new Label[] {labelResValueA0, labelResValueA1, labelResValueA2, labelResValueA3, labelResValueA4, labelResValueA5,
                labelResValueA6, labelResValueA7, labelResValueA8, labelResValueA9, labelResValueA10, labelResValueA11,labelResValueA12,
                labelResValueA13, labelResValueA14, labelResValueA15};

            arrResValueB = new Label[] {labelResValueB0, labelResValueB1, labelResValueB2, labelResValueB3, labelResValueB4, labelResValueB5,
                labelResValueB6, labelResValueB7, labelResValueB8, labelResValueB9, labelResValueB10, labelResValueB11,labelResValueB12,
                labelResValueB13, labelResValueB14, labelResValueB15};
        }

        private void labelStartValue_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Text = lbl.Text.Equals("0") ? "1" : "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = arrStartValueA.Length - 1; i >= 0; i--)
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

        private void моделированиеЌа”ровнећикропрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isFirstMode = true;
        }

        private void моделированиеЌа”ровне¬заимодействи€”ј»ќјToolStripMenuItem_Click(object sender, EventArgs e)
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
                if (mmp.ArrStateA[0])
                {
                    MessageBox.Show($"”множение окончено. –езультат: {variables.C}");
                }
            }

        }

        private void UpdateVar()
        {
            char[] arrCharB = variables.ToCharArray(variables.B);
            char[] arrCharA = variables.ToCharArray(variables.A);
            for (int i = 0; i < arrResValueB.Length; i++)
            {
                if (i <= arrCharB.Length - 1)
                    arrResValueB[i].Text = arrCharB[i].ToString();
                else
                    arrResValueB[i].Text = "0";
            }
            for (int i = 0; i < arrResValueA.Length; i++)
            {
                if (i <= arrCharA.Length - 1)
                    arrResValueA[i].Text = arrCharA[i].ToString();
                else
                    arrResValueA[i].Text = "0";
            }

        }

    }
}

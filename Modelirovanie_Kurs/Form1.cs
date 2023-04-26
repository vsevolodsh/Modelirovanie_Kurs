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

            arrResValueAM = new Label[] {labelResValueAM0, labelResValueAM1, labelResValueAM2, labelResValueAM3, labelResValueAM4, labelResValueAM5,
                labelResValueAM6, labelResValueAM7, labelResValueAM8, labelResValueAM9, labelResValueAM10, labelResValueAM11,labelResValueAM12,
                labelResValueAM13, labelResValueAM14, labelResValueAM15, labelResValueAM16, labelResValueAM17, labelResValueAM18, labelResValueAM19, labelResValueAM20,
                labelResValueAM21,labelResValueAM22, labelResValueAM23, labelResValueAM24, labelResValueAM25, labelResValueAM26,
                labelResValueAM27,labelResValueAM28, labelResValueAM29, labelResValueAM30, labelResValueAM31};

            arrResValueC = new Label[] {labelResValueC0, labelResValueC1, labelResValueC2, labelResValueC3, labelResValueC4, labelResValueC5,
                labelResValueC6, labelResValueC7, labelResValueC8, labelResValueC9, labelResValueC10, labelResValueC11,labelResValueC12,
                labelResValueC13, labelResValueC14, labelResValueC15, labelResValueC16, labelResValueC17, labelResValueC18, labelResValueC19, labelResValueC20,
                labelResValueC21,labelResValueC22, labelResValueC23, labelResValueC24, labelResValueC25, labelResValueC6,
                labelResValueC27,labelResValueC28, labelResValueC29, labelResValueC30, labelResValueC31};
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
            radioButtonA0.Checked = true;
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
                UpdateInterfaceFlags();
                if (mmp.ArrStateA[0])
                {

                    MessageBox.Show($"”множение окончено. –езультат: {variables.C}");
                }
            }

        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            if (isFirstMode)
            {
                do
                {
                    mmp.ExecuteTact();
                    UpdateVar();
                    UpdateInterfaceFlags();
                } while (!mmp.ArrStateA[0]);
                MessageBox.Show($"”множение окончено. –езультат: {variables.C}");
            }
            buttonAuto.Enabled = false;
        }

        private void UpdateVar()
        {
            char[] arrCharB = variables.ToCharArray(variables.B);
            char[] arrCharA = variables.ToCharArray(variables.A);
            char[] arrCharAM = variables.ToCharArray(variables.AM);
            char[] arrCharC = variables.ToCharArray(variables.C);
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

            for (int i = 0; i < arrResValueAM.Length; i++)
            {
                if (i <= arrCharAM.Length - 1)
                    arrResValueAM[i].Text = arrCharAM[i].ToString();
                else
                    arrResValueAM[i].Text = "0";
            }

            for (int i = 0; i < arrResValueC.Length; i++)
            {
                if (i <= arrCharC.Length - 1)
                    arrResValueC[i].Text = arrCharC[i].ToString();
                else
                    arrResValueC[i].Text = "0";
            }

        }

        private void UpdateInterfaceFlags()
        {
            if (isFirstMode)
            {
                if (mmp.ArrStateA[0])
                {
                    radioButtonA0.Checked = false;
                    radioButtonA2.Checked = false;
                    if (variables.YBoolArray[0])
                        checkBoxY1.Checked = true;
                    if (variables.YBoolArray[9])
                        checkBoxY10.Checked = true;
                    radioButtonA4.Checked = true;
                }
                else if (mmp.ArrStateA[1])
                {
                    radioButtonA0.Checked = false;
                    checkBoxY1_Y4.Checked = true;
                    radioButtonA1.Checked = true;
                }
                else if (mmp.ArrStateA[2])
                {
                    if (mmp.leftCircleBranch)
                    {
                        checkBoxY5_Y8.Checked = false;
                        checkBoxY6_Y8.Checked = true;
                    }
                    else
                    {
                        checkBoxY6_Y8.Checked = false;
                        checkBoxY5_Y8.Checked = true;   
                    }
                    radioButtonA1.Checked = false;
                    radioButtonA2.Checked = true;
                }
                else 
                {
                    radioButtonA2.Checked = false;
                    checkBoxY9.Checked = true;
                    radioButtonA3.Checked = true;
                }
            }
        }
       

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }
    }
}

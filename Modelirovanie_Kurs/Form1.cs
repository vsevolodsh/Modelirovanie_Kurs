namespace Modelirovanie_Kurs
{
    public partial class Form1 : Form
    {
        Variables variables = new();
        ModelMircoProg mmp;
        StateAndConditionsMemory stAndCndtMemory = new();
        CombinationScheme_Y cmbScheme_Y = new();
        CombinationScheme_D cmbScheme_D = new();
        OperatingDevice operatingDevice;
        ControlDevice controlDevice;
        bool isMicroProgMode = true;
        Label[] arrStartValueA;
        Label[] arrStartValueB;
        Label[] arrResValueB;
        Label[] arrResValueA;
        Label[] arrResValueAM;
        Label[] arrResValueC;
        Label[] arrCurrentCount;
        string strValueA = "";
        string strValueB = "";
        bool isOver = false;
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

            arrCurrentCount = new Label[] { labelCount0, labelCount1, labelCount2, labelCount3, labelCount4, labelCount5, labelCount6, labelCount7 };
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

        private void моделированиеЌа”ровнећикропрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isMicroProgMode = true;
        }

        private void моделированиеЌа”ровне¬заимодействи€”ј»ќјToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isMicroProgMode = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            radioButtonA0.Checked = true;
            buttonTact.Enabled = true;

            for (int i = arrStartValueA.Length - 1; i >= 0; i--)
            {
                strValueA += arrStartValueA[i].Text;
                strValueB += arrStartValueB[i].Text;
            }
            variables.A = Convert.ToUInt16(strValueA, 2);
            variables.B = Convert.ToUInt16(strValueB, 2);
            strValueA = "";
            strValueB = "";
            if (isMicroProgMode && checkBoxX0.Checked)
            {
                mmp.X0 = true;
            }
            else
            {
                operatingDevice = new(variables, this);
                operatingDevice.FillConditionsXArray();
                stAndCndtMemory.ConditionsX = operatingDevice.ConditionsX;
                controlDevice = new(stAndCndtMemory, cmbScheme_D, cmbScheme_Y, operatingDevice);
                controlDevice.ExecuteTact();
            }
        }
        bool firstTact = true;
        private void buttonTact_Click(object sender, EventArgs e)
        {
            if (isMicroProgMode)
            {
                mmp.ExecuteTact();
                UpdateVar();
                UpdateInterfaceFlags();
                if (mmp.ArrStateA[0])
                {
                    MessageBox.Show($"”множение окончено. –езультат: {variables.C}");
                    buttonTact.Enabled = false;
                }
            }
            else
            {

                controlDevice.ExecuteTact();
                UpdateVar();
                UpdateInterfaceFlags();
                if (stAndCndtMemory.ArrStateA[0] && isOver)
                {
                    MessageBox.Show($"”множение окончено. –езультат: {variables.C}");
                    buttonTact.Enabled = false;
                }
            }

        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            if (isMicroProgMode)
            {
                do
                {
                    mmp.ExecuteTact();
                    UpdateVar();
                    UpdateInterfaceFlags();
                } while (!mmp.ArrStateA[0]);
                MessageBox.Show($"”множение окончено. –езультат: {variables.C}");
            }
            else
            {
                do
                {
                    controlDevice.ExecuteTact();
                    UpdateVar();
                    UpdateInterfaceFlags();
                } while (!isOver);
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
            char[] arrCharCount = variables.ToCharArray(variables.Count);
            //for (int i = 0; i < arrResValueB.Length; i++)
            //{
            //    if (i <= arrCharB.Length - 1)
            //        arrResValueB[i].Text = arrCharB[i].ToString();
            //    else
            //        arrResValueB[i].Text = "0";
            //}
            for (int i = 0; i < arrResValueA.Length; i++)
            {
                if (i <= arrCharA.Length - 1)
                    arrResValueA[i].Text = arrCharA[i].ToString();
                else
                    arrResValueA[i].Text = "0";
                if (i <= arrCharB.Length - 1)
                    arrResValueB[i].Text = arrCharB[i].ToString();
                else
                    arrResValueB[i].Text = "0";
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
            for (int i = 0; i < arrCurrentCount.Length; i++)
            {
                if (i <= arrCharCount.Length - 1)
                    arrCurrentCount[i].Text = arrCharCount[i].ToString();
                else
                    arrCurrentCount[i].Text = "0";
            }
        }

        private void UpdateInterfaceFlags()
        {
            bool[] statesA = new bool[4];
            if (isMicroProgMode)
            {
                statesA = mmp.ArrStateA;
            }
            else
            {
                statesA = stAndCndtMemory.ArrStateA;
            }
            SetAllFlagsFalse();
            if (statesA[0])
            {
                if ((mmp.IsCSet0 || cmbScheme_Y.OperationsY[0]) && firstTact)
                {
                    checkBoxY1.Checked = true;
                    radioButtonA4.Checked = true;
                }
                else if ((mmp.IsCNegative || cmbScheme_Y.OperationsY[9]) && !firstTact)
                {
                    checkBoxY10.Checked = true;
                    radioButtonA4.Checked = true;
                }
                else
                {
                    radioButtonA4.Checked = true;
                }
                isOver = true;
            }
            else if (statesA[1])
            {
                checkBoxY1_Y4.Checked = true;
                radioButtonA1.Checked = true;
                firstTact = false;
                checkBoxX0.Checked = false;
            }
            else if (statesA[2])
            {
                if (mmp.RightCircleBranch || cmbScheme_Y.OperationsY[4])
                {
                    checkBoxY5_Y8.Checked = true;
                }
                else
                {
                    checkBoxY6_Y8.Checked = true;
                }
                radioButtonA2.Checked = true;
            }
            else if (statesA[3])
            {
                checkBoxY9.Checked = true;
                radioButtonA3.Checked = true;
            }
        }

        private void SetAllFlagsFalse()
        {
            radioButtonA0.Checked = false;
            radioButtonA1.Checked = false;
            radioButtonA2.Checked = false;
            radioButtonA3.Checked = false;
            radioButtonA4.Checked = false;
            checkBoxY1.Checked = false;
            checkBoxY1_Y4.Checked = false;
            checkBoxY5_Y8.Checked = false;
            checkBoxY6_Y8.Checked = false;
            checkBoxY9.Checked = false;
            checkBoxY10.Checked = false;

        }
    }
}

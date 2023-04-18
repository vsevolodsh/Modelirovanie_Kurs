namespace Modelirovanie_Kurs
{
    public partial class Form1 : Form
    {
        Label[] arrStartValueA;
        Label[] arrStartValueB;
        string strValueA = "";
        string strValueB = "";
        ushort a;
        ushort b;
        public Form1()
        {
            InitializeComponent();
            arrStartValueA = new Label[] {labelStartValueA0, labelStartValueA1, labelStartValueA2, labelStartValueA3, labelStartValueA4, labelStartValueA5,
                labelStartValueA6, labelStartValueA7, labelStartValueA8, labelStartValueA9, labelStartValueA10, labelStartValueA11, labelStartValueA12,
                labelStartValueA13, labelStartValueA14, labelStartValueA15};
            arrStartValueB = new Label[] {labelStartValueB0, labelStartValueB1, labelStartValueB2, labelStartValueB3, labelStartValueB4, labelStartValueB5,
                labelStartValueB6, labelStartValueB7, labelStartValueB8, labelStartValueB9, labelStartValueB10, labelStartValueB11,labelStartValueB12,
                labelStartValueB13, labelStartValueB14, labelStartValueB15};
            //ushort b = 0b1000_0000_0000_0011;
            ////ushort a = 3;
            ////ushort b = 2;
            ////ushort m = 0x4000;
            //uint c, am;
            //byte count = 0;
            //if ((a & 0x7fff) == 0 || (b & 0x7fff) == 0)
            //{
            //    c = 0;
            //    Console.WriteLine(c);
            //}
            //else
            //{
            //    c = 0;
            //    am = (uint)((a << 15) >> 1);
            //    count = 0xF;
            //    while (count != 0)
            //    {
            //        if ((b & 0x4000) != 0)
            //        {
            //            c = c + am;
            //            b = (ushort)(((b << 1) & 0x7fff) | (b & 0x8000));
            //            am = am >> 1;
            //            count--;
            //        }
            //        else
            //        {
            //            b = (ushort)(((b << 1) & 0x7fff) | (b & 0x8000));

            //            am = am >> 1;
            //            count--;
            //        }
            //    }
            //    //if ((c & 0x4000) != 0)
            //    //{
            //    //    Console.WriteLine(Convert.ToString(c, toBase: 2));
            //    //    c = c + 0x8000;
            //    //    Console.WriteLine(Convert.ToString(c, toBase: 2));
            //    //}
            //    Console.WriteLine(Convert.ToString(c, toBase: 2));
            //    Console.WriteLine(c);
            //    if ((a >> 15 ^ b >> 15) == 1)
            //    {
            //        c = ~c + 1;
            //        Console.WriteLine(Convert.ToString(c, toBase: 2));
            //        Console.WriteLine(c);
            //        //int ads = (int)c;
            //        //ads = ~ads + 1;
            //        //Console.WriteLine(Convert.ToString(ads, toBase: 2));
            //        //Console.WriteLine(ads);
            //    }
            //}
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
            a = Convert.ToUInt16(strValueA, 2);
            b = Convert.ToUInt16(strValueB, 2);
            MessageBox.Show($"a = {a},  " + strValueA + $"\n b = {b}, " + strValueB);
            strValueA = "";
            strValueB = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
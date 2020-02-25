using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Zahlenrechner
{
    public partial class Form1 : Form
    {
        int zahl1, dezimalzahl,switchcase;
        string dual, oktal, dez, hexa;
        Color backgroundColor = Color.FromArgb(206, 212, 221);
        Color fontColor= Color.FromArgb(14, 28, 51);
        Font drawFont = new Font("Artifakt Element", 13);


        public Form1()
        {    
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 backform = new Form1();

            panel1.Top = backform.Top;
            panel1.Width = backform.Width;
            panel1.Height = 30;
            panel1.BackColor = Color.FromArgb(218,222,230);

            panel2.Top = panel1.Height;
            panel2.Height = backform.Height;
            panel2.Left = backform.Left;
            panel2.Width = backform.Width;
            panel2.BackColor = backgroundColor;

            pictureBox1.Left = 506;
            pictureBox1.Top = 7;
            pictureBox1.Width = 15;
            pictureBox1.Height = 15;
            
            
        }
        //상단바 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = panel1.CreateGraphics();
            SolidBrush drawbrush = new SolidBrush(Color.FromArgb(14,28,51));
            canvas.DrawString("Zahlensystem", new Font("Alef", 16), drawbrush, new Point(5, 3));
        }

        //Table 
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics table = panel4.CreateGraphics();
            Pen blackPen = new Pen(Color.Black);
            blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            for (int i = 1; i <= 5; i++)
            {
                table.DrawLine(blackPen, 0, 30 * i, 330, 30 * i);
            }
            table.DrawLine(blackPen, 330 / 2, 0, 330 / 2, 150);
            SolidBrush drawPaint = new SolidBrush(Color.Black);
            drawPaint.Color = Color.Gray;
            table.FillRectangle(drawPaint, 0, 0, 330, 30);
            drawPaint.Color = Color.Black;
            Font drawFont = new Font("Artifakt Element", 13);
            table.DrawString("Zahlensystem", drawFont, drawPaint, 6, 6);
            table.DrawString("Binär", drawFont, drawPaint, 6, 36);
            table.DrawString("Oktal", drawFont, drawPaint, 6, 66);
            table.DrawString("Dezimal", drawFont, drawPaint, 6, 96);
            table.DrawString("Hexadezimal", drawFont, drawPaint, 6, 126);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rechnen();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //dual
            if (radioButton1.Checked == true)
                switchcase=1;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //oktal
            if (radioButton2.Checked == true)
                switchcase = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //dezimal
            if (radioButton3.Checked == true)
                switchcase = 3;
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //hexadezimal
            if (radioButton4.Checked == true)
                switchcase = 4;
        }

        void rechnen()
        {
            //Clear
            Graphics table = panel4.CreateGraphics();
            SolidBrush drawPaint = new SolidBrush(Color.FromArgb(206, 212, 221));
            table.FillRectangle(drawPaint, 170, 125, 150, 25);
            table.FillRectangle(drawPaint, 170, 35, 150, 25);
            table.FillRectangle(drawPaint, 170, 65, 150, 25);
            table.FillRectangle(drawPaint, 170, 95, 150, 25);

            zahl1 = Convert.ToInt32(textBox1.Text);

            switch (switchcase)
            {
                //dual
                case 1:
                    try
                    {
                        dual = zahl1.ToString();
                        dezimalzahl = Convert.ToInt32(dual, 2);
                        dez = dezimalzahl.ToString();
                        oktal = Convert.ToString(dezimalzahl, 8);
                        hexa = Convert.ToString(dezimalzahl, 16);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Die gegebene Zahl ist nicht binär", "ERROR", MessageBoxButtons.OK);
                        panel4.BackColor = backgroundColor;
                        table.DrawString("Die gegebene Zahl ist nicht binär", new Font("Artifakt Element", 13), drawPaint, 5, 5);
                    }
                    break;

                //oktal
                case 2:
                    oktal = zahl1.ToString();
                    dezimalzahl = Convert.ToInt32(oktal, 8);
                    dez = dezimalzahl.ToString();
                    dual = Convert.ToString(dezimalzahl, 2);
                    hexa = Convert.ToString(dezimalzahl, 16);
                    break;

                //dezimal
                case 3:
                    dezimalzahl = zahl1;
                    dual = Convert.ToString(dezimalzahl, 2);
                    oktal = Convert.ToString(dezimalzahl, 8);
                    dez = dezimalzahl.ToString();
                    hexa = Convert.ToString(dezimalzahl, 16);
                    break;

                //hexa
                case 4:
                    hexa = Convert.ToString(zahl1);
                    dezimalzahl = Convert.ToInt32(hexa, 16);
                    dez = dezimalzahl.ToString();
                    dual = Convert.ToString(dezimalzahl, 2);
                    oktal = Convert.ToString(dezimalzahl, 8);
                    break;
            }

            //paint
            drawPaint.Color = Color.Black;
            Font drawFont = new Font("Artifakt Element", 13);

            table.DrawString(dual, drawFont, drawPaint, 175, 36);
            table.DrawString(oktal, drawFont, drawPaint, 175, 66);
            table.DrawString(dez, drawFont, drawPaint, 175, 96);
            table.DrawString(hexa, drawFont, drawPaint, 175, 126);

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            rechnen();
        }
                
    }
}

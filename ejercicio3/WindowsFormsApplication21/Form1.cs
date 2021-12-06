using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication21
{
    public partial class Form1 : Form
    {
        string cadConection = "Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=examen;Integrated Security=True";
        int cR, cG, cB;
        int sumaR, sumaG, sumaB;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(10,10);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           /* Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            cR = c.R;
            cG = c.G;
            cB = c.B;*/
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int x, y, mR = 0, mG = 0, mB = 0;
            x = e.X;
            y = e.Y;
            for (int i = x; i < x+10;i++ )
            {
                for (int j = y; j < y+10; j++) {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            }

            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            cR = mR;
            cG = mG;
            cB = mB; 
            textBox1.Text = cR.ToString();
            textBox2.Text = cG.ToString();
            textBox3.Text = cB.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(c.R,0,0));
                }   
            pictureBox2.Image = cpoa;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            pictureBox2.Image = cpoa;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, Color.FromArgb(0, 0, c.B));
                }
            pictureBox2.Image = cpoa;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if ((cR - 10 < c.R && c.R < cR + 10) && (cG - 10 < c.G && c.G < cG + 10) && (cB - 10 < c.B && c.B < cB + 10) && cR == c.R && cB == c.B && cG == c.G)
                        cpoa.SetPixel(i, j, Color.Black);
                    else
                        cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int meR, meG, meb;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width-10; i+=10)
                for (int j = 0; j < bmp.Height-10; j += 10)
                {
                    meR = 0; 
                    meG = 0; 
                    meb = 0;
                    for (int k = i; k < i+10; k++)
                        for (int l = j; l < j + 10; l++) {
                            c = bmp.GetPixel(k, l);
                            meR = meR +c.R;
                            meG = meG+c.G;
                            meb = meb+c.B;
                        }
                    meb = meb / 100;
                    meR = meR / 100;
                    meG = meG / 100;



                    if ((cR - 10 < meR && meR < cR + 10) && (cG - 10 < meG && meG < cG + 10) && (cB - 10 < meb && meb < cB + 10) && cR == meR && cB == meb && cG == meG)
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Black);

                            }

                    }
                    else { 
                     for (int k = i; k < i+10; k++)
                         for (int l = j; l < j + 10; l++) {
                             c = bmp.GetPixel(k, l);
                             cpoa.SetPixel(k, l, c);
                            
                         }
                    }
                }

            pictureBox2.Image = cpoa;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Image);
            Bitmap bc = new Bitmap(b.Width, b.Height);
            Color c = new Color();
            int sumaR1, sumaG1, sumaB1;
            for (int i = 0; i < b.Width - 10; i = i + 10)
                for (int j = 0; j < b.Height - 10; j = j + 10)
                {
                    sumaR1 = 0;
                    sumaG1 = 0;
                    sumaB1 = 0;
                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = b.GetPixel(k, l);
                            sumaR1 = sumaR1 + c.R;
                            sumaG1 = sumaG1 + c.G;
                            sumaB1 = sumaB1 + c.B;
                        }
                    sumaR1 = sumaR1 / 100;
                    sumaG1 = sumaG1 / 100;
                    sumaB1 = sumaB1 / 100;
                    if ((sumaR1 > sumaR - 20 && sumaR1 < sumaR + 20) && (sumaG1 > sumaG - 20 && sumaG1 < sumaG + 20) && (sumaB1 > sumaB - 20 && sumaB1 < sumaB + 20))
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                bc.SetPixel(k, l, Color.FromArgb(0, 0, 0));
                            }
                    }
                    else
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = b.GetPixel(k, l);
                                bc.SetPixel(k, l, Color.FromArgb(c.R, c.G, c.B));
                            }
                    }
                }
            pictureBox1.Image = b;
            pictureBox2.Image = bc;
        }

    }
}

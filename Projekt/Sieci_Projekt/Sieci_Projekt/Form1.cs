using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sieci_Projekt
{
    public partial class Form1 : Form
    {
        Siec meNet;
        public Form1()
        {
            InitializeComponent();
            uint[] topologia = { 35, 10, 26 };
            meNet = new Siec(topologia);
            
            IMG.Image = new Bitmap(400, 400);
            g = Graphics.FromImage(IMG.Image);
            pioro = new Pen(Color.Black,12);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var doubles = File.ReadAllText("Dane.txt")
              .Split(new[] { " ", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
              .Select(s => double.Parse(s, CultureInfo.GetCultureInfo("en-US"))).ToArray();

            double[,] data = new double[26,35];
            double[,] target = new double[26,26];

           
            
                for (int i = 0,k=0; i < doubles.Length; i += 26 + 35,k++)
                {
                    for (int j = 0; j < 35; j++)
                    {
                        data[k,j] = Convert.ToDouble(doubles[i + j]);
                    }
                    for (int j = 0; j < 26; j++)
                    {
                        target[k,j] = Convert.ToDouble(doubles[i + j + 35]);
                    }
                    
                    


                }

                for (int i = 0; i < 5000; i++)
                {
                    double[] d = new double[35];
                    double[] t = new double[26];
                    for (int j = 0; j < 26; j++)
                    {

                        t[j] = target[i%26, j];
                    }
                    for (int j = 0; j < 35; j++)
                    {

                        d[j] = data[i % 26, j];
                    }
                    meNet.feed(d);
                    meNet.backProp(t);
                }



            Random rand = new Random();

                for (int i = 0; i < 500000;i++ )
                {

                    int k = rand.Next(25);
                    double[] d = new double[35];
                    double[] t = new double[26];
                    for (int j = 0; j < 26; j++)
                    {

                        t[j] = target[k, j];
                    }
                    for (int j = 0; j < 35; j++)
                    {

                        d[j] = data[k, j];
                    }                    
                    meNet.feed(d);
                    meNet.backProp(t);
                }

                for (int i = 0; i < 2000; i++)
                {
                    double[] d = new double[35];
                    double[] t = new double[26];
                    for (int j = 0; j < 26; j++)
                    {

                        t[j] = target[i % 26, j];
                    }
                    for (int j = 0; j < 35; j++)
                    {

                        d[j] = data[i % 26, j];
                    }
                    meNet.feed(d);
                    meNet.backProp(t);
                }

        }

        private Graphics g;
        private Point p = Point.Empty;
        private Pen pioro;

        private void IMG_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p = e.Location;
        }

        private void IMG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(pioro, p, e.Location);
                p = e.Location;
                IMG.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] data = new double[35];
            for (int i = 0; i < 35;i++ )
            {
                data[i] = 0;
            }
                litera.Text = null;
            Color color;
            for (int i = 0,k=0; i < 7; i++)
            {
                for(int j=0;j<5;j++)
                {
                    Bitmap b = new Bitmap(IMG.Image);
                    
                    for (int x = 0; x < 20; x++)
                    { 
                        for(int y=0;y<20;y++)
                        {
                            color = b.GetPixel((j * 20) + x, (i * 20) + y);
                            if (color.A == 255)
                            {
                                data[k] += 1;
                            }
                        }
                    }
                        
                    k++;
                }
                
            }
            for (int i = 0; i < 35; i++)
            {
                data[i] /=400 ;
            }
            
            meNet.feed(data);
            litera.Text=((char) (meNet.getMax()+65)).ToString();
            IMG.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IMG.Image = new Bitmap(400, 400);
            g = Graphics.FromImage(IMG.Image);
        }
       
    }
}

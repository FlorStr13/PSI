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

            double[] data = new double[35];
            double[] target = new double[26];

            meNet.feed(data);
            meNet.backProp(target);

            for (int n = 0; n < 15000; n++) 
            { 
                for (int i = 0; i < doubles.Length; i += 26 + 35)
                {
                    for (int j = 0; j < 35; j++)
                    {
                        data[j] = Convert.ToDouble(doubles[i + j]);
                    }
                    for (int j = 0; j < 26; j++)
                    {
                        target[j] = Convert.ToDouble(doubles[i + j + 35]);
                    }

                    meNet.feed(data);
                    meNet.backProp(target);
                }
            }   

            double[] test = {1 ,0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1};
            
            meNet.feed(test);
            meNet.feed(test);
            int litera=meNet.getMax();

            meNet.GetType();
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

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

            for (int n = 0; n < 10000; n++) 
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

            double[] test = {0 ,1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1};
            
            meNet.feed(test);
            meNet.GetType();
        }

        
    }
}

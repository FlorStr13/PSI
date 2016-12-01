using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sieci_Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint[] topologia = { 2, 1 };
            double[] data = { 0.0, 0.0 };
            Siec meNet = new Siec(topologia);
            double[] results=meNet.getResults(data);
            meNet.GetType();
        }
    }
}

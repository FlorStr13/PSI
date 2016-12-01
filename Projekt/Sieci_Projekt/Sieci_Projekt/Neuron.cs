using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieci_Projekt
{
    class Neuron
    {
        double output;
        double waga;
        static Random random = new Random();
        public Neuron()
        {
            
            waga = random.NextDouble();
        }

        public void setOutput(double output)
        {
            this.output = output;
        }

        public double getResult()
        {
            return waga * output;
        }

        static public double activationFunction(double x)
        {
            return Math.Tanh(x);
        }

        public double getOutput()
        {
            return output;
        }
    }
}

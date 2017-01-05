using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieci_Projekt
{
    class Neuron
    {
        
        public int index;
        public double output;
        public double[] wagi;
        public double[] delta;
        public double gradient;
        static Random random = new Random();

        public Neuron(uint w , int i)
        {
            gradient = 0;
            output = 1;
            this.index = i;
            wagi = new double[w];
            delta = new double[w];
            for(int j =0;j<wagi.Length;j++)
            {
                wagi[j] = random.NextDouble();
                delta[j] = 0;
            }
        }

        public void feed(Neuron[] poprzednia)
        {
            double suma=0;

            for (int i = 0; i < poprzednia.Length; i++)
            {
                suma += poprzednia[i].output * poprzednia[i].wagi[index];
            }

            output = funkcjaAktywacji(suma);
        }
       
        public double funkcjaAktywacji(double x)
        {
            return Math.Tanh(x);
        }

        public double transferFunctionDerivative(double x)
        {
            return 1.0 - x * x;
        }

        public void calcOutputGradients(double target)
        {
            double delta = target - output;
            gradient = delta * transferFunctionDerivative(output);
        }


        double sumDOW( Warstwa nextLayer) 
        {
            double sum = 0.0;

            // Sum our contributions of the errors at the nodes we feed.

            for (int n = 0; n < nextLayer.neurony.Length - 1; ++n) {
            sum += wagi[n] * nextLayer.neurony[n].gradient;
             }

         return sum;
        }

        public void calcHiddenGradients( Warstwa nextLayer)
        {
            double dow = sumDOW(nextLayer);
            gradient = dow * transferFunctionDerivative(output);
        }


        public void updateInputWeights(Warstwa prevLayer,double eta,double alpha)
        {
    // The weights to be updated are in the Connection container
    // in the neurons in the preceding layer

            for (int n = 0; n < prevLayer.neurony.Length; ++n) 
            {
                Neuron neuron = prevLayer.neurony[n];
                double oldDeltaWeight = neuron.delta[index];

                double newDeltaWeight =
            // Individual input, magnified by the gradient and train rate:
                eta
                * neuron.output
                * gradient
            // Also add momentum = a fraction of the previous delta weight;
                + alpha
                * oldDeltaWeight;

                neuron.delta[index] = newDeltaWeight;
                neuron.wagi[index] += newDeltaWeight;
            }
}
    }
}

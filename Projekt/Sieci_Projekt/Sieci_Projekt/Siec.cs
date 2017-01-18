using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieci_Projekt
{
    class Siec
    {
      
        public Warstwa[] warstwy;
        public double error;
        double eta;   //wspolczynik ucznia
        double alpha;  // szybkosc/moment uczenia


        public Siec(uint[] topologia)
        {
            eta = 0.15;  
            alpha = 0.5;
            error = 0;
            warstwy = new Warstwa[topologia.Length];
            for (int i=0 ;i<topologia.Length;i++)
            {
                if (i < topologia.Length - 1)
                {
                    warstwy[i] = new Warstwa(topologia[i]+1, topologia[i + 1]+1);
                }
                else
                {
                    warstwy[i] = new Warstwa(topologia[i]+1, 0);
                }
            }
        }

        public void feed(double[] data)
        {
            //ustawianie danych na 1 warstwie
            for (int i = 0; i < data.Length; i++)
            {
                warstwy[0].neurony[i].output=data[i];
            }

            for (int i = 1; i < warstwy.Length; i++)
            {
                int n = warstwy[i].neurony.Length-1;
                Neuron[] poprzedniaWarstwa = warstwy[i - 1].neurony;
                // petla po wszystkich neuronach w warstwie
                for (int j = 0; j < n; j++)
                {
                    warstwy[i].neurony[j].feed(poprzedniaWarstwa);     
                }
            }
        }

        public double[] getResults()
        {
            double[] results=new double[warstwy[warstwy.Length - 1].neurony.Length-1];
            for (int i = 0; i < warstwy[warstwy.Length - 1].neurony.Length-1; i++)
            {
                results[i] = warstwy[warstwy.Length - 1].neurony[i].output;
            }

            return results;
        }

        public void backProp(double[] target)
        {
            error = 0;
            //liczenie bleu na warstwie wyjsciowej
            for(int i=0;i<warstwy[warstwy.Length-1].neurony.Length-1;i++)
            {
                double delta = target[i] - warstwy[warstwy.Length - 1].neurony[i].output;
                error += delta * delta;
            }

            error /= warstwy[warstwy.Length - 1].neurony.Length-1;
            error = Math.Sqrt(error);

            //liczenie gradienta warstwy wyjsciowej
            for (int n = 0; n < warstwy[warstwy.Length - 1].neurony.Length - 1; ++n)
            {
                warstwy[warstwy.Length - 1].neurony[n].calcOutputGradients(target[n]);
            }

            //liczenie gradientu poprzednich warstw

            for (int layerNum = warstwy.Length - 2; layerNum > 0; --layerNum)
            {
                Warstwa hiddenLayer = warstwy[layerNum];
                Warstwa nextLayer = warstwy[layerNum + 1];

                for (int n = 0; n < hiddenLayer.neurony.Length; ++n)
                {
                    hiddenLayer.neurony[n].calcHiddenGradients(nextLayer);
                }
            }

            //updata wag na karzdym neuronie
            for (int  layerNum = warstwy.Length - 1; layerNum > 0; --layerNum)
            {
                Warstwa layer = warstwy[layerNum];
                Warstwa prevLayer = warstwy[layerNum - 1];

                for (int n = 0; n < layer.neurony.Length - 1; ++n)
                {
                    layer.neurony[n].updateInputWeights(prevLayer,eta,alpha);
                }
            }

           // Console.Write(error);
            //Console.WriteLine("/n");
        }

        public int getMax()
        {
            int max = 0; 
            double pom = 0;
            for (int i=0 ; i < warstwy[warstwy.Length-1].neurony.Length-2; i++)
            {
                if (warstwy[warstwy.Length - 1].neurony[i].output > pom)
                {
                    pom = warstwy[warstwy.Length - 1].neurony[i].output;
                    max = i;
                }
            }

            return max;
        }


    }
}

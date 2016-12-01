using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieci_Projekt
{
    class Siec
    {
        Warstwa[] warstwy;

        public Siec(uint[] topologia)
        {
            warstwy = new Warstwa[topologia.Length];
            for (int i = 0; i < topologia.Length; i++)
            {
                warstwy[i] = new Warstwa(topologia[i] + 1);
                warstwy[i].getNeuron((int)topologia[i]).setOutput(1.0);
            }
        }
      
        
        
        // dane przechodza przes siec i wypluwa wektor wynikow
        public double[] getResults(double[] data)
        {
            // tworzy tablice tak dloga jak ilosc wektorow na ostatniej warstwie
            double[] results = new double[warstwy[warstwy.Length-1].getNeurons().Length-1];
            //ustawianie outputu na warstwie wejscia
            for (int i = 0; i < data.Length; i++)
            {
                warstwy[0].getNeurons()[i].setOutput(data[i]);
            }
            //petla po wszystkich warstwach poza wejsciowa
            for (int i = 1; i < warstwy.Length; i++)
            {
                int n = warstwy[i].getNeurons().Length-1;
                Neuron[] poprzedniaWarstwa = warstwy[i-1].getNeurons();
               // petla po wszystkich neuronach w warstwie
                for (int j = 0; j < n; j++ )
                {
                    double output = 0;
                    //liczenie z wag i outputy z poprzedniej warstwy
                    for (int k = 0; k < poprzedniaWarstwa.Length;k++ )
                    {
                        output += poprzedniaWarstwa[k].getResult();
                    }

                    // wrzucenie do funkcji aktywacji
                    warstwy[i].getNeuron(j).setOutput(Neuron.activationFunction(output));
                }
            }

            for (int i = 0; i < warstwy[warstwy.Length - 1].getNeurons().Length-1;i++ )
            {
                results[i] = warstwy[warstwy.Length - 1].getNeuron(i).getOutput();
            }
             
            return results;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieci_Projekt
{
    class Warstwa
    {
        Neuron[] neurony;

        public Warstwa(uint n)
        {
            neurony = new Neuron[n];
            for(int i=0;i<n;i++)
            {
                neurony[i] = new Neuron();
            }
        }
        public Neuron[] getNeurons()
        {
            return neurony;
        }

        public Neuron getNeuron(int n)
        {
            return neurony[n];
        }

    }
}

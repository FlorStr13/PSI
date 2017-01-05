using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieci_Projekt
{
    class Warstwa
    {
        
        public Neuron[] neurony;

        public Warstwa(uint n , uint w)
        {
            neurony = new Neuron[n];
            for(int i=0;i<neurony.Length;i++)
            {
                neurony[i] = new Neuron(w,i);
            }
        }

    }
}

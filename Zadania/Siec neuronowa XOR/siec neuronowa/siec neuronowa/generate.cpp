#include <cstdlib>
#include <fstream>
#include "generate.h"

void generate()
{
    std::fstream plik;
    plik.open("Data.txt", std::ios::out);

   
    for (int i = 0; i < 2000; i++)
    {
        int n1 = (int)(2.0 * rand() / double(RAND_MAX));
        int n2 = (int)(2.0 * rand() / double(RAND_MAX));
        int t = n1^n2;
        plik <<n1<<" "<<n2<<" \n";
        plik  << t << " \n";
    }
    plik.close();
}

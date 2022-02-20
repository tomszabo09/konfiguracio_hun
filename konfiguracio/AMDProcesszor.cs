using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    sealed class AMDProcesszor : Processzor, IHardverElem
    {
        public AMDProcesszor(string nev, int minoseg, int ar, int powerusage, int corecount, double processingpower) : base(nev, minoseg, ar, CPUtype.AMD, powerusage, corecount, processingpower)
        {
            
        }
    }
}

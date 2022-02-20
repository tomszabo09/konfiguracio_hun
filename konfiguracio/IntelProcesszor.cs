using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    sealed class IntelProcesszor : Processzor, IHardverElem
    {
        public IntelProcesszor(string nev, int minoseg, int ar, int powerusage, int corecount = 0, double processingpower = 0) : base(nev, minoseg, ar, CPUtype.Intel, powerusage, corecount, processingpower)
        {
            
        }
    }
}

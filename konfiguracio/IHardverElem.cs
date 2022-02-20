using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    enum Típus
    {
        Processzor, Alaplap, RAM, Videókártya, Tápegység, ProcesszorHűtő
    }
    interface IHardverElem
    {
        string Név { get; }
        int Minőség { get; }
        int Ár { get; }
        Típus típus { get; set; }

        void Beépít(Számítógép pc);
        void Elromlik();
    }
}

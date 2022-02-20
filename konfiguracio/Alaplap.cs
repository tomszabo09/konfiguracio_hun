using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    public delegate void CheckComponents(string nev);
    enum Memorytype
    {
        Null, DDR2, DDR3, DDR4
    }
    enum CPUtype
    {
        Null, Intel, AMD
    }
    class Alaplap : Számítógép, IHardverElem
    {
        public string Név { get; }
        public int Minőség { get; }
        public int Ár { get; }
        public Típus típus { get; set; }
        public CPUtype Socket { get; private set; }
        public Memorytype Datarate { get; }
        public int PCIEslots { get; set; }
        public int Cpunum { get; set; }
        public int Ramslots { get; set; }
        public int Hutonum { get; set; }

        public Alaplap(string nev, int minoseg, int ar, CPUtype socket = 0, Memorytype datarate = 0, int pcieslots = 0, int ramslots = 0)
        {
            this.Név = nev;
            this.Minőség = minoseg;
            this.Ár = ar;
            this.Socket = socket;
            this.Datarate = datarate;
            this.típus = Típus.Alaplap;
            this.PCIEslots = pcieslots;
            this.Ramslots = ramslots;
            this.Cpunum = 1;
            this.Hutonum = 1;
        }
        public virtual void Beépít(Számítógép pc)
        {
            pc.SumQuality += this.Minőség;
            pc.Value += this.Ár;
            pc.MB = true;
            if (this.típus == Típus.Alaplap)
            {
                pc.mb = this;
                if (pc.MBnum == 0)
                {
                    pc.SumQuality -= this.SumQuality;
                    pc.Value -= this.Ár;
                    throw new DuplicateItemException(this.Név,this.típus);
                }
                pc.MBnum--;
            }
        }
        public virtual void Elromlik()
        {

        }
        public virtual bool Kompatibilis(Számítógép pc)
        {
            return true;
        }
    }
    class DuplicateItemException : Exception
    {
        public DuplicateItemException(string nev, Típus típus) : base($"A(z) '{nev}' nevű {típus} már nem fér el!")
        {

        }
    }
    class WrongOrderException : Exception
    {
        public WrongOrderException(Típus típus) : base($"A {típus}-t nem lehet az alaplap előtt berakni!")
        {

        }
    }
}

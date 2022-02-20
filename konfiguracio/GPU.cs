using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    sealed class GPU : Alaplap, IHardverElem
    {
        public int PowerUsage { get; }
        public int Orajel { get; }
        public int VRAM { get; }

        public GPU(string nev, int minoseg, int ar, int orajel, int vram, int powerusage) : base(nev, minoseg, ar)
        {
            this.PowerUsage = powerusage;
            this.Orajel = orajel;
            this.VRAM = vram;
            this.típus = Típus.Videókártya;
        }
        public override void Beépít(Számítógép pc)
        {
            if (pc.MBnum == 0)
            {
                this.GPUnum++;
                pc.SumPowerUsage += this.PowerUsage;
                pc.GPU = true;
                pc.mb.PCIEslots--;
                if (!this.Kompatibilis(pc))
                {
                    this.GPUnum--;
                    pc.SumPowerUsage -= this.PowerUsage;
                    throw new DuplicateItemException(this.Név,this.típus);
                }
            }
            else
                throw new WrongOrderException(this.típus);

            base.Beépít(pc);
        }
        public override bool Kompatibilis(Számítógép pc)
        {
            return pc.mb.PCIEslots >= 0;
        }
    }
}

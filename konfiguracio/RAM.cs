using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    sealed class RAM : Alaplap, IHardverElem
    {
        public Memorytype RAMFajta { get; }
        public int Memory { get; }
        public int PowerUsage { get; }
        public int Frequency { get; }

        public RAM(string nev, int minoseg, int ar, int memory, Memorytype datarate, int frequency, int powerusage) : base(nev,minoseg,ar,0,datarate)
        {
            this.Memory = memory;
            this.PowerUsage = powerusage;
            this.RAMFajta = datarate;
            this.típus = Típus.RAM;
            this.Frequency = frequency;
        }

        public event CheckComponents FalseDDR;
        public override void Beépít(Számítógép pc)
        {
            if (pc.MBnum == 0)
            {
                pc.SumPowerUsage += this.PowerUsage;
                pc.SumRAM += this.Memory;
                pc.RAM = true;
                pc.mb.Ramslots--;
                if (!this.Kompatibilis(pc))
                {
                    pc.RAM = false;
                    pc.SumPowerUsage -= this.PowerUsage;
                    pc.SumRAM -= this.Memory;
                    pc.mb.Ramslots++;
                    pc.SumQuality -= this.Minőség;
                    pc.Value -= this.Ár;
                    Elromlik();
                }
                if (pc.mb.Ramslots < 0)
                {
                    pc.SumPowerUsage -= this.PowerUsage;
                    pc.SumRAM -= this.Memory;
                    throw new DuplicateItemException(this.Név,this.típus);
                }
            }
            else
                throw new WrongOrderException(this.típus);

            base.Beépít(pc);
        }
        public override void Elromlik()
        {
            FalseDDR?.Invoke(this.Név);
        }
        public override bool Kompatibilis(Számítógép pc)
        {
            return this.RAMFajta == pc.mb.Datarate;
        }
    }
}

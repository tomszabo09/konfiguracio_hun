using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    sealed class CPUHuto : Processzor, IHardverElem
    {
        public CPUtype Manufacturer { get; }
        public CPUHuto(string nev, int minoseg, int ar, CPUtype manufacturer, int powerusage) : base(nev,minoseg,ar,manufacturer,powerusage)
        {
            this.Manufacturer = manufacturer;
            this.típus = Típus.ProcesszorHűtő;
        }

        public event CheckComponents NotCompatibleCooler;
        public override void Beépít(Számítógép pc)
        {
            if (pc.MBnum == 0 && pc.mb.Cpunum == 0)
            {
                pc.SumPowerUsage += this.PowerUsage;
                pc.SumQuality += this.Minőség;
                pc.Value += this.Ár;
                if (pc.mb.Hutonum == 0 && pc.CPUCooler == true)
                {
                    pc.SumPowerUsage -= this.PowerUsage;
                    pc.SumQuality -= this.Minőség;
                    pc.Value -= this.Ár;
                    throw new DuplicateItemException(this.Név,this.típus);
                }
                pc.CPUCooler = true;
                if (!Kompatibilis(pc) && pc.CPU == true)
                {
                    pc.CPUCooler = false;
                    pc.mb.Hutonum++;
                    pc.SumPowerUsage -= this.PowerUsage;
                    pc.SumQuality -= this.Minőség;
                    pc.Value -= this.Ár;
                    Elromlik();
                }
                pc.mb.Hutonum--;
            }
            else
                throw new WrongOrderExceptionCPU();
        }
        public override void Elromlik()
        {
            NotCompatibleCooler?.Invoke(this.Név);
        }
        public override bool Kompatibilis(Számítógép pc)
        {
            return this.Manufacturer == pc.mb.Socket;
        }
    }
    class WrongOrderExceptionCPU : Exception
    {
        public WrongOrderExceptionCPU() : base("A processzor hűtőt nem lehet a processzor előtt berakni!")
        {

        }
    }
}

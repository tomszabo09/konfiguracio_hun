using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    abstract class Processzor : Alaplap, IHardverElem
    {
        private CPUtype CPUFajta { get; }
        public int CoreCount { get; }
        public int PowerUsage { get; }
        public double ProcessingPower { get; }
        
        public Processzor(string nev, int minoseg, int ar, CPUtype socket, int powerusage, int corecount = 0, double processingpower = 0) : base(nev, minoseg, ar, socket)
        {
            this.CoreCount = corecount;
            this.ProcessingPower = processingpower;
            this.PowerUsage = powerusage;
            this.típus = Típus.Processzor;
            this.CPUFajta = socket;
        }

        public event CheckComponents FalseSocket;
        public override void Beépít(Számítógép pc)
        {
            if (pc.MBnum == 0)
            {
                pc.SumPowerUsage += this.PowerUsage;
                pc.CPU = true;
                if (!this.Kompatibilis(pc))
                {
                    pc.CPU = false;
                    pc.mb.Cpunum++;
                    pc.SumPowerUsage -= this.PowerUsage;
                    pc.SumQuality -= this.Minőség;
                    pc.Value -= this.Ár;
                    Elromlik();
                }
                if (pc.mb.Cpunum == 0)
                {
                    pc.SumPowerUsage -= this.PowerUsage;
                    throw new DuplicateItemException(this.Név,this.típus);
                }
                pc.mb.Cpunum--;
            }
            else
                throw new WrongOrderException(this.típus);

            base.Beépít(pc);
        }
        public override void Elromlik()
        {
            FalseSocket?.Invoke(this.Név);
        }
        public override bool Kompatibilis(Számítógép pc)
        {
            return this.CPUFajta == pc.mb.Socket;
        }
    }
}

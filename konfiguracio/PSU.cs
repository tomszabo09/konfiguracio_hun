using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    public delegate void CheckPSU(string nev, int hiany);
    class PSU : Számítógép, IHardverElem
    {
        public string Név { get; }
        public int Minőség { get; }
        public int Ár { get; }
        public Típus típus { get; set; }
        public int Power { get; }
        private int Hiany { get; set; }
        public bool IsEnough { get; set; }

        public PSU(string nev, int minoseg, int ar, int power)
        {
            this.Név = nev;
            this.Minőség = minoseg;
            this.Ár = ar;
            this.Power = power;
            this.típus = Típus.Tápegység;
        }

        public event CheckPSU InsufficientPower;
        public void Beépít(Számítógép pc)
        {
            pc.SumQuality += this.Minőség;
            pc.Value += this.Ár;
            pc.PSU = true;
            this.IsEnough = true;
            if (pc.SumPowerUsage > this.Power)
            {
                this.IsEnough = false;
                pc.PSU = false;
                pc.SumQuality -= this.Minőség;
                pc.Value -= this.Ár;
                pc.PSUnum++;
                this.Hiany = pc.SumPowerUsage - this.Power;
                Elromlik();
            }
            if (pc.PSUnum == 0)
            {
                pc.SumQuality -= this.Minőség;
                pc.Value -= this.Ár;
                this.IsEnough = false;
                pc.PSU = false;
                throw new DuplicateItemException(this.Név,this.típus);
            }
            pc.PSUnum--;
        }
        public virtual void Elromlik()
        {
            InsufficientPower?.Invoke(this.Név,this.Hiany);
        }
    }
}

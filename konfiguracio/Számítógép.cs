using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    class Számítógép
    {
        public int SumPowerUsage { get; set; }
        public double SumQuality { get; set; }
        public int Value { get; set; }
        public int SumRAM { get; set; }
        public int GPUnum { get; set; }
        public Alaplap mb { get; set; }
        public bool PSU { get; set; }
        public bool MB { get; set; }
        public bool CPU { get; set; }
        public bool RAM { get; set; }
        public bool GPU { get; set; }
        public bool CPUCooler { get; set; }

        public int PSUnum = 1;
        public int MBnum = 1;

        public bool Mukodik()
        {
            if (this.MB == false)
            {
                Console.WriteLine("Hiányzó elem: alaplap");
            }
            if (this.CPU == false && this.MBnum == 0)
            {
                Console.WriteLine("Hiányzó elem: processzor");
            }
            if (this.CPUCooler == false && this.MBnum == 0)
            {
                Console.WriteLine("Hiányzó elem: processzor hűtő");
            }
            if (this.RAM == false && this.MBnum == 0)
            {
                if (mb.Ramslots != 0)
                    Console.WriteLine("Hiányzó elem: RAM");
            }
            if (this.GPU == false && this.MBnum == 0)
            {
                if (mb.PCIEslots != 0)
                    Console.WriteLine("Hiányzó elem: videókártya");
            }
            if (this.PSU == false)
            {
                Console.WriteLine("Hiányzó elem: tápegység");
            }
            return (this.PSU == true && this.MB == true && this.CPU == true && this.RAM == true && this.GPU == true && CPUCooler == true);
        }
        public bool PSULast()
        {
            return (this.PSU == false && this.MB == true && this.CPU == true && this.RAM == true && this.GPU == true && CPUCooler == true);
        }
    }
}

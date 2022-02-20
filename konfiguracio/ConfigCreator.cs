using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konfiguracio
{
    class ConfigCreator
    {
        static void RAMCompatibilityIssue(string nev)
        {
            Console.Clear();
            Console.WriteLine($"A '{nev}' nevű RAM nem illeszkedik az alaplapba!");
        }
        static void CPUCompatibilityIssue(string nev)
        {
            Console.Clear();
            Console.WriteLine($"A '{nev}' processzor nem illeszkedik az alaplapba! Válasszon egy másikat!");
        }
        static void CPUCoolerCompatibilityIssue(string nev)
        {
            Console.Clear();
            Console.WriteLine($"A '{nev}' processzor hűtő nem illeszkedik a processzorra! Válasszon egy másikat!");
        }
        static void InsufficientPowerIssue(string nev, int hiany)
        {
            Console.Clear();
            Console.WriteLine($"A '{nev}' tápegység nem termel elegendő energiát! Válasszon egy másikat! \nHiány mértéke: {hiany} W");
        }
        static void ComponentAdded(Számítógép item)
        {
            Console.WriteLine($"'{(item as IHardverElem).Név}' {(item as IHardverElem).típus} beépítve [Minőség: {(item as IHardverElem).Minőség}, Ár: {(item as IHardverElem).Ár} ft]");
        }

        List<IHardverElem> build = new List<IHardverElem>();
        Graf<Számítógép> graf = new Graf<Számítógép>();

        #region Komponensek
        Alaplap a1 = new Alaplap("Asus", 5, 200000, CPUtype.Intel, Memorytype.DDR4, 4, 8);
        Alaplap a2 = new Alaplap("MSI", 4, 120000, CPUtype.Intel, Memorytype.DDR4, 2, 4);
        Alaplap a3 = new Alaplap("Intel", 3, 80000, CPUtype.Intel, Memorytype.DDR3, 2, 2);
        Alaplap a4 = new Alaplap("ASRock", 1, 30000, CPUtype.Intel, Memorytype.DDR2, 1, 2);
        Alaplap a5 = new Alaplap("GIGABYTE", 5, 180000, CPUtype.AMD, Memorytype.DDR4, 2, 8);
        Alaplap a6 = new Alaplap("EVGA", 4, 150000, CPUtype.AMD, Memorytype.DDR4, 2, 4);
        Alaplap a7 = new Alaplap("Biostar", 3, 90000, CPUtype.AMD, Memorytype.DDR3, 2, 2);
        Alaplap a8 = new Alaplap("Acer", 1, 35000, CPUtype.AMD, Memorytype.DDR2, 1, 2);
        Processzor i9 = new IntelProcesszor("Intel Core i9", 5, 120000, 95, 8, 5);
        Processzor i7 = new IntelProcesszor("Intel Core i7", 4, 90000, 95, 4, 4.2);
        Processzor i5 = new IntelProcesszor("Intel Core i5", 3, 65000, 65, 4, 3.7);
        Processzor i3 = new IntelProcesszor("Intel Core i3", 2, 30000, 65, 6, 2.9);
        Processzor ar9 = new AMDProcesszor("AMD Ryzen 9", 5, 160000, 105, 12, 4.6);
        Processzor ar7 = new AMDProcesszor("AMD Ryzen 7", 4, 90000, 105, 8, 4.3);
        Processzor ar5 = new AMDProcesszor("AMD Ryzen 5", 3, 60000, 65, 6, 3.9);
        Processzor ar3 = new AMDProcesszor("AMD Ryzen 3", 3, 50000, 65, 4, 3.6);
        CPUHuto c1 = new CPUHuto("Noctua", 5, 30000, CPUtype.Intel, 3);
        CPUHuto c2 = new CPUHuto("Cooler Master", 3, 16000, CPUtype.Intel, 5);
        CPUHuto c3 = new CPUHuto("NZXT", 5, 32000, CPUtype.AMD, 4);
        CPUHuto c4 = new CPUHuto("Corsair", 2, 10000, CPUtype.AMD, 3);
        RAM r1 = new RAM("Corsair", 5, 30000, 8, Memorytype.DDR4, 3200, 2);
        RAM r2 = new RAM("Kingston", 5, 55000, 16, Memorytype.DDR4, 3200, 2);
        RAM r3 = new RAM("HyperX", 4, 25000, 4, Memorytype.DDR4, 3700, 3);
        RAM r4 = new RAM("G.Skill", 5, 20000, 8, Memorytype.DDR3, 3200, 3);
        RAM r5 = new RAM("Crucial", 4, 14000, 4, Memorytype.DDR3, 2666, 3);
        RAM r6 = new RAM("Fujitsu", 3, 8000, 2, Memorytype.DDR2, 1333, 4);
        GPU g1 = new GPU("RTX 3090", 5, 500000, 1400, 24, 350);
        GPU g2 = new GPU("RTX 3080", 5, 300000, 1440, 10, 320);
        GPU g3 = new GPU("RTX 2080 Ti", 4, 260000, 1350, 11, 260);
        GPU g4 = new GPU("GTX 1080 Ti", 3, 160000, 1480, 11, 250);
        GPU g5 = new GPU("RX 6900 XT", 5, 450000, 1825, 16, 300);
        GPU g6 = new GPU("RX 6700 XT", 3, 300000, 2321, 12, 230);
        GPU g7 = new GPU("RX 5700", 2, 120000, 1465, 8, 185);
        GPU g8 = new GPU("R9 390", 2, 100000, 1000, 8, 275);
        PSU p1 = new PSU("Corsair", 5, 21000, 450);
        PSU p2 = new PSU("BeQuiet!", 3, 40000, 1500);
        PSU p3 = new PSU("XPG", 4, 30000, 650);
        PSU p4 = new PSU("Fractal", 2, 15000, 300);

        List<int> IntelCPUprice = new List<int>();
        List<int> AMDCPUprice = new List<int>();
        List<int> IntelCPUCoolerprice = new List<int>();
        List<int> AMDCPUCoolerprice = new List<int>();
        List<int> DDR4RAMprice = new List<int>();
        List<int> DDR3RAMprice = new List<int>();
        List<int> DDR2RAMprice = new List<int>();
        List<int> GPUprice = new List<int>();

        List<int> IntelCPUquality = new List<int>();
        List<int> AMDCPUquality = new List<int>();
        List<int> IntelCPUCoolerquality = new List<int>();
        List<int> AMDCPUCoolerquality = new List<int>();
        List<int> DDR4RAMquality = new List<int>();
        List<int> DDR3RAMquality = new List<int>();
        List<int> DDR2RAMquality = new List<int>();
        List<int> GPUquality = new List<int>();
        #endregion

        public void Start()
        {
            Számítógép PC = new Számítógép();
            Menu(PC);
        }
        private void Menu(Számítógép PC)
        {
            #region UI
            Console.WriteLine("Üdvözöljük a számítógép konfiguráció összeállító rendszerben!");
            Console.WriteLine("Egy számítógép működéséhez szükség van alaplapra, processzorra, processzor hűtőre, RAM-ra, videókártyára és tápegységre.");
            Console.WriteLine("Kérjük, válassza ki, mire van szüksége (billentyű lenyomásával jelezze):");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("1. Alaplap");
            Console.WriteLine("2. Processzor");
            Console.WriteLine("3. Processzor hűtő");
            Console.WriteLine("4. RAM");
            Console.WriteLine("5. Videókártya");
            Console.WriteLine("6. Tápegység");
            Console.WriteLine("7. Optimális keresés");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("Kosár tartalma:\n");

            IHardverElem[] cart = build.ToArray();
            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i].típus == Típus.Alaplap)
                {
                    Console.WriteLine($"{cart[i].típus}: {cart[i].Név} [Minőség: {cart[i].Minőség}, Ár: {cart[i].Ár} ft, Socket: {(cart[i] as Alaplap).Socket}, Memória típusa: {(cart[i] as Alaplap).Datarate}," +
                        $" PCIE slotok száma: {(cart[i] as Alaplap).PCIEslots}, DDR slotok száma: {(cart[i] as Alaplap).Ramslots}]");
                }
                else if (cart[i].típus == Típus.Processzor)
                {
                    Console.WriteLine($"{cart[i].típus}: {cart[i].Név} [Minőség: {cart[i].Minőség}, Ár: {cart[i].Ár} ft, Fogyasztás: {(cart[i] as Processzor).PowerUsage} W," +
                        $" Magok száma: {(cart[i] as Processzor).CoreCount}, Órajel: {(cart[i] as Processzor).ProcessingPower} GHz]");
                }
                else if (cart[i].típus == Típus.ProcesszorHűtő)
                {
                    Console.WriteLine($"{cart[i].típus}: {cart[i].Név} [Minőség: {cart[i].Minőség}, Ár: {cart[i].Ár} ft, Fogyasztás: {(cart[i] as CPUHuto).PowerUsage} W]");
                }
                else if (cart[i].típus == Típus.RAM)
                {
                    Console.WriteLine($"{cart[i].típus}: {cart[i].Név} [Minőség: {cart[i].Minőség}, Ár: {cart[i].Ár} ft, Kapacitás: {(cart[i] as RAM).Memory} GB, Frekvencia: {(cart[i] as RAM).Frequency} MHz," +
                        $" Fogyasztás: {(cart[i] as RAM).PowerUsage} W]");
                }
                else if (cart[i].típus == Típus.Videókártya)
                {
                    Console.WriteLine($"{cart[i].típus}: {cart[i].Név} [Minőség: {cart[i].Minőség}, Ár: {cart[i].Ár} ft, Órajel: {(cart[i] as GPU).Orajel} MHz, VRAM: {(cart[i] as GPU).VRAM} GB," +
                        $" Fogyasztás: {(cart[i] as GPU).PowerUsage} W]");
                }
                else if (cart[i].típus == Típus.Tápegység)
                {
                    Console.WriteLine($"{cart[i].típus}: {cart[i].Név} [Minőség: {cart[i].Minőség}, Ár: {cart[i].Ár} ft, Kapacitás: {(cart[i] as PSU).Power} W]");
                }
            }

            Console.WriteLine($"\nKosár összértéke: {PC.Value} ft");
            Console.WriteLine($"A konfiguráció átlagos minősége: {Math.Round(((double)PC.SumQuality/build.Count),2)}\n");
            Console.WriteLine(PC.Mukodik() ? "Működik a PC!" : string.Empty);
            Console.WriteLine("\nESC: Kilépés");
            #endregion

            ConsoleKey key = Console.ReadKey().Key;

            do
            {
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    if (!PC.Mukodik())
                    {
                        Console.Clear();
                        try
                        {
                            MB(PC);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                        Console.WriteLine("Már létezik egy összeállítótt konfiguráció!");

                    Console.WriteLine("\nA visszalépéshez nyomjon le egy tetszőleges billentyűt!");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(PC);
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    try
                    {
                        CPU(PC);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("\nA visszalépéshez nyomjon le egy tetszőleges billentyűt!");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(PC);
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    try
                    {
                        CPUCooler(PC);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("\nA visszalépéshez nyomjon le egy tetszőleges billentyűt!");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(PC);
                }
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    try
                    {
                        RAM(PC);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("\nA visszalépéshez nyomjon le egy tetszőleges billentyűt!");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(PC);
                }
                else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    try
                    {
                        GPU(PC);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("\nA visszalépéshez nyomjon le egy tetszőleges billentyűt!");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(PC);
                }
                else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
                {
                    Console.Clear();
                    Console.WriteLine($"Az eddigi komponensek összfogyasztása: {PC.SumPowerUsage} W\n");
                    try
                    {
                        PSU(PC);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("\nA visszalépéshez nyomjon le egy tetszőleges billentyűt!");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(PC);
                }
                else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
                {
                    if (!PC.Mukodik())
                    {
                        #region Graf
                        graf.Ujcsucs(p1);
                        graf.Ujcsucs(p2);
                        graf.Ujcsucs(p3);
                        graf.Ujcsucs(p4);
                        graf.Ujcsucs(a1);
                        graf.Ujcsucs(a2);
                        graf.Ujcsucs(a3);
                        graf.Ujcsucs(a4);
                        graf.Ujcsucs(a5);
                        graf.Ujcsucs(a6);
                        graf.Ujcsucs(a7);
                        graf.Ujcsucs(a8);
                        graf.Ujcsucs(i9);
                        graf.Ujcsucs(i7);
                        graf.Ujcsucs(i5);
                        graf.Ujcsucs(i3);
                        graf.Ujcsucs(ar9);
                        graf.Ujcsucs(ar7);
                        graf.Ujcsucs(ar5);
                        graf.Ujcsucs(ar3);
                        graf.Ujcsucs(c1);
                        graf.Ujcsucs(c2);
                        graf.Ujcsucs(c3);
                        graf.Ujcsucs(c4);
                        graf.Ujcsucs(r1);
                        graf.Ujcsucs(r2);
                        graf.Ujcsucs(r3);
                        graf.Ujcsucs(r4);
                        graf.Ujcsucs(r5);
                        graf.Ujcsucs(r6);
                        graf.Ujcsucs(g1);
                        graf.Ujcsucs(g2);
                        graf.Ujcsucs(g3);
                        graf.Ujcsucs(g4);
                        graf.Ujcsucs(g5);
                        graf.Ujcsucs(g6);
                        graf.Ujcsucs(g7);
                        graf.Ujcsucs(g8);

                        //intel alaplap-processzor
                        graf.UjEl(a1, i9);
                        graf.UjEl(a1, i7);
                        graf.UjEl(a1, i5);
                        graf.UjEl(a1, i3);
                        graf.UjEl(a2, i9);
                        graf.UjEl(a2, i7);
                        graf.UjEl(a2, i5);
                        graf.UjEl(a2, i3);
                        graf.UjEl(a3, i9);
                        graf.UjEl(a3, i7);
                        graf.UjEl(a3, i5);
                        graf.UjEl(a3, i3);
                        graf.UjEl(a4, i9);
                        graf.UjEl(a4, i7);
                        graf.UjEl(a4, i5);
                        graf.UjEl(a4, i3);

                        //intel processzor-hűtő
                        graf.UjEl(i9, c1);
                        graf.UjEl(i9, c2);
                        graf.UjEl(i7, c1);
                        graf.UjEl(i7, c2);
                        graf.UjEl(i5, c1);
                        graf.UjEl(i5, c2);
                        graf.UjEl(i3, c1);
                        graf.UjEl(i3, c2);

                        //asus alaplap-processzor
                        graf.UjEl(a5, ar9);
                        graf.UjEl(a5, ar7);
                        graf.UjEl(a5, ar5);
                        graf.UjEl(a5, ar3);
                        graf.UjEl(a6, ar9);
                        graf.UjEl(a6, ar7);
                        graf.UjEl(a6, ar5);
                        graf.UjEl(a6, ar3);
                        graf.UjEl(a7, ar9);
                        graf.UjEl(a7, ar7);
                        graf.UjEl(a7, ar5);
                        graf.UjEl(a7, ar3);
                        graf.UjEl(a8, ar9);
                        graf.UjEl(a8, ar7);
                        graf.UjEl(a8, ar5);
                        graf.UjEl(a8, ar3);

                        //asus processzor-hűtő
                        graf.UjEl(ar9, c3);
                        graf.UjEl(ar9, c4);
                        graf.UjEl(ar7, c3);
                        graf.UjEl(ar7, c4);
                        graf.UjEl(ar5, c3);
                        graf.UjEl(ar5, c4);
                        graf.UjEl(ar3, c3);
                        graf.UjEl(ar3, c4);

                        //alaplap-ddr4 ram
                        graf.UjEl(a1, r1);
                        graf.UjEl(a1, r2);
                        graf.UjEl(a1, r3);
                        graf.UjEl(a2, r1);
                        graf.UjEl(a2, r2);
                        graf.UjEl(a2, r3);
                        graf.UjEl(a5, r1);
                        graf.UjEl(a5, r2);
                        graf.UjEl(a5, r3);
                        graf.UjEl(a6, r1);
                        graf.UjEl(a6, r2);
                        graf.UjEl(a6, r3);

                        //alaplap-ddr3 ram
                        graf.UjEl(a3, r4);
                        graf.UjEl(a3, r5);
                        graf.UjEl(a7, r4);
                        graf.UjEl(a7, r5);

                        //alaplap-ddr2 ram
                        graf.UjEl(a4, r6);
                        graf.UjEl(a8, r6);

                        //videókártya, tápegység alaplapokhoz kötve (mindig kompatibilis)
                        graf.UjEl(a1, g1);
                        graf.UjEl(a1, g2);
                        graf.UjEl(a1, g3);
                        graf.UjEl(a1, g4);
                        graf.UjEl(a1, g5);
                        graf.UjEl(a1, g6);
                        graf.UjEl(a1, g7);
                        graf.UjEl(a1, g8);
                        graf.UjEl(a1, p1);
                        graf.UjEl(a1, p2);
                        graf.UjEl(a1, p3);
                        graf.UjEl(a1, p4);

                        graf.UjEl(a2, g1);
                        graf.UjEl(a2, g2);
                        graf.UjEl(a2, g3);
                        graf.UjEl(a2, g4);
                        graf.UjEl(a2, g5);
                        graf.UjEl(a2, g6);
                        graf.UjEl(a2, g7);
                        graf.UjEl(a2, g8);
                        graf.UjEl(a2, p1);
                        graf.UjEl(a2, p2);
                        graf.UjEl(a2, p3);
                        graf.UjEl(a2, p4);

                        graf.UjEl(a3, g1);
                        graf.UjEl(a3, g2);
                        graf.UjEl(a3, g3);
                        graf.UjEl(a3, g4);
                        graf.UjEl(a3, g5);
                        graf.UjEl(a3, g6);
                        graf.UjEl(a3, g7);
                        graf.UjEl(a3, g8);
                        graf.UjEl(a3, p1);
                        graf.UjEl(a3, p2);
                        graf.UjEl(a3, p3);
                        graf.UjEl(a3, p4);

                        graf.UjEl(a4, g1);
                        graf.UjEl(a4, g2);
                        graf.UjEl(a4, g3);
                        graf.UjEl(a4, g4);
                        graf.UjEl(a4, g5);
                        graf.UjEl(a4, g6);
                        graf.UjEl(a4, g7);
                        graf.UjEl(a4, g8);
                        graf.UjEl(a4, p1);
                        graf.UjEl(a4, p2);
                        graf.UjEl(a4, p3);
                        graf.UjEl(a4, p4);

                        graf.UjEl(a5, g1);
                        graf.UjEl(a5, g2);
                        graf.UjEl(a5, g3);
                        graf.UjEl(a5, g4);
                        graf.UjEl(a5, g5);
                        graf.UjEl(a5, g6);
                        graf.UjEl(a5, g7);
                        graf.UjEl(a5, g8);
                        graf.UjEl(a5, p1);
                        graf.UjEl(a5, p2);
                        graf.UjEl(a5, p3);
                        graf.UjEl(a5, p4);

                        graf.UjEl(a6, g1);
                        graf.UjEl(a6, g2);
                        graf.UjEl(a6, g3);
                        graf.UjEl(a6, g4);
                        graf.UjEl(a6, g5);
                        graf.UjEl(a6, g6);
                        graf.UjEl(a6, g7);
                        graf.UjEl(a6, g8);
                        graf.UjEl(a6, p1);
                        graf.UjEl(a6, p2);
                        graf.UjEl(a6, p3);
                        graf.UjEl(a6, p4);

                        graf.UjEl(a7, g1);
                        graf.UjEl(a7, g2);
                        graf.UjEl(a7, g3);
                        graf.UjEl(a7, g4);
                        graf.UjEl(a7, g5);
                        graf.UjEl(a7, g6);
                        graf.UjEl(a7, g7);
                        graf.UjEl(a7, g8);
                        graf.UjEl(a7, p1);
                        graf.UjEl(a7, p2);
                        graf.UjEl(a7, p3);
                        graf.UjEl(a7, p4);

                        graf.UjEl(a8, g1);
                        graf.UjEl(a8, g2);
                        graf.UjEl(a8, g3);
                        graf.UjEl(a8, g4);
                        graf.UjEl(a8, g5);
                        graf.UjEl(a8, g6);
                        graf.UjEl(a8, g7);
                        graf.UjEl(a8, g8);
                        graf.UjEl(a8, p1);
                        graf.UjEl(a8, p2);
                        graf.UjEl(a8, p3);
                        graf.UjEl(a8, p4);
                        #endregion

                        Console.Clear();
                        Console.WriteLine("Válasszon keresési szempontot:\n");
                        Console.WriteLine("1. Legolcsóbb konfiguráció keresése");
                        Console.WriteLine("2. Átlagosan legjobb minőségű konfiguráció keresése");

                        ConsoleKey key2 = Console.ReadKey().Key;

                        if (key2 == ConsoleKey.D1 || key2 == ConsoleKey.NumPad1)
                        {
                            #region Árak
                            IntelCPUprice.Add(i9.Ár);
                            IntelCPUprice.Add(i7.Ár);
                            IntelCPUprice.Add(i5.Ár);
                            IntelCPUprice.Add(i3.Ár);
                            AMDCPUprice.Add(ar9.Ár);
                            AMDCPUprice.Add(ar7.Ár);
                            AMDCPUprice.Add(ar5.Ár);
                            AMDCPUprice.Add(ar3.Ár);

                            IntelCPUCoolerprice.Add(c1.Ár);
                            IntelCPUCoolerprice.Add(c2.Ár);
                            AMDCPUCoolerprice.Add(c3.Ár);
                            AMDCPUCoolerprice.Add(c4.Ár);

                            DDR4RAMprice.Add(r1.Ár);
                            DDR4RAMprice.Add(r2.Ár);
                            DDR4RAMprice.Add(r3.Ár);
                            DDR3RAMprice.Add(r4.Ár);
                            DDR3RAMprice.Add(r5.Ár);
                            DDR2RAMprice.Add(r6.Ár);

                            GPUprice.Add(g1.Ár);
                            GPUprice.Add(g2.Ár);
                            GPUprice.Add(g3.Ár);
                            GPUprice.Add(g4.Ár);
                            GPUprice.Add(g5.Ár);
                            GPUprice.Add(g6.Ár);
                            GPUprice.Add(g7.Ár);
                            GPUprice.Add(g8.Ár);
                            #endregion

                            Console.Clear();
                            BargainSearch(PC, 1, build, IntelCPUprice, AMDCPUprice, IntelCPUCoolerprice, AMDCPUCoolerprice, DDR4RAMprice, DDR3RAMprice, DDR2RAMprice, GPUprice);
                        }
                        else if (key2 == ConsoleKey.D2 || key2 == ConsoleKey.NumPad2)
                        {
                            #region Minőségek
                            IntelCPUquality.Add(i9.Minőség);
                            IntelCPUquality.Add(i7.Minőség);
                            IntelCPUquality.Add(i5.Minőség);
                            IntelCPUquality.Add(i3.Minőség);
                            AMDCPUquality.Add(ar9.Minőség);
                            AMDCPUquality.Add(ar7.Minőség);
                            AMDCPUquality.Add(ar5.Minőség);
                            AMDCPUquality.Add(ar3.Minőség);

                            IntelCPUCoolerquality.Add(c1.Minőség);
                            IntelCPUCoolerquality.Add(c2.Minőség);
                            AMDCPUCoolerquality.Add(c3.Minőség);
                            AMDCPUCoolerquality.Add(c4.Minőség);

                            DDR4RAMquality.Add(r1.Minőség);
                            DDR4RAMquality.Add(r2.Minőség);
                            DDR4RAMquality.Add(r3.Minőség);
                            DDR3RAMquality.Add(r4.Minőség);
                            DDR3RAMquality.Add(r5.Minőség);
                            DDR2RAMquality.Add(r6.Minőség);

                            GPUquality.Add(g1.Minőség);
                            GPUquality.Add(g2.Minőség);
                            GPUquality.Add(g3.Minőség);
                            GPUquality.Add(g4.Minőség);
                            GPUquality.Add(g5.Minőség);
                            GPUquality.Add(g6.Minőség);
                            GPUquality.Add(g7.Minőség);
                            GPUquality.Add(g8.Minőség);
                            #endregion

                            Console.Clear();
                            QualitySearch(PC, 2, build, IntelCPUquality, AMDCPUquality, IntelCPUCoolerquality, AMDCPUCoolerquality, DDR4RAMquality, DDR3RAMquality, DDR2RAMquality, GPUquality);
                        }

                        Console.WriteLine("\nA visszalépéshez nyomjon le egy tetszőleges billentyűt!");
                        Console.ReadKey();
                        Console.Clear();
                        Menu(PC);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Már össze van állítva egy működő konfiguráció!");
                        Console.WriteLine("\nBackspace: vissza");
                        Console.WriteLine("Kilépéshez nyomjon le egy tetszőleges billentyűt!");

                        ConsoleKey key2 = Console.ReadKey().Key;

                        if (key2 == ConsoleKey.Backspace)
                        {
                            Console.Clear();
                            Menu(PC);
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                else if (key != ConsoleKey.Escape)
                {
                    Console.Clear();
                    Menu(PC);
                }
            } while (key != ConsoleKey.Escape);

            Environment.Exit(0);
        }

        private void MB(Számítógép PC)
        {
            Console.WriteLine("A következő alaplapok közül lehet választani:\n");
            Console.WriteLine($"1. {a1.Név} [Minőség: {a1.Minőség}, Ár: {a1.Ár} ft, Socket: {a1.Socket}, Memória típusa: {a1.Datarate}, PCIE slotok száma: {a1.PCIEslots}, DDR slotok száma: {a1.Ramslots}]");
            Console.WriteLine($"2. {a2.Név} [Minőség: {a2.Minőség}, Ár: {a2.Ár} ft, Socket: {a2.Socket}, Memória típusa: {a2.Datarate}, PCIE slotok száma: {a2.PCIEslots}, DDR slotok száma: {a2.Ramslots}]");
            Console.WriteLine($"3. {a3.Név} [Minőség: {a3.Minőség}, Ár: {a3.Ár} ft, Socket: {a3.Socket}, Memória típusa: {a3.Datarate}, PCIE slotok száma: {a3.PCIEslots}, DDR slotok száma: {a3.Ramslots}]");
            Console.WriteLine($"4. {a4.Név} [Minőség: {a4.Minőség}, Ár: {a4.Ár} ft, Socket: {a4.Socket}, Memória típusa: {a4.Datarate}, PCIE slotok száma: {a4.PCIEslots}, DDR slotok száma: {a4.Ramslots}]");
            Console.WriteLine($"5. {a5.Név} [Minőség: {a5.Minőség}, Ár: {a5.Ár} ft, Socket: {a5.Socket}, Memória típusa: {a5.Datarate}, PCIE slotok száma: {a5.PCIEslots}, DDR slotok száma: {a5.Ramslots}]");
            Console.WriteLine($"6. {a6.Név} [Minőség: {a6.Minőség}, Ár: {a6.Ár} ft, Socket: {a6.Socket}, Memória típusa: {a6.Datarate}, PCIE slotok száma: {a6.PCIEslots}, DDR slotok száma: {a6.Ramslots}]");
            Console.WriteLine($"7. {a7.Név} [Minőség: {a7.Minőség}, Ár: {a7.Ár} ft, Socket: {a7.Socket}, Memória típusa: {a7.Datarate}, PCIE slotok száma: {a7.PCIEslots}, DDR slotok száma: {a7.Ramslots}]");
            Console.WriteLine($"8. {a8.Név} [Minőség: {a8.Minőség}, Ár: {a8.Ár} ft, Socket: {a8.Socket}, Memória típusa: {a8.Datarate}, PCIE slotok száma: {a8.PCIEslots}, DDR slotok száma: {a8.Ramslots}]");
            Console.WriteLine("\nBackspace: vissza");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                a1.Beépít(PC);
                build.Add(a1);
                ComponentAdded(a1);
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                a2.Beépít(PC);
                build.Add(a2);
                ComponentAdded(a2);
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                a3.Beépít(PC);
                build.Add(a3);
                ComponentAdded(a3);
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                a4.Beépít(PC);
                build.Add(a4);
                ComponentAdded(a4);
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                a5.Beépít(PC);
                build.Add(a5);
                ComponentAdded(a5);
            }
            else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
            {
                Console.Clear();
                a6.Beépít(PC);
                build.Add(a6);
                ComponentAdded(a6);
            }
            else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
            {
                Console.Clear();
                a7.Beépít(PC);
                build.Add(a7);
                ComponentAdded(a7);
            }
            else if (key == ConsoleKey.D8 || key == ConsoleKey.NumPad8)
            {
                Console.Clear();
                a8.Beépít(PC);
                build.Add(a8);
                ComponentAdded(a8);
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                MB(PC);
            }
        }
        private void CPU(Számítógép PC)
        {
            Console.WriteLine("A következő processzorok közül lehet választani:\n");
            Console.WriteLine($"1. {i9.Név} [Minőség: {i9.Minőség}, Ár: {i9.Ár} ft, Fogyasztás: {i9.PowerUsage} W, Magok száma: {i9.CoreCount}, Órajel: {i9.ProcessingPower} GHz]");
            Console.WriteLine($"2. {i7.Név} [Minőség: {i7.Minőség}, Ár: {i7.Ár} ft, Fogyasztás: {i7.PowerUsage} W, Magok száma: {i7.CoreCount}, Órajel: {i7.ProcessingPower} GHz]");
            Console.WriteLine($"3. {i5.Név} [Minőség: {i5.Minőség}, Ár: {i5.Ár} ft, Fogyasztás: {i5.PowerUsage} W, Magok száma: {i5.CoreCount}, Órajel: {i5.ProcessingPower} GHz]");
            Console.WriteLine($"4. {i3.Név} [Minőség: {i3.Minőség}, Ár: {i3.Ár} ft, Fogyasztás: {i3.PowerUsage} W, Magok száma: {i3.CoreCount}, Órajel: {i3.ProcessingPower} GHz]");
            Console.WriteLine($"5. {ar9.Név} [Minőség: {ar9.Minőség}, Ár: {ar9.Ár} ft, Fogyasztás: {ar9.PowerUsage} W, Magok száma: {ar9.CoreCount}, Órajel: {ar9.ProcessingPower} GHz]");
            Console.WriteLine($"6. {ar7.Név} [Minőség: {ar7.Minőség}, Ár: {ar7.Ár} ft, Fogyasztás: {ar7.PowerUsage} W, Magok száma: {ar7.CoreCount}, Órajel: {ar7.ProcessingPower} GHz]");
            Console.WriteLine($"7. {ar5.Név} [Minőség: {ar5.Minőség}, Ár: {ar5.Ár} ft, Fogyasztás: {ar5.PowerUsage} W, Magok száma: {ar5.CoreCount}, Órajel: {ar5.ProcessingPower} GHz]");
            Console.WriteLine($"8. {ar3.Név} [Minőség: {ar3.Minőség}, Ár: {ar3.Ár} ft, Fogyasztás: {ar3.PowerUsage} W, Magok száma: {ar3.CoreCount}, Órajel: {ar3.ProcessingPower} GHz]");
            Console.WriteLine("\nBackspace: vissza");

            i9.FalseSocket += CPUCompatibilityIssue;
            i7.FalseSocket += CPUCompatibilityIssue;
            i5.FalseSocket += CPUCompatibilityIssue;
            i3.FalseSocket += CPUCompatibilityIssue;
            ar9.FalseSocket += CPUCompatibilityIssue;
            ar7.FalseSocket += CPUCompatibilityIssue;
            ar5.FalseSocket += CPUCompatibilityIssue;
            ar3.FalseSocket += CPUCompatibilityIssue;

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                i9.Beépít(PC);
                if (i9.Kompatibilis(PC))
                {
                    build.Add(i9);
                    ComponentAdded(i9);
                }
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                i7.Beépít(PC);
                if (i7.Kompatibilis(PC))
                {
                    build.Add(i7);
                    ComponentAdded(i7);
                }
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                i5.Beépít(PC);
                if (i5.Kompatibilis(PC))
                {
                    build.Add(i5);
                    ComponentAdded(i5);
                }
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                i3.Beépít(PC);
                if (i3.Kompatibilis(PC))
                {
                    build.Add(i3);
                    ComponentAdded(i3);
                }
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                ar9.Beépít(PC);
                if (ar9.Kompatibilis(PC))
                {
                    build.Add(ar9);
                    ComponentAdded(ar9);
                }
            }
            else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
            {
                Console.Clear();
                ar7.Beépít(PC);
                if (ar7.Kompatibilis(PC))
                {
                    build.Add(ar7);
                    ComponentAdded(ar7);
                }
            }
            else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
            {
                Console.Clear();
                ar5.Beépít(PC);
                if (ar5.Kompatibilis(PC))
                {
                    build.Add(ar5);
                    ComponentAdded(ar5);
                }
            }
            else if (key == ConsoleKey.D8 || key == ConsoleKey.NumPad8)
            {
                Console.Clear();
                ar3.Beépít(PC);
                if (ar3.Kompatibilis(PC))
                {
                    build.Add(ar3);
                    ComponentAdded(ar3);
                }
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                CPU(PC);
            }
        }
        private void CPUCooler(Számítógép PC)
        {
            Console.WriteLine("A következő processzor hűtők közül lehet választani:\n");
            Console.WriteLine($"1. {c1.Név} [Minőség: {c1.Minőség}, Ár: {c1.Ár} ft, Kompatibilis processzor: {c1.Manufacturer}, Fogyasztás: {c1.PowerUsage} W]");
            Console.WriteLine($"2. {c2.Név} [Minőség: {c2.Minőség}, Ár: {c2.Ár} ft, Kompatibilis processzor: {c2.Manufacturer}, Fogyasztás: {c2.PowerUsage} W]");
            Console.WriteLine($"3. {c3.Név} [Minőség: {c3.Minőség}, Ár: {c3.Ár} ft, Kompatibilis processzor: {c3.Manufacturer}, Fogyasztás: {c3.PowerUsage} W]");
            Console.WriteLine($"4. {c4.Név} [Minőség: {c4.Minőség}, Ár: {c4.Ár} ft, Kompatibilis processzor: {c4.Manufacturer}, Fogyasztás: {c4.PowerUsage} W]");
            Console.WriteLine("\nBackspace: vissza");

            c1.NotCompatibleCooler += CPUCoolerCompatibilityIssue;
            c2.NotCompatibleCooler += CPUCoolerCompatibilityIssue;
            c3.NotCompatibleCooler += CPUCoolerCompatibilityIssue;
            c4.NotCompatibleCooler += CPUCoolerCompatibilityIssue;

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                c1.Beépít(PC);
                if (c1.Kompatibilis(PC))
                {
                    build.Add(c1);
                    ComponentAdded(c1);
                }
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                c2.Beépít(PC);
                if (c2.Kompatibilis(PC))
                {
                    build.Add(c2);
                    ComponentAdded(c2);
                }
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                c3.Beépít(PC);
                if (c3.Kompatibilis(PC))
                {
                    build.Add(c3);
                    ComponentAdded(c3);
                }
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                c4.Beépít(PC);
                if (c4.Kompatibilis(PC))
                {
                    build.Add(c4);
                    ComponentAdded(c4);
                }
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                CPUCooler(PC);
            }
        }
        private void RAM(Számítógép PC)
        {
            Console.WriteLine("A következő RAM-ok közül lehet választani:\n");
            Console.WriteLine($"1. {r1.Név} [Minőség: {r1.Minőség}, Ár: {r1.Ár} ft, Kapacitás: {r1.Memory} GB, Fajta: {r1.RAMFajta}, Frekvencia: {r1.Frequency} MHz, Fogyasztás: {r1.PowerUsage} W]");
            Console.WriteLine($"2. {r2.Név} [Minőség: {r2.Minőség}, Ár: {r2.Ár} ft, Kapacitás: {r2.Memory} GB, Fajta: {r2.RAMFajta}, Frekvencia: {r2.Frequency} MHz, Fogyasztás: {r2.PowerUsage} W]");
            Console.WriteLine($"3. {r3.Név} [Minőség: {r3.Minőség}, Ár: {r3.Ár} ft, Kapacitás: {r3.Memory} GB, Fajta: {r3.RAMFajta}, Frekvencia: {r3.Frequency} MHz, Fogyasztás: {r3.PowerUsage} W]");
            Console.WriteLine($"4. {r4.Név} [Minőség: {r4.Minőség}, Ár: {r4.Ár} ft, Kapacitás: {r4.Memory} GB, Fajta: {r4.RAMFajta}, Frekvencia: {r4.Frequency} MHz, Fogyasztás: {r4.PowerUsage} W]");
            Console.WriteLine($"5. {r5.Név} [Minőség: {r5.Minőség}, Ár: {r5.Ár} ft, Kapacitás: {r5.Memory} GB, Fajta: {r5.RAMFajta}, Frekvencia: {r5.Frequency} MHz, Fogyasztás: {r5.PowerUsage} W]");
            Console.WriteLine($"6. {r6.Név} [Minőség: {r6.Minőség}, Ár: {r6.Ár} ft, Kapacitás: {r6.Memory} GB, Fajta: {r6.RAMFajta}, Frekvencia: {r6.Frequency} MHz, Fogyasztás: {r6.PowerUsage} W]");
            Console.WriteLine("\nBackspace: vissza");

            r1.FalseDDR += RAMCompatibilityIssue;
            r2.FalseDDR += RAMCompatibilityIssue;
            r3.FalseDDR += RAMCompatibilityIssue;
            r4.FalseDDR += RAMCompatibilityIssue;
            r5.FalseDDR += RAMCompatibilityIssue;
            r6.FalseDDR += RAMCompatibilityIssue;

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                r1.Beépít(PC);
                if (r1.Kompatibilis(PC))
                {
                    build.Add(r1);
                    ComponentAdded(r1);
                }
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                r2.Beépít(PC);
                if (r2.Kompatibilis(PC))
                {
                    build.Add(r2);
                    ComponentAdded(r2);
                }
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                r3.Beépít(PC);
                if (r3.Kompatibilis(PC))
                {
                    build.Add(r3);
                    ComponentAdded(r3);
                }
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                r4.Beépít(PC);
                if (r4.Kompatibilis(PC))
                {
                    build.Add(r4);
                    ComponentAdded(r4);
                }
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                r5.Beépít(PC);
                if (r5.Kompatibilis(PC))
                {
                    build.Add(r5);
                    ComponentAdded(r5);
                }
            }
            else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
            {
                Console.Clear();
                r6.Beépít(PC);
                if (r6.Kompatibilis(PC))
                {
                    build.Add(r6);
                    ComponentAdded(r6);
                }
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                RAM(PC);
            }
        }
        private void GPU(Számítógép PC)
        {
            Console.WriteLine("A következő videókártyák közül lehet választani:\n");
            Console.WriteLine($"1. {g1.Név} [Minőség: {g1.Minőség}, Ár: {g1.Ár} ft, Órajel: {g1.Orajel} MHz, VRAM: {g1.VRAM} GB, Fogyasztás: {g1.PowerUsage} W]");
            Console.WriteLine($"2. {g2.Név} [Minőség: {g2.Minőség}, Ár: {g2.Ár} ft, Órajel: {g2.Orajel} MHz, VRAM: {g2.VRAM} GB, Fogyasztás: {g2.PowerUsage} W]");
            Console.WriteLine($"3. {g3.Név} [Minőség: {g3.Minőség}, Ár: {g3.Ár} ft, Órajel: {g3.Orajel} MHz, VRAM: {g3.VRAM} GB, Fogyasztás: {g3.PowerUsage} W]");
            Console.WriteLine($"4. {g4.Név} [Minőség: {g4.Minőség}, Ár: {g4.Ár} ft, Órajel: {g4.Orajel} MHz, VRAM: {g4.VRAM} GB, Fogyasztás: {g4.PowerUsage} W]");
            Console.WriteLine($"5. {g5.Név} [Minőség: {g5.Minőség}, Ár: {g5.Ár} ft, Órajel: {g5.Orajel} MHz, VRAM: {g5.VRAM} GB, Fogyasztás: {g5.PowerUsage} W]");
            Console.WriteLine($"6. {g6.Név} [Minőség: {g6.Minőség}, Ár: {g6.Ár} ft, Órajel: {g6.Orajel} MHz, VRAM: {g6.VRAM} GB, Fogyasztás: {g6.PowerUsage} W]");
            Console.WriteLine($"7. {g7.Név} [Minőség: {g7.Minőség}, Ár: {g7.Ár} ft, Órajel: {g7.Orajel} MHz, VRAM: {g7.VRAM} GB, Fogyasztás: {g7.PowerUsage} W]");
            Console.WriteLine($"8. {g8.Név} [Minőség: {g8.Minőség}, Ár: {g8.Ár} ft, Órajel: {g8.Orajel} MHz, VRAM: {g8.VRAM} GB, Fogyasztás: {g8.PowerUsage} W]");
            Console.WriteLine("\nBackspace: vissza");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                g1.Beépít(PC);
                if (g1.Kompatibilis(PC))
                {
                    build.Add(g1);
                    ComponentAdded(g1);
                }
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                g2.Beépít(PC);
                if (g2.Kompatibilis(PC))
                {
                    build.Add(g2);
                    ComponentAdded(g2);
                }
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                g3.Beépít(PC);
                if (g3.Kompatibilis(PC))
                {
                    build.Add(g3);
                    ComponentAdded(g3);
                }
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                g4.Beépít(PC);
                if (g4.Kompatibilis(PC))
                {
                    build.Add(g4);
                    ComponentAdded(g4);
                }
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                g5.Beépít(PC);
                if (g5.Kompatibilis(PC))
                {
                    build.Add(g5);
                    ComponentAdded(g5);
                }
            }
            else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
            {
                Console.Clear();
                g6.Beépít(PC);
                if (g6.Kompatibilis(PC))
                {
                    build.Add(g6);
                    ComponentAdded(g6);
                }
            }
            else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
            {
                Console.Clear();
                g7.Beépít(PC);
                if (g7.Kompatibilis(PC))
                {
                    build.Add(g7);
                    ComponentAdded(g7);
                }
            }
            else if (key == ConsoleKey.D8 || key == ConsoleKey.NumPad8)
            {
                Console.Clear();
                g8.Beépít(PC);
                if (g8.Kompatibilis(PC))
                {
                    build.Add(g8);
                    ComponentAdded(g8);
                }
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                GPU(PC);
            }
        }
        private void PSU(Számítógép PC)
        {
            Console.WriteLine("A következő tápegységek közül lehet választani:\n");
            Console.WriteLine($"1. {p1.Név} [Minőség: {p1.Minőség}, Ár: {p1.Ár} ft, Kapacitás: {p1.Power} W]");
            Console.WriteLine($"2. {p2.Név} [Minőség: {p2.Minőség}, Ár: {p2.Ár} ft, Kapacitás: {p2.Power} W]");
            Console.WriteLine($"3. {p3.Név} [Minőség: {p3.Minőség}, Ár: {p3.Ár} ft, Kapacitás: {p3.Power} W]");
            Console.WriteLine($"4. {p4.Név} [Minőség: {p4.Minőség}, Ár: {p4.Ár} ft, Kapacitás: {p4.Power} W]");
            Console.WriteLine("\nBackspace: vissza");

            p1.InsufficientPower += InsufficientPowerIssue;
            p2.InsufficientPower += InsufficientPowerIssue;
            p3.InsufficientPower += InsufficientPowerIssue;
            p4.InsufficientPower += InsufficientPowerIssue;

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                if (PC.PSULast())
                {
                    p1.Beépít(PC);
                    if (p1.IsEnough)
                    {
                        build.Add(p1);
                        ComponentAdded(p1);
                    }
                }
                else if (PC.Mukodik())
                {
                    Console.Clear();
                    Console.WriteLine("Már létezik egy összeállított konfiguráció!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("A tápegységet utoljára kell beszerelni!");
                }
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                if (PC.PSULast())
                {
                    p2.Beépít(PC);
                    if (p2.IsEnough)
                    {
                        build.Add(p2);
                        ComponentAdded(p2);
                    }
                }
                else if (PC.Mukodik())
                {
                    Console.Clear();
                    Console.WriteLine("Már létezik egy összeállított konfiguráció!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("A tápegységet utoljára kell beszerelni!");
                }
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                if (PC.PSULast())
                {
                    p3.Beépít(PC);
                    if (p3.IsEnough)
                    {
                        build.Add(p3);
                        ComponentAdded(p3);
                    }
                }
                else if (PC.Mukodik())
                {
                    Console.Clear();
                    Console.WriteLine("Már létezik egy összeállított konfiguráció!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("A tápegységet utoljára kell beszerelni!");
                }
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                if (PC.PSULast())
                {
                    p4.Beépít(PC);
                    if (p4.IsEnough)
                    {
                        build.Add(p4);
                        ComponentAdded(p4);
                    }
                }
                else if (PC.Mukodik())
                {
                    Console.Clear();
                    Console.WriteLine("Már létezik egy összeállított konfiguráció!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("A tápegységet utoljára kell beszerelni!");
                }
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                PSU(PC);
            }
        }
        private void BargainSearch(Számítógép PC, int which, List<IHardverElem> build, List<int> intelcpuprice, List<int> amdcpuprice, List<int> intelcpucoolerprice, List<int> amdcpucoolerprice, List<int> ddr4ramprice, 
            List<int> ddr3ramprice, List<int> ddr2ramprice, List<int> gpuprice)
        {
            Console.WriteLine("Válasszon alaplapot:\n");
            Console.WriteLine($"1. {a1.Név} [Minőség: {a1.Minőség}, Ár: {a1.Ár} ft, Socket: {a1.Socket}, Memória típusa: {a1.Datarate}, PCIE slotok száma: {a1.PCIEslots}, DDR slotok száma: {a1.Ramslots}]");
            Console.WriteLine($"2. {a2.Név} [Minőség: {a2.Minőség}, Ár: {a2.Ár} ft, Socket: {a2.Socket}, Memória típusa: {a2.Datarate}, PCIE slotok száma: {a2.PCIEslots}, DDR slotok száma: {a2.Ramslots}]");
            Console.WriteLine($"3. {a3.Név} [Minőség: {a3.Minőség}, Ár: {a3.Ár} ft, Socket: {a3.Socket}, Memória típusa: {a3.Datarate}, PCIE slotok száma: {a3.PCIEslots}, DDR slotok száma: {a3.Ramslots}]");
            Console.WriteLine($"4. {a4.Név} [Minőség: {a4.Minőség}, Ár: {a4.Ár} ft, Socket: {a4.Socket}, Memória típusa: {a4.Datarate}, PCIE slotok száma: {a4.PCIEslots}, DDR slotok száma: {a4.Ramslots}]");
            Console.WriteLine($"5. {a5.Név} [Minőség: {a5.Minőség}, Ár: {a5.Ár} ft, Socket: {a5.Socket}, Memória típusa: {a5.Datarate}, PCIE slotok száma: {a5.PCIEslots}, DDR slotok száma: {a5.Ramslots}]");
            Console.WriteLine($"6. {a6.Név} [Minőség: {a6.Minőség}, Ár: {a6.Ár} ft, Socket: {a6.Socket}, Memória típusa: {a6.Datarate}, PCIE slotok száma: {a6.PCIEslots}, DDR slotok száma: {a6.Ramslots}]");
            Console.WriteLine($"7. {a7.Név} [Minőség: {a7.Minőség}, Ár: {a7.Ár} ft, Socket: {a7.Socket}, Memória típusa: {a7.Datarate}, PCIE slotok száma: {a7.PCIEslots}, DDR slotok száma: {a7.Ramslots}]");
            Console.WriteLine($"8. {a8.Név} [Minőség: {a8.Minőség}, Ár: {a8.Ár} ft, Socket: {a8.Socket}, Memória típusa: {a8.Datarate}, PCIE slotok száma: {a8.PCIEslots}, DDR slotok száma: {a8.Ramslots}]");
            Console.WriteLine("\nBackspace: vissza");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                graf.Melysegibejaras(a1, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                graf.Melysegibejaras(a2, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                graf.Melysegibejaras(a3, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                graf.Melysegibejaras(a4, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                graf.Melysegibejaras(a5, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
            {
                Console.Clear();
                graf.Melysegibejaras(a6, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
            {
                Console.Clear();
                graf.Melysegibejaras(a7, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.D8 || key == ConsoleKey.NumPad8)
            {
                Console.Clear();
                graf.Melysegibejaras(a8, ComponentAdded, PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                BargainSearch(PC, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
            }
        }
        private void QualitySearch(Számítógép PC, int which, List<IHardverElem> build, List<int> intelcpuquality, List<int> amdcpuquality, List<int> intelcpucoolerquality, List<int> amdcpucoolerquality, 
            List<int> ddr4ramquality, List<int> ddr3ramquality, List<int> ddr2ramquality, List<int> gpuquality)
        {
            Console.WriteLine("Válasszon alaplapot:\n");
            Console.WriteLine($"1. {a1.Név} [Minőség: {a1.Minőség}, Ár: {a1.Ár} ft, Socket: {a1.Socket}, Memória típusa: {a1.Datarate}, PCIE slotok száma: {a1.PCIEslots}, DDR slotok száma: {a1.Ramslots}]");
            Console.WriteLine($"2. {a2.Név} [Minőség: {a2.Minőség}, Ár: {a2.Ár} ft, Socket: {a2.Socket}, Memória típusa: {a2.Datarate}, PCIE slotok száma: {a2.PCIEslots}, DDR slotok száma: {a2.Ramslots}]");
            Console.WriteLine($"3. {a3.Név} [Minőség: {a3.Minőség}, Ár: {a3.Ár} ft, Socket: {a3.Socket}, Memória típusa: {a3.Datarate}, PCIE slotok száma: {a3.PCIEslots}, DDR slotok száma: {a3.Ramslots}]");
            Console.WriteLine($"4. {a4.Név} [Minőség: {a4.Minőség}, Ár: {a4.Ár} ft, Socket: {a4.Socket}, Memória típusa: {a4.Datarate}, PCIE slotok száma: {a4.PCIEslots}, DDR slotok száma: {a4.Ramslots}]");
            Console.WriteLine($"5. {a5.Név} [Minőség: {a5.Minőség}, Ár: {a5.Ár} ft, Socket: {a5.Socket}, Memória típusa: {a5.Datarate}, PCIE slotok száma: {a5.PCIEslots}, DDR slotok száma: {a5.Ramslots}]");
            Console.WriteLine($"6. {a6.Név} [Minőség: {a6.Minőség}, Ár: {a6.Ár} ft, Socket: {a6.Socket}, Memória típusa: {a6.Datarate}, PCIE slotok száma: {a6.PCIEslots}, DDR slotok száma: {a6.Ramslots}]");
            Console.WriteLine($"7. {a7.Név} [Minőség: {a7.Minőség}, Ár: {a7.Ár} ft, Socket: {a7.Socket}, Memória típusa: {a7.Datarate}, PCIE slotok száma: {a7.PCIEslots}, DDR slotok száma: {a7.Ramslots}]");
            Console.WriteLine($"8. {a8.Név} [Minőség: {a8.Minőség}, Ár: {a8.Ár} ft, Socket: {a8.Socket}, Memória típusa: {a8.Datarate}, PCIE slotok száma: {a8.PCIEslots}, DDR slotok száma: {a8.Ramslots}]");
            Console.WriteLine("\nBackspace: vissza");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                graf.Melysegibejaras(a1, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                graf.Melysegibejaras(a2, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                Console.Clear();
                graf.Melysegibejaras(a3, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
            {
                Console.Clear();
                graf.Melysegibejaras(a4, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
            {
                Console.Clear();
                graf.Melysegibejaras(a5, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
            {
                Console.Clear();
                graf.Melysegibejaras(a6, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
            {
                Console.Clear();
                graf.Melysegibejaras(a7, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.D8 || key == ConsoleKey.NumPad8)
            {
                Console.Clear();
                graf.Melysegibejaras(a8, ComponentAdded, PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
            else if (key == ConsoleKey.Backspace)
            {
                Console.Clear();
                Menu(PC);
            }
            else
            {
                Console.Clear();
                QualitySearch(PC, which, build, intelcpuquality, amdcpuquality, intelcpucoolerquality, amdcpucoolerquality, ddr4ramquality, ddr3ramquality, ddr2ramquality, gpuquality);
            }
        }
    }
    class Graf<T>
    {
        protected class El
        {
            public T hova;
        }

        public delegate void ExternalProcessor(T item);

        List<T> tartalmak;
        List<List<El>> szomszedok;

        public Graf()
        {
            tartalmak = new List<T>();
            szomszedok = new List<List<El>>();
        }

        public void Ujcsucs(T tartalom)
        {
            tartalmak.Add(tartalom);
            szomszedok.Add(new List<El>());
        }
        public void UjEl(T honnan, T hova)
        {
            int idx = tartalmak.IndexOf(honnan);
            szomszedok[idx].Add(new Graf<T>.El() { hova = hova });
            idx = tartalmak.IndexOf(hova);
            szomszedok[idx].Add(new Graf<T>.El() { hova = honnan });
        }
        protected List<El> Szomszedok(T csucs)
        {
            int index = tartalmak.IndexOf(csucs);
            return szomszedok[index];
        }

        private void BargainSetup(T k, ExternalProcessor method, Számítógép pc, List<IHardverElem> build, List<int> intelcpuprice, List<int> amdcpuprice, List<int> intelcpucoolerprice, List<int> amdcpucoolerprice, 
            List<int> ddr4ramprice, List<int> ddr3ramprice, List<int> ddr2ramprice, List<int> gpuprice)
        {
            if (pc.MB == false && (k as IHardverElem).típus == Típus.Alaplap)
            {
                (k as Alaplap).Beépít(pc);
                pc.MB = true;
                build.Add(k as Alaplap);
                method?.Invoke(k);
            }
            else if (pc.CPU == false && (k as IHardverElem).típus == Típus.Processzor && (k as Processzor).Kompatibilis(pc))
            {
                if (k is IntelProcesszor && (k as Processzor).Ár == intelcpuprice.Min())
                {
                    (k as Processzor).Beépít(pc);
                    pc.CPU = true;
                    build.Add(k as IntelProcesszor);
                    method?.Invoke(k);
                }
                else if (k is AMDProcesszor && (k as Processzor).Ár == amdcpuprice.Min())
                {
                    (k as Processzor).Beépít(pc);
                    pc.CPU = true;
                    build.Add(k as AMDProcesszor);
                    method?.Invoke(k);
                }
            }
            else if (pc.CPUCooler == false && (k as IHardverElem).típus == Típus.ProcesszorHűtő && (k as CPUHuto).Kompatibilis(pc))
            {
                if ((k as CPUHuto).Socket == CPUtype.Intel && (k as CPUHuto).Ár == intelcpucoolerprice.Min())
                {
                    (k as CPUHuto).Beépít(pc);
                    pc.CPUCooler = true;
                    build.Add(k as CPUHuto);
                    method?.Invoke(k);
                }
                else if ((k as CPUHuto).Socket == CPUtype.AMD && (k as CPUHuto).Ár == amdcpucoolerprice.Min())
                {
                    (k as CPUHuto).Beépít(pc);
                    pc.CPUCooler = true;
                    build.Add(k as CPUHuto);
                    method?.Invoke(k);
                }
            }
            else if (pc.RAM == false && (k as IHardverElem).típus == Típus.RAM && (k as RAM).Kompatibilis(pc))
            {
                if ((k as RAM).Datarate == Memorytype.DDR4 && (k as RAM).Ár == ddr4ramprice.Min())
                {
                    (k as RAM).Beépít(pc);
                    pc.RAM = true;
                    build.Add(k as RAM);
                    method?.Invoke(k);
                }
                else if ((k as RAM).Datarate == Memorytype.DDR3 && (k as RAM).Ár == ddr3ramprice.Min())
                {
                    (k as RAM).Beépít(pc);
                    pc.RAM = true;
                    build.Add(k as RAM);
                    method?.Invoke(k);
                }
                else if ((k as RAM).Datarate == Memorytype.DDR2 && (k as RAM).Ár == ddr2ramprice.Min())
                {
                    (k as RAM).Beépít(pc);
                    pc.RAM = true;
                    build.Add(k as RAM);
                    method?.Invoke(k);
                }
            }
            else if (pc.GPU == false && (k as IHardverElem).típus == Típus.Videókártya && (k as GPU).Kompatibilis(pc) && (k as GPU).Ár == gpuprice.Min())
            {
                (k as GPU).Beépít(pc);
                pc.GPU = true;
                build.Add(k as GPU);
                method?.Invoke(k);
            }
            else if (pc.PSU == false && (k as IHardverElem).típus == Típus.Tápegység && (k as PSU).Power >= pc.SumPowerUsage)
            {
                (k as PSU).Beépít(pc);
                pc.PSU = true;
                build.Add(k as PSU);
                method?.Invoke(k);
            }
        }
        private void QualitySetup(T k, ExternalProcessor method, Számítógép pc, List<IHardverElem> build, List<int> intelcpuquality, List<int> amdcpuquality, List<int> intelcpucoolerquality,
            List<int> amdcpucoolerquality, List<int> ddr4ramquality, List<int> ddr3ramquality, List<int> ddr2ramquality, List<int> gpuquality)
        {
            if (pc.MB == false && (k as IHardverElem).típus == Típus.Alaplap)
            {
                (k as Alaplap).Beépít(pc);
                pc.MB = true;
                build.Add(k as Alaplap);
                method?.Invoke(k);
            }
            else if (pc.CPU == false && (k as IHardverElem).típus == Típus.Processzor && (k as Processzor).Kompatibilis(pc))
            {
                if (k is IntelProcesszor && (k as Processzor).Minőség == intelcpuquality.Max())
                {
                    (k as Processzor).Beépít(pc);
                    pc.CPU = true;
                    build.Add(k as IntelProcesszor);
                    method?.Invoke(k);
                }
                else if (k is AMDProcesszor && (k as Processzor).Minőség == amdcpuquality.Max())
                {
                    (k as Processzor).Beépít(pc);
                    pc.CPU = true;
                    build.Add(k as AMDProcesszor);
                    method?.Invoke(k);
                }
            }
            else if (pc.CPUCooler == false && (k as IHardverElem).típus == Típus.ProcesszorHűtő && (k as CPUHuto).Kompatibilis(pc))
            {
                if ((k as CPUHuto).Socket == CPUtype.Intel && (k as CPUHuto).Minőség == intelcpucoolerquality.Max())
                {
                    (k as CPUHuto).Beépít(pc);
                    pc.CPUCooler = true;
                    build.Add(k as CPUHuto);
                    method?.Invoke(k);
                }
                else if ((k as CPUHuto).Socket == CPUtype.AMD && (k as CPUHuto).Minőség == amdcpucoolerquality.Max())
                {
                    (k as CPUHuto).Beépít(pc);
                    pc.CPUCooler = true;
                    build.Add(k as CPUHuto);
                    method?.Invoke(k);
                }
            }
            else if (pc.RAM == false && (k as IHardverElem).típus == Típus.RAM && (k as RAM).Kompatibilis(pc))
            {
                if ((k as RAM).Datarate == Memorytype.DDR4 && (k as RAM).Minőség == ddr4ramquality.Max())
                {
                    (k as RAM).Beépít(pc);
                    pc.RAM = true;
                    build.Add(k as RAM);
                    method?.Invoke(k);
                }
                else if ((k as RAM).Datarate == Memorytype.DDR3 && (k as RAM).Minőség == ddr3ramquality.Max())
                {
                    (k as RAM).Beépít(pc);
                    pc.RAM = true;
                    build.Add(k as RAM);
                    method?.Invoke(k);
                }
                else if ((k as RAM).Datarate == Memorytype.DDR2 && (k as RAM).Minőség == ddr2ramquality.Max())
                {
                    (k as RAM).Beépít(pc);
                    pc.RAM = true;
                    build.Add(k as RAM);
                    method?.Invoke(k);
                }
            }
            else if (pc.GPU == false && (k as IHardverElem).típus == Típus.Videókártya && (k as GPU).Kompatibilis(pc) && (k as GPU).Minőség == gpuquality.Max())
            {
                (k as GPU).Beépít(pc);
                pc.GPU = true;
                build.Add((k as GPU));
                method?.Invoke(k);
            }
            else if (pc.PSU == false && (k as IHardverElem).típus == Típus.Tápegység && (k as PSU).Power >= pc.SumPowerUsage)
            {
                (k as PSU).Beépít(pc);
                pc.PSU = true;
                build.Add(k as PSU);
                method?.Invoke(k);
            }
        }
        public void MelysegibejarasRek(T k, List<T> F, ExternalProcessor method, Számítógép pc, int which, List<IHardverElem> build, List<int> intelcpu, List<int> amdcpu, List<int> intelcpucooler,
            List<int> amdcpucooler, List<int> ddr4ram,List<int> ddr3ram, List<int> ddr2ram, List<int> gpu)
        {
            F.Add(k);

            if (which == 1)
            {
                BargainSetup(k, method, pc, build, intelcpu, amdcpu, intelcpucooler, amdcpucooler, ddr4ram, ddr3ram, ddr2ram, gpu);
            }
            else if (which == 2)
            {
                QualitySetup(k, method, pc, build, intelcpu, amdcpu, intelcpucooler, amdcpucooler, ddr4ram, ddr3ram, ddr2ram, gpu);
            }
            else
                method?.Invoke(k);

            foreach (El x in Szomszedok(k))
            {
                if (!F.Contains(x.hova))
                {
                    MelysegibejarasRek(x.hova, F, method, pc, which, build, intelcpu, amdcpu, intelcpucooler, amdcpucooler, ddr4ram, ddr3ram, ddr2ram, gpu);
                }
            }
        }
        public void Melysegibejaras(T start, ExternalProcessor _method, Számítógép pc, int which, List<IHardverElem> build, List<int> intelcpuprice, List<int> amdcpuprice, List<int> intelcpucoolerprice, List<int> amdcpucoolerprice, 
            List<int> ddr4ramprice,List<int> ddr3ramprice, List<int> ddr2ramprice, List<int> gpuprice)
        {
            ExternalProcessor method = _method;
            List<T> F = new List<T>();
            MelysegibejarasRek(start, F, method, pc, which, build, intelcpuprice, amdcpuprice, intelcpucoolerprice, amdcpucoolerprice, ddr4ramprice, ddr3ramprice, ddr2ramprice, gpuprice);
        }
    }
}

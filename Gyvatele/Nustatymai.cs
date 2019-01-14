using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyvatele
{
    public enum Kryptis
    {
        Aukstyn,
        Zemyn,
        Kaire,
        Desine
    };

    class Nustatymai
    {
        public static int Plotis { get; set; }
        public static int Aukstis { get; set; }
        public static int Greitis { get; set; }
        public static int Rezultatas { get; set; }
        public static int Taskai { get; set; }
        public static bool ZaidimasBaigtas { get; set; }
        public static Kryptis Kryptis { get; set; }

        public Nustatymai()
        {
            Plotis = 16;
            Aukstis = 16;
            Greitis = 16;
            Rezultatas = 0;
            Taskai = 1;
            ZaidimasBaigtas = false;
            Kryptis = Kryptis.Desine;
        }
    }
}

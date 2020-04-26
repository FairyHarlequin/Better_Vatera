using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Termek : IComparable
    {
        public string Sorszam { get; set; }
        string Nev { get; set; }
        string Cikkszam { get; set; }
        string HanyszorVasaroltakMeg { get; set; }

        public Termek(string sorszam, string nev, string cikkszam, string hanyszorVasaroltakMeg)
        {
            this.Sorszam = sorszam;
            this.Nev = nev;
            this.Cikkszam = cikkszam;
            this.HanyszorVasaroltakMeg = hanyszorVasaroltakMeg;
        }

        public static void KeresoFabaKerul()
        {
            
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

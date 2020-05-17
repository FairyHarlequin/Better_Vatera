using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Termek : IComparable<Termek>
    {
        public string Sorszam { get; set; }
        public string Nev { get; set; }
        public string Cikkszam { get; set; }
        public double Ar { get; set; }
        public string HanyszorVasaroltakMeg { get; set; }
        public Elado arusito { get; set; }

        public Termek(string sorszam = null, string nev = null, string cikkszam = null, double ar = 0, string hanyszorVasaroltakMeg = null)
        {
            this.Sorszam = sorszam;
            this.Nev = nev;
            this.Cikkszam = cikkszam;
            this.Ar = ar;
            this.HanyszorVasaroltakMeg = hanyszorVasaroltakMeg;
        }

        public void Kiir()
        {
            Console.WriteLine($"A termék neve: {this.Nev}, Cikkszáma: {this.Cikkszam}, Ára: {this.Ar}, Hányszor vásárolták meg: {this.HanyszorVasaroltakMeg}");
        }

        public int CompareTo(Termek obj)
        {
            if (obj.Nev == null)
            {
                return 1;
            }

            Termek termek = obj as Termek;

            if (termek.Nev != null)
            {
                return this.Nev.CompareTo(termek.Nev);
            }
            else
            {
                throw new ArgumentException("Az object az nem egy Termék");
            }
        }
    }
}

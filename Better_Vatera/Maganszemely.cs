using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Maganszemely : Elado
    {
        public string Nev { get; set; }

        public Maganszemely(string nev, int adoszam, string kontaktszemely, ertekeles ertekeles, LancoltLista<Termek> termekLista, Kapcsolat kapcsolat, string fizetos) : base(adoszam, kontaktszemely, ertekeles, termekLista, kapcsolat, fizetos)
        {
            this.Nev = nev;
        }
    }
}

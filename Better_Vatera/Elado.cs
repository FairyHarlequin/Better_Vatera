using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Elado : IElado
    {
        public int Adoszam { get; set; }
        public string Kontaktszemely { get; set; }
        public ertekeles Ertekeles { get; set; }
        public List<Termek> TermekLista { get; set; }
        public Kapcsolat Kapcsolat { get; set; }
        public string Fizetos { get; set; }

        public Elado(int adoszam = 0, string kontaktszemely = "nincs", ertekeles ertekeles = ertekeles.egy, List<Termek> termekLista = null, Kapcsolat kapcsolat = null, string fizetos = "ingyenes")
        {
            this.Adoszam = adoszam;
            this.Kontaktszemely = kontaktszemely;
            this.Ertekeles = ertekeles;
            this.TermekLista = termekLista;
            this.Kapcsolat = kapcsolat;
            this.Fizetos = fizetos;
        }
    }
}

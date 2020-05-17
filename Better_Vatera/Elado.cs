using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Elado : IElado, IComparable<Elado>
    {
        public int Adoszam { get; set; }
        public string Kontaktszemely { get; set; }
        public ertekeles Ertekeles { get; set; }
        public LancoltLista<Termek> TermekLista { get; set; }
        public Kapcsolat Kapcsolat { get; set; }
        public string Fizetos { get; set; }

        public Elado(int adoszam = 0, string kontaktszemely = "nincs", ertekeles ertekeles = ertekeles.egy, LancoltLista<Termek> termekLista = null, Kapcsolat kapcsolat = null, string fizetos = "ingyenes")
        {
            this.Adoszam = adoszam;
            this.Kontaktszemely = kontaktszemely;
            this.Ertekeles = ertekeles;
            this.TermekLista = termekLista;
            this.Kapcsolat = kapcsolat;
            this.Fizetos = fizetos;
        }

        public int CompareTo(Elado obj)
        {
            if (obj is Jogiszemely)
            {
                Jogiszemely obj2 = obj as Jogiszemely;

                if (obj2.CegNev == null)
                {
                    return 1;
                }

                Jogiszemely szemely = obj as Jogiszemely;

                if (szemely.CegNev != null)
                {
                    return obj2.CegNev.CompareTo(szemely.CegNev);
                }
                else
                {
                    throw new ArgumentException("Az object az nem egy Jogiszemély");
                }
            }
            else if (obj is Maganszemely)
            {
                Maganszemely obj3 = obj as Maganszemely;

                if (obj3.Nev == null)
                {
                    return 1;
                }

                Maganszemely szemely = obj as Maganszemely;

                if (szemely.Nev != null)
                {
                    return obj3.Nev.CompareTo(szemely.Nev);
                }
                else
                {
                    throw new ArgumentException("Az object az nem egy Magánszemély");
                }
            }
            else
            {
                throw new ArgumentException("Az object az nem egy Eladó");
            }
        }
    }
}

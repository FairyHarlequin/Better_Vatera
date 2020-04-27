using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Jogiszemely : Elado
    {
        public string CegNev { get; set; }

        public Jogiszemely(string cegNev, int adoszam, string kontaktszemely, ertekeles ertekeles, List<Termek> termekLista, Kapcsolat kapcsolat, string fizetos) : base(adoszam,kontaktszemely,ertekeles, termekLista, kapcsolat, fizetos)
        {
            this.CegNev = cegNev;
        }
    }
}

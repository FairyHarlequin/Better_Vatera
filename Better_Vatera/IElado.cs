using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    enum ertekeles { egy, ketto, harom, negy, ot }
    interface IElado
    {
        int Adoszam { get; set; }
        string Kontaktszemely { get; set; }
        ertekeles Ertekeles { get; set; }
        List<Termek> TermekLista { get; set; }
        Kapcsolat Kapcsolat { get; set; }
    }  
}

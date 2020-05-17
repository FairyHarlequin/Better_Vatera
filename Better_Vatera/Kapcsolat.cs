using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Kapcsolat
    {
        string _Telefonszam { get; set; }
        string _Email { get; set; }
        string _LevelezesiCim { get; set; }
        string _Fax { get; set; }

        public Kapcsolat(string telefonszam, string email, string levelezesiCim, string fax)
        {
            this._Telefonszam = telefonszam;
            this._Email = email;
            this._LevelezesiCim = levelezesiCim;
            this._Fax = fax;
        }
    }
}

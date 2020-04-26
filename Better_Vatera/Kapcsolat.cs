using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Kapcsolat
    {
        string Telefonszam { get; set; }
        string Email { get; set; }
        string LevelezesiCim { get; set; }
        string Fax { get; set; }

        public Kapcsolat(string telefonszam, string email, string levelezesiCim, string fax)
        {
            this.Telefonszam = telefonszam;
            this.Email = email;
            this.LevelezesiCim = levelezesiCim;
            this.Fax = fax;
        }
    }
}

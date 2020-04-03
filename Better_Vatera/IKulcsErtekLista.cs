using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    interface IKulcsErtekLista<T, K>
    {
        void Beszur(T tartalom, K kulcs);

        T KulcsAlapjanKeres(K kulcs);

        K TartalomAlapjanKeres(T tartalom);
    }
}

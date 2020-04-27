using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class Exceptions : Exception
    {
        public Exceptions(string msg) : base(msg)
        {

        }
    }

    class NincsIlyenEladoException : Exceptions
    {
        public NincsIlyenEladoException(string msg) : base(msg)
        {

        }
    }

    class NincsIlyenCikkszamException : Exceptions
    {
        public NincsIlyenCikkszamException(string msg) : base(msg)
        {

        }
    }

    class NincsIlyenTermeknevException : Exceptions
    {
        public NincsIlyenTermeknevException(string msg) : base(msg)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Vatera
{
    class NincsIlyenTermeknevException : Exception
    {
        public NincsIlyenTermeknevException(string msg) : base(msg)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.RequerimientosNoFuncionales.Interfaces
{
    interface ICrypto
    {
        String Encriptar(string text, string password);

        String Desencriptar(string encrypted, string password);
    }
}

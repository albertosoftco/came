using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.RequerimientosNoFuncionales.Interfaces
{
    interface ICrypto
    {
        String Encrypt(string text, string password);

        String Decrypt(string encrypted, string password);
    }
}

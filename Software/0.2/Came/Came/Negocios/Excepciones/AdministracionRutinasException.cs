using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.Excepciones
{
    class AdministracionRutinasException : Exception
    {
        public AdministracionRutinasException(string message)
            :base(message)
        {
            
        }

        
    }
}

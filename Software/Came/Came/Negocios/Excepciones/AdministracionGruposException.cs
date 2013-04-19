using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.Excepciones
{
    class AdministracionGruposException : Exception
    {

        public AdministracionGruposException(string message)
            : base(message)
        {
            
        }

        public AdministracionGruposException()
            : base()
        {
            
        }
             
    }
}

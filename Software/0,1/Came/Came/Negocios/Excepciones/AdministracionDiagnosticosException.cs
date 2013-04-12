using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.Excepciones
{
    class AdministracionDiagnosticosException:Exception
    {
        public AdministracionDiagnosticosException(string message)
            :base(message)
        {
            
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.Excepciones
{
    class AdministracionAlumnosException:Exception
    {
        public AdministracionAlumnosException(string message)
            :base(message)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.Excepciones
{
    class AdministracionAlumnosExcetion:Exception
    {
        public AdministracionAlumnosExcetion(string message)
            :base(message)
        {
            
        }
    }
}

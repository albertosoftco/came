using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Came.Negocios.Excepciones
{
    class LoginException:Exception
    {
        public LoginException(String message)
            :base(message)
        {
            
        }

        public LoginException()
            :base()
        {
            
        }
    }
}

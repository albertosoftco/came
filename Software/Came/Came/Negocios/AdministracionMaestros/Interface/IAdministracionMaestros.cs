using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;

namespace Came.Negocios.AdministracionMaestros.Interface
{
    interface IAdministracionMaestros
    {
        IEnumerable<Maestro> GetMaestros();

        Maestro GetMaestro(int id);
    }
}

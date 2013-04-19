using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.AdministracionMaestros.Interface;
using Came.Modelo.Interface;
using Came.Modelo;

namespace Came.Negocios.AdministracionMaestros.Fachada
{
    class FachadaAdministracionMaestros : IAdministracionMaestros
    {
        private AdministracionMaestros admMaestros;
        
        public FachadaAdministracionMaestros(IModelo modelo)
        {
            admMaestros = new AdministracionMaestros(modelo);
        }
        public IEnumerable<Modelo.Maestro> GetMaestros()
        {
            return admMaestros.GetMaestros();
        }

        public Maestro GetMaestro(int id)
        {
            return admMaestros.GetMaestro(id);
        }
    }
}

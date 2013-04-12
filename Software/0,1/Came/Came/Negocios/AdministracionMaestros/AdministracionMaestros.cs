using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;
using Came.Modelo.Fachada;
using Came.Modelo;
namespace Came.Negocios.AdministracionMaestros
{
    class AdministracionMaestros
    {
        private IModelo modelo;

        public AdministracionMaestros(IModelo modelo)
        {
            this.modelo = modelo;

        }
        
        public IEnumerable<Maestro>GetMaestros()
        {
            return modelo.GetMaestros();
        }


        public Maestro GetMaestro(int id)
        {
            return modelo.GetMaestro(id);
        }
    }
}

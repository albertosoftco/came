using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;
using Came.Modelo;

namespace Came.Negocios.AdministracionDiagnosticos
{
    class AdministracionDiagnosticos
    {
        private IModelo modelo;

        public AdministracionDiagnosticos(IModelo modelo)
        {
            this.modelo = modelo;
        }


        public void AgregaDiagnostico(Diagnostico diagnostico)
        {
            this.modelo.GetModelo().Diagnostico.Add(diagnostico);
            this.modelo.SalvaCambios();
        }


        

    }
}

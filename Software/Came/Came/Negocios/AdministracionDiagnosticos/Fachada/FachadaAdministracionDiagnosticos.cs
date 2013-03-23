using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.AdministracionDiagnosticos.Interface;
using Came.Modelo.Interface;

namespace Came.Negocios.AdministracionDiagnosticos.Fachada
{
    class FachadaAdministracionDiagnosticos : IAdministracionDiagnosticos
    {

        private IModelo modelo;
        private AdministracionDiagnosticos admDiagnosticos;

        public FachadaAdministracionDiagnosticos(IModelo modelo)
        {
            this.modelo = modelo;
            this.admDiagnosticos = new AdministracionDiagnosticos(modelo);

        }

        public void AgregaDiagnostico(Modelo.Diagnostico diagnostico)
        {
           
        }

        public void AgregaDiscapacidad(Modelo.Discapacidad discapacidad)
        {
            throw new NotImplementedException();
        }

        public void AgregaFactor(Modelo.Factor factor)
        {
            throw new NotImplementedException();
        }

        public void ActualizaDiagnostico(Modelo.Diagnostico diagnostico)
        {
            throw new NotImplementedException();
        }

        public void ActualizaDiscapacidad(Modelo.Discapacidad discapacidad)
        {
            throw new NotImplementedException();
        }

        public void ActualizaFactor(Modelo.Factor factor)
        {
            throw new NotImplementedException();
        }

        public void EliminaDiagnostico(int idDiagnostico)
        {
            throw new NotImplementedException();
        }

        public void EliminaDiscapacidad(int idDiscapacidad)
        {
            throw new NotImplementedException();
        }

        public void EliminaFactor(int idFactor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo.Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo.Factor> GetFactoresDiscapacidad(int idDiscapacidad)
        {
            throw new NotImplementedException();
        }
    }
}

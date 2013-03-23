using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;

namespace Came.Negocios.AdministracionDiagnosticos.Interface
{
    interface IAdministracionDiagnosticos
    {
        void AgregaDiagnostico(Diagnostico diagnostico);

        void AgregaDiscapacidad(Discapacidad discapacidad);

        void AgregaFactor(Factor factor);

        void ActualizaDiagnostico(Diagnostico diagnostico);

        void ActualizaDiscapacidad(Discapacidad discapacidad);

        void ActualizaFactor(Factor factor);

        void EliminaDiagnostico(int idDiagnostico);

        void EliminaDiscapacidad(int idDiscapacidad);

        void EliminaFactor(int idFactor);

        IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico);

        IEnumerable<Factor> GetFactoresDiscapacidad(int idDiscapacidad);

        
    }
}

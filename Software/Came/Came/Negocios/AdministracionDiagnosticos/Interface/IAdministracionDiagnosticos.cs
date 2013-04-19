using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;
using System.Data.Entity;

namespace Came.Negocios.AdministracionDiagnosticos.Interface
{
    interface IAdministracionDiagnosticos
    {
        void AgregaRelacionDiagnosticoDiscapacidad(int idDiagnostico, int idDiscapacidad);

        void AgregaRelacionDiscapacidadFactor(int idDiscapacidad, int idFactor);

        void AgregaDiagnostico(Diagnostico diagnostico);

        void AgregaDiscapacidad(Discapacidad discapacidad);

        void AgregaFactor(Factor factor);

        void ActualizaDiagnostico(Diagnostico diagnostico);

        void ActualizaDiscapacidad(Discapacidad discapacidad);

        void ActualizaFactor(Factor factor);

        void EliminaDiagnostico(int idDiagnostico);

        void EliminaDiscapacidad(int idDiscapacidad);

        void EliminaFactor(int idFactor);

        Diagnostico GetDiagnostico(int idDiagnostico);

        Discapacidad GetDiscapacidad(int idDiscapacidad);

        Factor GetFactor(int idFactor);

        Diagnostico GetDiagnostico(string nombre);

        Discapacidad GetDiscapacidad(string nombre);

        Factor GetFactor(string nombre);

        IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico);

        IEnumerable<Factor> GetFactoresDiscapacidad(int idDiscapacidad);

        void AsignaDiscapacidadDiagnostico(int idDiscapacidad, int idDiagnostico);

        void AsignaFactorDiscapacidad(int idFactor, int idDiscapacidad);

        void AsignaDiagnosticoAlumno(int idDiagnostico, int idAlumno);

        DbSet<Diagnostico_Discapacidad> GetRelacionesDiagnosticoDiscapacidad();

        DbSet<Discapacidad_Factor> GetRelacionesDiscapacidadFactor();

        IEnumerable<Factor> GetFactores();

        IEnumerable<Discapacidad> GetDiscapacidades();
    }
}

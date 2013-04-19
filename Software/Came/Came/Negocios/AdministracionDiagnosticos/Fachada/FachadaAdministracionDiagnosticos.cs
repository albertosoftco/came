using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.AdministracionDiagnosticos.Interface;
using Came.Modelo.Interface;
using Came.Modelo;
using Came.Negocios.Excepciones;
using Came.Modelo.Fachada;

namespace Came.Negocios.AdministracionDiagnosticos.Fachada
{
    class FachadaAdministracionDiagnosticos : IAdministracionDiagnosticos
    {

        
        private AdministracionDiagnosticos admDiagnosticos;

        public FachadaAdministracionDiagnosticos()
        {
            this.admDiagnosticos = new AdministracionDiagnosticos(FachadaModelo.GetInstance());
        }

        public void AgregaDiagnostico(Diagnostico diagnostico)
        {
            admDiagnosticos.AgregaDiagnostico(diagnostico);
        }

        public void AgregaDiscapacidad(Discapacidad discapacidad)
        {
            admDiagnosticos.AgregaDiscapacidad(discapacidad);
        }

        public void AgregaFactor(Factor factor)
        {
            admDiagnosticos.AgregaFactor(factor);
        }

        public void ActualizaDiagnostico(Diagnostico diagnostico)
        {
            admDiagnosticos.ActualizaDiagnostico(diagnostico);
        }

        public void ActualizaDiscapacidad(Discapacidad discapacidad)
        {
            admDiagnosticos.ActualizaDiscapacidad(discapacidad);
        }

        public void ActualizaFactor(Factor factor)
        {
            admDiagnosticos.ActualizaFactor(factor);
        }

        public void EliminaDiagnostico(int idDiagnostico)
        {
            admDiagnosticos.EliminaDiagnostico(idDiagnostico);
        }

        public void EliminaDiscapacidad(int idDiscapacidad)
        {
            admDiagnosticos.EliminaDiscapacidad(idDiscapacidad);
        }

        public void EliminaFactor(int idFactor)
        {
            admDiagnosticos.EliminaFactor(idFactor);
        }

        public IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico)
        {
            return admDiagnosticos.GetDiscapacidadesDiagnostico(idDiagnostico);
        }

        public IEnumerable<Factor> GetFactoresDiscapacidad(int idDiscapacidad)
        {
            return admDiagnosticos.GetFactoresDiscapacidad(idDiscapacidad);
        }

        public void AsignaDiscapacidadDiagnostico(int idDiscapacidad, int idDiagnostico)
        {
            admDiagnosticos.AsignaDiscapacidadDiagnostico(idDiscapacidad, idDiagnostico);
        }

        public void AsignaFactorDiscapacidad(int idFactor, int idDiscapacidad)
        {
            admDiagnosticos.AsignaFactorDiscapacidad(idFactor, idDiscapacidad);
        }

        public void AsignaDiagnosticoAlumno(int idDiagnostico, int idAlumno)
        {
            admDiagnosticos.AsignaDiagnosticoAlumno(idDiagnostico, idAlumno);
        }


        public Diagnostico GetDiagnostico(int idDiagnostico)
        {
            return admDiagnosticos.GetDiagnostico(idDiagnostico);
        }

        public Discapacidad GetDiscapacidad(int idDiscapacidad)
        {
            return admDiagnosticos.GetDiscapacidad(idDiscapacidad);
        }

        public Factor GetFactor(int idFactor)
        {
            return admDiagnosticos.GetFactor(idFactor);
        }


        public Diagnostico GetDiagnostico(string nombre)
        {
            return admDiagnosticos.GetDiagnostico(nombre);
        }

        public Discapacidad GetDiscapacidad(string nombre)
        {
            return admDiagnosticos.GetDiscapacidad(nombre);
        }

        public Factor GetFactor(string nombre)
        {
            return admDiagnosticos.GetFactor(nombre);
        }


        public System.Data.Entity.DbSet<Diagnostico_Discapacidad> GetRelacionesDiagnosticoDiscapacidad()
        {
            return admDiagnosticos.GetRelacionesDiagnosticoDiscapacidad();
        }

        public System.Data.Entity.DbSet<Discapacidad_Factor> GetRelacionesDiscapacidadFactor()
        {
            return admDiagnosticos.GetRelacionesDiscapacidadFactor();
        }

        public void AgregaRelacionDiagnosticoDiscapacidad(int idDiagnostico, int idDiscapacidad)
        {
            admDiagnosticos.AgregaRelacionDiagnosticoDiscapacidad(idDiagnostico, idDiscapacidad);
        }

        public void AgregaRelacionDiscapacidadFactor(int idDiscapacidad, int idFactor)
        {
            admDiagnosticos.AgregaRelacionDiscapacidadFactor(idDiscapacidad, idFactor);
        }

        public IEnumerable<Factor>GetFactores()
        {
            return admDiagnosticos.GetFactores();
        }

        public IEnumerable<Discapacidad> GetDiscapacidades()
        {
            return admDiagnosticos.GetDiscapacidades();
        }
    }
}

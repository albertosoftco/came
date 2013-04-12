using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.AdministracionDiagnosticos.Interface;
using Came.Modelo.Interface;
using Came.Modelo;
using Came.Negocios.Excepciones;

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
            Diagnostico d = modelo.GetDiagnosticos().Where(i => i.Nombre.Equals(diagnostico.Nombre)).SingleOrDefault();
            if(d != null)
            {
                throw new AdministracionDiagnosticosException("El diagnostico ya existe");
            }
            else
            {
                modelo.GetDiagnosticos().Add(d);
                modelo.SalvaCambios();
            }
        }

        public void AgregaDiscapacidad(Modelo.Discapacidad discapacidad)
        {
            Discapacidad d = modelo.GetDiscapacidades().Where(i => i.Nombre.Equals(discapacidad.Nombre)).SingleOrDefault();
            if (d != null)
            {
                throw new AdministracionDiagnosticosException("La discapacidad ya existe");
            }
            else
            {
                modelo.GetDiscapacidades().Add(d);
                modelo.SalvaCambios();
            }
        }

        public void AgregaFactor(Modelo.Factor factor)
        {
            Factor f = modelo.GetFactores().Where(i => i.Nombre.Equals(factor.Nombre)).SingleOrDefault();
            if (f != null)
            {
                throw new AdministracionDiagnosticosException("El factor ya existe");
            }
            else
            {
                modelo.GetFactores().Add(factor);
                modelo.SalvaCambios();
            }
        }

        public void ActualizaDiagnostico(Modelo.Diagnostico diagnostico)
        {
            Diagnostico d = modelo.GetDiagnosticos().Where(i => i.Nombre.Equals(diagnostico.Nombre)).SingleOrDefault();
            if (d != null)
            {
                d.Nombre = diagnostico.Nombre;
                d.Diagnostico_Discapacidad = null;
                d.Diagnostico_Discapacidad = diagnostico.Diagnostico_Discapacidad;
                d.Descripcion = diagnostico.Descripcion;
                modelo.SalvaCambios();
                return;
            }
            else throw new AdministracionDiagnosticosException("El diagnostico no existe");
        }

        public void ActualizaDiscapacidad(Modelo.Discapacidad discapacidad)
        {
            Diagnostico d = modelo.GetDiagnosticos().Where(i => i.Nombre.Equals(discapacidad.Nombre)).SingleOrDefault();
            if (d != null)
            {
                d.Nombre = discapacidad.Nombre;
                d.Diagnostico_Discapacidad = null;
                d.Diagnostico_Discapacidad = discapacidad.Diagnostico_Discapacidad;
                d.Descripcion = discapacidad.Descripcion;
                modelo.SalvaCambios();
                return;
            }
            else throw new AdministracionDiagnosticosException("El diagnostico no existe");
        }

        public void ActualizaFactor(Modelo.Factor factor)
        {
            Factor f = modelo.GetFactores().Where(i => i.Nombre.Equals(factor.Nombre)).SingleOrDefault();
            if (f != null)
            {
                f.Nombre = factor.Nombre;
                f.Discapacidad_Factor = null;
                f.Discapacidad_Factor = factor.Discapacidad_Factor;
                modelo.SalvaCambios();
                return;

            }
            else throw new AdministracionDiagnosticosException("El factor no existe");
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


        public void AsignaDiscapacidadDiagnostico(int idDiscapacidad, int idDiagnostico)
        {
            throw new NotImplementedException();
        }

        public void AsignaFactorDiscapacidad(int idFactor, int idDiscapacidad)
        {
            throw new NotImplementedException();
        }
    }
}

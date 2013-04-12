using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;
using Came.Modelo;
using Came.Negocios.Excepciones;

namespace Came.Negocios.AdministracionDiagnosticos
{

    /// <summary>
    /// 
    /// </summary>
    class AdministracionDiagnosticos
    {
        /// <summary>
        /// 
        /// </summary>
        private IModelo modelo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelo"></param>
        public AdministracionDiagnosticos(IModelo modelo)
        {
            this.modelo = modelo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagnostico"></param>
        public void AgregaDiagnostico(Diagnostico diagnostico)
        {
            //checa si el diagnostico existe
            Diagnostico di = modelo.GetDiagnosticos().Where(i => i.Nombre.Equals(diagnostico.Nombre)).SingleOrDefault();
            //si no existe lo guarda, si existe, se lanza una excepcion
            if(di == null)
            {
                modelo.GetDiagnosticos().Add(diagnostico);
                modelo.SalvaCambios();
            }
            else
            {
                throw new AdministracionDiagnosticosException("El diagnostico ya existe");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="discapacidad"></param>
        public void AgregaDiscapacidad(Discapacidad discapacidad)
        {
            Discapacidad d = modelo.GetDiscapacidades().Where(i => i.Nombre.Equals(discapacidad.Nombre)).SingleOrDefault();
            if(d == null)
            {
                modelo.GetDiscapacidades().Add(discapacidad);
                modelo.SalvaCambios();
            }
            else
            {
                throw new AdministracionDiagnosticosException("La discapacidad ya existe");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factor"></param>
        public void AgregaFactor(Factor factor)
        {
            Factor f = modelo.GetFactores().Where(i => i.Nombre.Equals(factor.Nombre)).SingleOrDefault();
            if(f == null)
            {
                modelo.GetFactores().Add(factor);
                modelo.SalvaCambios();
            }
            else
            {
                throw new AdministracionDiagnosticosException("El factor ya existe");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagnostico"></param>
        public void ActualizaDiagnostico(Diagnostico diagnostico)
        {
            //checa si existe el diagnostico para actualizarlo, si no se lanza una excepcion
            var d = modelo.GetDiagnosticos().Where(i => i.Nombre.Equals(diagnostico.Nombre)).SingleOrDefault();
            if(d == null)
            {
                throw new AdministracionDiagnosticosException("El diagnostico no existe");
            }
            else
            {
                //actualiza las relaciones 
                if(d.Diagnostico_Discapacidad.Count > 0 )
                {
                    
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="discapacidad"></param>
        public void ActualizaDiscapacidad(Discapacidad discapacidad)
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="factor"></param>
        public void ActualizaFactor(Factor factor)
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagnostico"></param>
        public void EliminaDiagnostico(Diagnostico diagnostico)
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="discapacidad"></param>
        public void EliminaDiscapacidad(Discapacidad discapacidad)
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="factor"></param>
        public void EliminaFactor(Factor factor)
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiagnostico"></param>
        /// <returns></returns>
        public IEnumerable<Discapacidad>GetDiscapacidadesDiagnostico(int idDiagnostico)
        {
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiscapacidad"></param>
        /// <returns></returns>
        public IEnumerable<Factor>GetFactoresDiscapacidad(int idDiscapacidad)
        {
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiscapacidad"></param>
        /// <param name="idDiagnostico"></param>
        public void AsignaDiscapacidadDiagnostico(int idDiscapacidad, int idDiagnostico)
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFactor"></param>
        /// <param name="idDiscapacidad"></param>
        public void AsignaFactorDiscapacidad(int idFactor, int idDiscapacidad)
        {
            
        }

    }
}

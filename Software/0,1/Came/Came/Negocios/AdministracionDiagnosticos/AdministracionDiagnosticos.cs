using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;
using Came.Modelo;
using Came.Negocios.Excepciones;
using System.Data.Entity;

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
        /// <param name="diagnosticoActual"></param>
        public void AgregaDiagnostico(Diagnostico diagnostico)
        {
            //checa si el diagnosticoActual existe
            Diagnostico di = modelo.GetDiagnosticos().Where(i => i.Nombre.Equals(diagnostico.Nombre)).SingleOrDefault();
            //si no existe lo guarda, si existe, se lanza una excepcion
            if (di == null)
            {
                modelo.GetDiagnosticos().Add(diagnostico);
                modelo.SalvaCambios();

            }
            else
            {
                throw new AdministracionDiagnosticosException("El diagnosticoActual ya existe");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="discapacidadActual"></param>
        public void AgregaDiscapacidad(Discapacidad discapacidad)
        {
            Discapacidad d = modelo.GetDiscapacidades().Where(i => i.Nombre.Equals(discapacidad.Nombre)).SingleOrDefault();
            if (d == null)
            {
                modelo.GetDiscapacidades().Add(discapacidad);
                modelo.SalvaCambios();
            }
            else
            {
                throw new AdministracionDiagnosticosException("La discapacidadActual ya existe");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factorActual"></param>
        public void AgregaFactor(Factor factor)
        {
            Factor f = modelo.GetFactores().Where(i => i.Nombre.Equals(factor.Nombre)).SingleOrDefault();
            if (f == null)
            {
                modelo.GetFactores().Add(factor);
                modelo.SalvaCambios();
            }
            else
            {
                throw new AdministracionDiagnosticosException("El factorActual ya existe");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagnosticoActual"></param>
        public void ActualizaDiagnostico(Diagnostico diagnostico)
        {
            //checa si existe el diagnosticoActual para actualizarlo, si no se lanza una excepcion
            var d = modelo.GetDiagnosticos().Where(i => i.ID.Equals(diagnostico.Nombre)).SingleOrDefault();
            if (d == null)
            {
                throw new AdministracionDiagnosticosException("El diagnosticoActual no existe");
            }
            else
            {
                //actualiza los datos basicos del diagnosticoActual
                d.Descripcion = diagnostico.Descripcion;
                d.Nombre = diagnostico.Nombre;
                //actualiza las relaciones 
                if (d.Diagnostico_Discapacidad.Count > 0)
                {
                    foreach (Diagnostico_Discapacidad dd in d.Diagnostico_Discapacidad)
                    {
                        modelo.GetRelacionesDiagnosticoDiscapacidad().Remove(dd);
                    }
                    if (diagnostico.Diagnostico_Discapacidad.Count > 0)
                    {
                        foreach (Diagnostico_Discapacidad dd in diagnostico.Diagnostico_Discapacidad)
                        {
                            modelo.GetRelacionesDiagnosticoDiscapacidad().Add(dd);
                        }
                    }
                    modelo.SalvaCambios();
                }
                else if (diagnostico.Diagnostico_Discapacidad.Count > 0)
                {
                    foreach (Diagnostico_Discapacidad dd in diagnostico.Diagnostico_Discapacidad)
                    {
                        modelo.GetRelacionesDiagnosticoDiscapacidad().Add(dd);
                    }
                    modelo.SalvaCambios();
                }

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="discapacidadActual"></param>
        public void ActualizaDiscapacidad(Discapacidad discapacidad)
        {
            //checa si existe el diagnosticoActual para actualizarlo, si no se lanza una excepcion
            var d = modelo.GetDiscapacidades().Where(i => i.ID.Equals(discapacidad.Nombre)).SingleOrDefault();
            if (d == null)
            {
                throw new AdministracionDiagnosticosException("La discapacidadActual no existe");
            }
            else
            {

                //actualiza los datos basicos del diagnosticoActual
                d.Descripcion = discapacidad.Descripcion;
                d.Nombre = discapacidad.Nombre;
                //actualiza las relaciones 
                if (d.Diagnostico_Discapacidad.Count > 0)
                {
                    foreach (Diagnostico_Discapacidad dd in d.Diagnostico_Discapacidad)
                    {
                        modelo.GetRelacionesDiagnosticoDiscapacidad().Remove(dd);
                    }
                    if (discapacidad.Diagnostico_Discapacidad.Count > 0)
                    {
                        foreach (Diagnostico_Discapacidad dd in discapacidad.Diagnostico_Discapacidad)
                        {
                            modelo.GetRelacionesDiagnosticoDiscapacidad().Add(dd);
                        }
                    }

                }
                else
                {
                    if (discapacidad.Diagnostico_Discapacidad.Count > 0)
                    {
                        foreach (Diagnostico_Discapacidad dd in discapacidad.Diagnostico_Discapacidad)
                        {
                            modelo.GetRelacionesDiagnosticoDiscapacidad().Add(dd);
                        }
                    }
                }
                if (d.Discapacidad_Factor.Count > 0)
                {
                    foreach (Discapacidad_Factor df in d.Discapacidad_Factor)
                    {
                        modelo.GetRelacionesDiscapacidadFactor().Remove(df);
                    }
                    if (discapacidad.Discapacidad_Factor.Count > 0)
                    {
                        foreach (Discapacidad_Factor df in discapacidad.Discapacidad_Factor)
                        {
                            modelo.GetRelacionesDiscapacidadFactor().Add(df);
                        }
                    }
                }
                else
                {
                    if (discapacidad.Discapacidad_Factor.Count > 0)
                    {
                        foreach (Discapacidad_Factor df in discapacidad.Discapacidad_Factor)
                        {
                            modelo.GetRelacionesDiscapacidadFactor().Add(df);
                        }
                    }
                }
                modelo.SalvaCambios();

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="factorActual"></param>
        public void ActualizaFactor(Factor factor)
        {
            var f = modelo.GetFactores().Where(i => i.ID.Equals(factor.ID)).SingleOrDefault();
            if (factor == null)
            {
                throw new AdministracionDiagnosticosException("El diagnosticoActual no existe");
            }
            else
            {
                f.Nombre = factor.Nombre;
                if (f.Discapacidad_Factor.Count > 0)
                {
                    foreach (Discapacidad_Factor df in f.Discapacidad_Factor)
                    {
                        modelo.GetRelacionesDiscapacidadFactor().Remove(df);
                    }
                    if (factor.Discapacidad_Factor.Count > 0)
                    {
                        foreach (Discapacidad_Factor df in factor.Discapacidad_Factor)
                        {
                            modelo.GetRelacionesDiscapacidadFactor().Add(df);
                        }
                    }
                }
                else
                {
                    if (factor.Discapacidad_Factor.Count > 0)
                    {
                        foreach (Discapacidad_Factor df in factor.Discapacidad_Factor)
                        {
                            modelo.GetRelacionesDiscapacidadFactor().Add(df);
                        }
                    }
                }
                modelo.SalvaCambios();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="diagnosticoActual"></param>
        public void EliminaDiagnostico(int diagnostico)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="discapacidadActual"></param>
        public void EliminaDiscapacidad(int discapacidad)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="factorActual"></param>
        public void EliminaFactor(int factor)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiagnostico"></param>
        /// <returns></returns>
        public IEnumerable<Discapacidad> GetDiscapacidadesDiagnostico(int idDiagnostico)
        {
            return modelo.GetDiscapacidadesDiagnostico(idDiagnostico);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiscapacidad"></param>
        /// <returns></returns>
        public IEnumerable<Factor> GetFactoresDiscapacidad(int idDiscapacidad)
        {
            return modelo.GetfactoresDiscapacidad(idDiscapacidad);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiagnostico"></param>
        /// <param name="idAlumno"></param>
        public void AsignaDiagnosticoAlumno(int idDiagnostico, int idAlumno)
        {
            var d = modelo.GetDiagnostico(idDiagnostico);
            if (d == null)
            {
                throw new AdministracionDiagnosticosException("El diagnosticoActual no existe");
            }
            var a = modelo.GetAlumno(idAlumno);
            if (a == null)
            {
                throw new AdministracionDiagnosticosException("El alumno no existe");
            }
            else
            {
                //checa si ya existe una relacion 
                if (a.Diagnostico != null)
                {
                    throw new AdministracionDiagnosticosException("Al alumno solo se le debe de registrar un diagnosticoActual");
                }
                else
                {
                    a.IdDiagnostico = idDiagnostico;
                    modelo.SalvaCambios();
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiscapacidad"></param>
        /// <param name="idDiagnostico"></param>
        public void AsignaDiscapacidadDiagnostico(int idDiscapacidad, int idDiagnostico)
        {
            var dis = modelo.GetDiscapacidad(idDiscapacidad);
            if (dis == null)
            {
                throw new AdministracionDiagnosticosException("La discapacidadActual no existe");
            }
            var dia = modelo.GetDiagnostico(idDiagnostico);
            if (dia == null)
            {
                throw new AdministracionDiagnosticosException("El diagnosticoActual no existe");
            }
            if (dia.Diagnostico_Discapacidad.Where(i => i.IdDiagnostico.Equals(idDiagnostico)).SingleOrDefault() != null &&
                dia.Diagnostico_Discapacidad.Where(i => i.IdDiscapacidad.Equals(idDiscapacidad)).SingleOrDefault() != null)
            {
                throw new AdministracionDiagnosticosException("La relacion ya existe");
            }
            else
            {
                //agrega la relacion
                dia.Diagnostico_Discapacidad.Add(new Diagnostico_Discapacidad { IdDiscapacidad = idDiscapacidad, IdDiagnostico = idDiagnostico });
                modelo.SalvaCambios();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFactor"></param>
        /// <param name="idDiscapacidad"></param>
        public void AsignaFactorDiscapacidad(int idFactor, int idDiscapacidad)
        {
            var dis = modelo.GetDiscapacidad(idDiscapacidad);
            if (dis == null)
            {
                throw new AdministracionDiagnosticosException("La discapacidadActual no existe");
            }
            var fac = modelo.GetFactor(idFactor);
            if (fac == null)
            {
                throw new AdministracionDiagnosticosException("El factorActual no existe");
            }
            else
            {
                //checa si existe la relacion
                var relacion = modelo.GetRelacionesDiscapacidadFactor().Where(i => i.IdFactor.Equals(idFactor) && i.IdDiscapacidad.Equals(idDiscapacidad));

                if (relacion != null)
                {
                    throw new AdministracionDiagnosticosException("La relacion ya existe");
                }
                else
                {
                    modelo.GetRelacionesDiscapacidadFactor().Add(new Discapacidad_Factor { IdDiscapacidad = idDiscapacidad, IdFactor = idFactor });
                    modelo.SalvaCambios();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiagnostico"></param>
        /// <returns></returns>
        public Diagnostico GetDiagnostico(int idDiagnostico)
        {
            return modelo.GetDiagnostico(idDiagnostico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDiscapacidad"></param>
        /// <returns></returns>
        public Discapacidad GetDiscapacidad(int idDiscapacidad)
        {
            return modelo.GetDiscapacidad(idDiscapacidad);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idFactor"></param>
        /// <returns></returns>
        public Factor GetFactor(int idFactor)
        {
            return modelo.GetFactor(idFactor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Diagnostico GetDiagnostico(string nombre)
        {
            return modelo.GetDiagnosticos().Where(i => i.Nombre.Equals(nombre)).SingleOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Discapacidad GetDiscapacidad(string nombre)
        {
            return modelo.GetDiscapacidades().Where(i => i.Nombre.Equals(nombre)).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Factor GetFactor(string nombre)
        {
            return modelo.GetFactores().Where(i => i.Nombre.Equals(nombre)).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbSet<Diagnostico_Discapacidad> GetRelacionesDiagnosticoDiscapacidad()
        {

            return modelo.GetRelacionesDiagnosticoDiscapacidad();
        }

        public DbSet<Discapacidad_Factor> GetRelacionesDiscapacidadFactor()
        {

            return modelo.GetRelacionesDiscapacidadFactor();
        }


        /// <summary>
        /// agrega una relacion al modelo
        /// </summary>
        /// <param name="idDiagnostico"></param>
        /// <param name="idDiscapacidad"></param>
        public void AgregaRelacionDiagnosticoDiscapacidad(int idDiagnostico, int idDiscapacidad)
        {
            modelo.GetRelacionesDiagnosticoDiscapacidad().Add(new Diagnostico_Discapacidad { IdDiagnostico = idDiagnostico, IdDiscapacidad = idDiscapacidad});
            modelo.SalvaCambios();
        }


        /// <summary>
        /// agrega una relacion al modelo
        /// </summary>
        /// <param name="idDiscapacidad"></param>
        /// <param name="idFactor"></param>
        public void AgregaRelacionDiscapacidadFactor(int idDiscapacidad, int idFactor)
        {
            modelo.GetRelacionesDiscapacidadFactor().Add(new Discapacidad_Factor { IdDiscapacidad = idDiscapacidad, IdFactor = idFactor});
            modelo.SalvaCambios();
        }
    }
}


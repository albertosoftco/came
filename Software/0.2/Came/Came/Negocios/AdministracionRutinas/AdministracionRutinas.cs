using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo.Interface;
using Came.Modelo;
using Came.Negocios.Excepciones;

namespace Came.Negocios.AdministracionRutinas
{
    class AdministracionRutinas
    {
        private IModelo modelo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelo"></param>
        public AdministracionRutinas(IModelo modelo)
        {
            this.modelo = modelo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rutina"></param>
        public void AgregaRutina(Rutina rutina)
        {
           
                var r = modelo.GetRutinas().Where(i => i.Nombre.Equals(rutina.Nombre)).SingleOrDefault();
                if(r == null)
                {
                    modelo.GetRutinas().Add(rutina);
                    modelo.SalvaCambios();
                }
                else
                {
                    throw new AdministracionRutinasException("La rutinaActual ya existe");
                }
        }


          
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rutina>GetRutinas()
        {
            return modelo.GetRutinas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programa"></param>
        public void AgregaPrograma(Programa programa)
        {
            if (modelo.GetProgramas().Where(i => i.Nombre.Equals(programa.Nombre)).SingleOrDefault() != null)
            {
                throw new AdministracionRutinasException("El programa ya existe");

            }
            else
            {
                modelo.GetProgramas().Add(programa);
                modelo.SalvaCambios();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actividad"></param>
        public void AgregaActividad(Actividad actividad)
        {
            if(modelo.GetActividades().Where(i=>i.Nombre.Equals(actividad.Nombre) && i.Tipo.Equals(actividad.Tipo)).SingleOrDefault() != null)
            {
                throw new AdministracionRutinasException("La actividad ya existe");
            }
            else
            {
                modelo.GetActividades().Add(actividad);
                modelo.SalvaCambios();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ejercicio"></param>
        public void AgregaEjercicio(Ejercicio ejercicio)
        {
            if(modelo.GetEjercicios().Where(i=>i.Nombre.Equals(ejercicio.Nombre)).Single()!=null)
            {
                throw new AdministracionRutinasException("El ejercicio ya existe");
            }
            else
            {
                modelo.GetEjercicios().Add(ejercicio);
                modelo.SalvaCambios();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IModelo GetModelo()
        {
            return modelo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Ejercicio>GetEjerciciosActividad(int id)
        {
            return modelo.GetEjerciciosActividad(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <returns></returns>
        public IEnumerable<Actividad>GetActividadesPrograma(int idPrograma)
        {
            return modelo.GetActividadesPrograma(idPrograma);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRutina"></param>
        /// <returns></returns>
        public IEnumerable<Programa> GetProgramasRutina(int idRutina)
        {
            return modelo.GetProgramasRutina(idRutina);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <param name="idRutina"></param>
        public void AsignaRutina(int idAlumno,int idRutina)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programas"></param>
        /// <param name="idRutina"></param>
        public void AsignaProgramasRutina(IEnumerable<Programa>programas, int idRutina)
        {
            Rutina rutina = modelo.GetRutina(idRutina);
            if (rutina == null)
            {
                throw new AdministracionRutinasException("La rutinaActual no existe");
            }
            else
            {
                if(programas.Count() == 0)
                {
                    throw new AdministracionRutinasException("La lista de programas esta vaica");
                }
                else
                {
                    foreach(Programa p in programas)
                    {
                      rutina.Rutina_Programa.Add(new Rutina_Programa { IdPrograma = p.ID, IdRutina= idRutina});
                    }
                    modelo.SalvaCambios();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <param name="idRutina"></param>
        public void AsignaProgramaRutina(int idPrograma,int idRutina)
        {
            Programa p = modelo.GetPrograma(idPrograma);
            if(p == null)
            {
                throw new AdministracionRutinasException("El programa no existe");
            }
            Rutina r = modelo.GetRutina(idRutina);
            if(r == null)
            {
                throw new AdministracionRutinasException("La rutinaActual no existe");
            }
            else
            {
                r.Rutina_Programa.Add(new Rutina_Programa { IdPrograma = p.ID,IdRutina=idRutina});
                modelo.SalvaCambios();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Rutina GetRutina(string nombre)
        {
            return modelo.GetRutinas().Where(i => i.Nombre.Equals(nombre)).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actividades"></param>
        /// <param name="idPrograma"></param>
        public void AsignaActividadesPrograma(IEnumerable<Actividad>actividades,int idPrograma)
        {
            Programa p = modelo.GetPrograma(idPrograma);
            if(p == null)
            {
                throw new AdministracionRutinasException("El programa no existe");
            }
            else
            {
                if(actividades.Count() == 0)
                {
                    throw new AdministracionRutinasException("La lista de actividades esta vacia");
                }
                else
                {
                    foreach(Actividad a in actividades)
                    {
                        p.Programa_Actividad.Add(new Programa_Actividad { IdActividad=a.ID, IdPrograma = idPrograma});
                    }
                    modelo.SalvaCambios();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <param name="idPrograma"></param>
        public void AsignaActividadPrograma(int idActividad, int idPrograma)
        {
            Programa p = modelo.GetPrograma(idPrograma);

            if (p == null)
            {
                throw new AdministracionRutinasException("El programa no existe");
            }
            Actividad a = modelo.GetActividad(idActividad);
            if (a == null)
            {
                throw new AdministracionRutinasException("La actividad no existe");
            }
            else
            {
                p.Programa_Actividad.Add(new Programa_Actividad { IdPrograma = p.ID, IdActividad = idActividad });
                modelo.SalvaCambios();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRutina"></param>
        /// <returns></returns>
        public Rutina GetRutina(int idRutina)
        {
            var rutina = modelo.GetRutina(idRutina);
            if(rutina == null)
            {
                throw new AdministracionRutinasException("La rutinaActual no existe");
            }
            else
            {
                return rutina;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Horario>GetHorarios()
        {
            return modelo.GetHorarios();
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Maestro>GetMaestros()
        {
            return modelo.GetMaestros();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMaestro"></param>
        /// <returns></returns>
        public Maestro GetMaestro(int idMaestro)
        {
            return modelo.GetMaestro(idMaestro);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Actividad GetActividad(int id)
        {
            return modelo.GetActividad(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Programa GetPrograma(int id)
        {
            return modelo.GetPrograma(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Programa GetPrograma(string nombre)
        {
            return modelo.GetProgramas().Where(i => i.Nombre.Equals(nombre)).SingleOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ejercicio GetEjercicio(int id)
        {
            return modelo.GetEjercicio(id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Programa>GetProgramas()
        {
            return modelo.GetProgramas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Actividad GetActividad(string nombre)
        {
            return modelo.GetActividades().Where(i => i.Nombre.Equals(nombre)).SingleOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Actividad>GetActividades()
        {
            return modelo.GetActividades();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        public void EliminaPrograma(int idPrograma)
        {
            Programa p = modelo.GetPrograma(idPrograma);
            if (p == null)
            {
                throw new AdministracionRutinasException("El programa no existe");
            }
            else
            {
                if (p.Rutina_Programa.Count > 0)
                {
                    //elimina las relaciones con el programa 
                    var relaciones = modelo.GetRelacionesRutinaPrograma();
                    foreach (Rutina_Programa rp in relaciones)
                    {
                        if(rp.IdPrograma.Equals(idPrograma))
                        {
                            modelo.GetRelacionesRutinaPrograma().Remove(rp);
                            
                        }
                    }
                    var rel = modelo.GetRelacionesProgramaActividad();
                    foreach (Programa_Actividad pa in rel)
                    {
                        if(pa.IdPrograma.Equals(idPrograma))
                        {
                            modelo.GetRelacionesProgramaActividad().Remove(pa);
                            
                        }
                    }
                    //elimina el programa seleccionado y guarda los cambios
                    modelo.GetProgramas().Remove(p);
                    modelo.SalvaCambios();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <param name="idPrograma"></param>
        public void AsignaEjercicioActividad(int idEjercicio, int idActividad)
        {
            Ejercicio ej = modelo.GetEjercicio(idEjercicio);
            if(ej == null)
            {
                throw new AdministracionRutinasException("El ejercicio no existe");
            }
            Actividad ac = modelo.GetActividad(idActividad);
            if(ac == null)
            {
                throw new AdministracionRutinasException("La actividad no existe");
            }
            modelo.GetRelacionesActividadEjercicio().Add(new Actividad_Ejercicio {IdActividad = idActividad, IdEjercicio = idEjercicio });
            modelo.SalvaCambios();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Ejercicio GetEjercicio(string nombre)
        {
            return modelo.GetEjercicios().Where(i => i.Nombre.Equals(nombre)).SingleOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        public void EliminaActividad(int idActividad)
        {
            Actividad a = modelo.GetActividad(idActividad);
            if(a == null)
            {
                throw new AdministracionRutinasException("La actividad no existe");
            }
            else
            {
                //elimina las relaciones de la actividad con ejercicios y programas 
                if(a.Programa_Actividad.Count >0)
                {
                    //relacion con programas
                    var relP = modelo.GetRelacionesProgramaActividad();
                    foreach(Programa_Actividad pa in relP)
                    {
                        if(pa.IdActividad.Equals(idActividad))
                        {
                            modelo.GetRelacionesProgramaActividad().Remove(pa);
                        }
                    }
                }
                if(a.Actividad_Ejercicio.Count >0)
                {
                    var relE = modelo.GetRelacionesActividadEjercicio();
                    foreach(Actividad_Ejercicio ae in relE)
                    {
                        if(ae.IdActividad.Equals(idActividad))
                        {
                            modelo.GetRelacionesActividadEjercicio().Remove(ae);

                        }
                    }
                }
                //elimina la actividad
                modelo.GetActividades().Remove(a);
                modelo.SalvaCambios();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <param name="idRutina"></param>
        public void EliminaRelacionEjercicioActividad(int idEjercicio, int idActividad)
        {
            var ej = modelo.GetEjercicios().Where(i => i.ID.Equals(idEjercicio)).SingleOrDefault();
            if(ej == null)
            {
                throw new AdministracionRutinasException("El ejercicio no existe");
            }
            var ac = modelo.GetActividades().Where(i => i.ID.Equals(idActividad)).SingleOrDefault();
            if(ac == null)
            {
                throw new AdministracionRutinasException("La actividad no existe");
            }
            if(ej.Actividad_Ejercicio.Count == 0)
            {
                return;
            }
            else
            {
                var rel = ej.Actividad_Ejercicio.Where(i => i.IdActividad.Equals(idActividad) && i.IdEjercicio.Equals(idEjercicio)) ;
                foreach(Actividad_Ejercicio ae in rel)
                {
                    modelo.GetModelo().Actividad_Ejercicio.Remove(ae);
                }
                modelo.SalvaCambios();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idRutina"></param>
        /// <param name="idPrograma"></param>
        public void EliminaRelacionActividadPrograma(int idActividad, int idPrograma)
        {
            var ac = modelo.GetEjercicios().Where(i => i.ID.Equals(idActividad)).SingleOrDefault();
            if (ac == null)
            {
                throw new AdministracionRutinasException("El ejercicio no existe");
            }
            var pr = modelo.GetActividades().Where(i => i.ID.Equals(idPrograma)).SingleOrDefault();
            if (ac == null)
            {
                throw new AdministracionRutinasException("La actividad no existe");
            }
            if (pr.Programa_Actividad.Count == 0)
            {
                return;
            }
            else
            {
                var rel = pr.Programa_Actividad.Where(i => i.IdActividad.Equals(idActividad) && i.IdPrograma.Equals(idPrograma)); ;
                foreach (Programa_Actividad ae in rel)
                {
                    modelo.GetModelo().Programa_Actividad.Remove(ae);
                }
                modelo.SalvaCambios();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <param name="idRutina"></param>
        public void EliminaRelacionProgramaRutina(int idPrograma, int idRutina)
        {
            var pr = modelo.GetProgramas().Where(i => i.ID.Equals(idPrograma)).SingleOrDefault();
            if (pr == null)
            {
                throw new AdministracionRutinasException("El Programa no existe");
            }
            var ru = modelo.GetRutinas().Where(i => i.ID.Equals(idRutina)).SingleOrDefault();
            if (ru == null)
            {
                throw new AdministracionRutinasException("La La Rutina no existe");
            }
            if (ru.Rutina_Programa.Count == 0)
            {
                return;
            }
            else
            {
                var rel = pr.Rutina_Programa.Where(i => i.IdRutina.Equals(idRutina) && i.IdPrograma.Equals(idPrograma));
                foreach (Rutina_Programa ae in rel)
                {
                    modelo.GetModelo().Rutina_Programa.Remove(ae);
                }

               
                modelo.SalvaCambios();
            }
            
        }

        public void EliminaRutina(int id, bool borraTodo)
        {
            
        }
    }
}

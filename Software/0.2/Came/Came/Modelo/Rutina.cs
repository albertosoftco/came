//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Came.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rutina
    {
        public Rutina()
        {
            this.Alumno = new HashSet<Alumno>();
            this.Rutina_Programa = new HashSet<Rutina_Programa>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdMaestro { get; set; }
        public string Lugar { get; set; }
        public string Finalidad { get; set; }
        public Nullable<int> IdHorario { get; set; }
    
        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual Horario Horario { get; set; }
        public virtual Horario Horario1 { get; set; }
        public virtual ICollection<Rutina_Programa> Rutina_Programa { get; set; }
    }
}
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
    
    public partial class Actividad
    {
        public Actividad()
        {
            this.Actividad_Ejercicio = new HashSet<Actividad_Ejercicio>();
            this.Programa_Actividad = new HashSet<Programa_Actividad>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
    
        public virtual ICollection<Actividad_Ejercicio> Actividad_Ejercicio { get; set; }
        public virtual ICollection<Programa_Actividad> Programa_Actividad { get; set; }
    }
}

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
    
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            this.Actividad_Ejercicio = new HashSet<Actividad_Ejercicio>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
    
        public virtual ICollection<Actividad_Ejercicio> Actividad_Ejercicio { get; set; }
    }
}

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
    
    public partial class Programa
    {
        public Programa()
        {
            this.Programa_Actividad = new HashSet<Programa_Actividad>();
            this.Rutina_Programa = new HashSet<Rutina_Programa>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Programa_Actividad> Programa_Actividad { get; set; }
        public virtual ICollection<Rutina_Programa> Rutina_Programa { get; set; }
    }
}

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
    
    public partial class Maestro
    {
        public Maestro()
        {
            this.Maestro_Grupo = new HashSet<Maestro_Grupo>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Rfc { get; set; }
        public System.DateTime FechaIngreso { get; set; }
    
        public virtual ICollection<Maestro_Grupo> Maestro_Grupo { get; set; }
    }
}

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
    
    public partial class Rutina_Programa
    {
        public int ID { get; set; }
        public int IdRutina { get; set; }
        public int IdPrograma { get; set; }
    
        public virtual Programa Programa { get; set; }
        public virtual Rutina Rutina { get; set; }
    }
}

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
    
    public partial class Diagnostico_Discapacidad
    {
        public int ID { get; set; }
        public int IdDiagnostico { get; set; }
        public int IdDiscapacidad { get; set; }
    
        public virtual Diagnostico Diagnostico { get; set; }
        public virtual Discapacidad Discapacidad { get; set; }
    }
}

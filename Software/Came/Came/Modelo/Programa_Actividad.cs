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
    
    public partial class Programa_Actividad
    {	
		///<summary>
		///id de la relacion
		///</summary>
        public int ID { get; set; }
		
		///<summary>
		///id del programa
		///</summary>
        public int IdPrograma { get; set; }
		
		///<summary>
		///id de la actividad
		///</summary>
        public int IdActividad { get; set; }
    
		///<summary>
		///actividad de la relacion
		///</summary>
        public virtual Actividad Actividad { get; set; }
		
		///<summary>
		///programa de la relacion
		///</summary>
        public virtual Programa Programa { get; set; }
    }
}

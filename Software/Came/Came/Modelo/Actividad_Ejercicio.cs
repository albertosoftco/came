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
    
    public partial class Actividad_Ejercicio
    {
		///<summary>
		///ID de la relacion
		///</summary>
        public int ID { get; set; }
		
		///<summary>
		///id de la actividad
		///</summary>
        public int IdActividad { get; set; }
		
		///<summary>
		///id del ejercicio
		///</summary>
        public int IdEjercicio { get; set; }
    
		///<summary>
		///Actividad de la relacion
		///</summary>
        public virtual Actividad Actividad { get; set; }
		
		///<summary>
		///ejercicio de la relacion
		///</summary>
        public virtual Ejercicio Ejercicio { get; set; }
    }
}

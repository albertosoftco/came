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
    
    public partial class Alumno_Alergia
    {
		///<summary>
		///ID de la relacion
		///</summary>
        public int ID { get; set; }
		
		///<summary>
		///id del alumno de la relacion
		///</summary>
        public int IdAlumno { get; set; }
		
		///<summary>
		///id de la alergia de la relacion
		///</summary>
        public int IdAlergia { get; set; }
    
		///<summary>
		///alergia de la relacion
		///</summary>
        public virtual Alergia Alergia { get; set; }
		
		///<summary>
		///alumno de la relacion
		///</summary>
        public virtual Alumno Alumno { get; set; }
    }
}
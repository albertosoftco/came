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
    
    public partial class Grupo_Alumno
    {
		///<summary>
		///id de la relacion
		///</summary>
        public int ID { get; set; }
		
		///<summary>
		///id del grupo
		///</summary>
        public int IdGrupo { get; set; }
		
		///<summary>
		///id del alumno
		///</summary>
        public int IdAlumno { get; set; }
    
		///<summary>
		///alumno de la relacion
		///</summary>
        public virtual Alumno Alumno { get; set; }
		
		///<summary>
		///grupo de la relacion
		///</summary>
        public virtual Grupo Grupo { get; set; }
    }
}
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
    
    public partial class Discapacidad_Factor
    {
		///<summary>
		///id de la relacion
		///</summary>
        public int ID { get; set; }
		
		///<summary>
		///id de la discapacidad 
		///</summary>
        public int IdDiscapacidad { get; set; }
		
		///<summary>
		///id del factor
		///</summary>
        public int IdFactor { get; set; }
    
		///<summary>
		///discapacidad de la relacion
		///</summary>
        public virtual Discapacidad Discapacidad { get; set; }
		
		///<summary>
		///factor de la relacion
		///</summary>
        public virtual Factor Factor { get; set; }
    }
}

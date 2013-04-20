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
		///<summary>
		///constructor de la clase 
		///</summary>
        public Programa()
        {
            this.Programa_Actividad = new HashSet<Programa_Actividad>();
            this.Rutina_Programa = new HashSet<Rutina_Programa>();
        }
    
		///<summary>
		///id del programa
		///</summary>
        public int ID { get; set; }
		
		///<summary>
		///nomre del programa
		///</summary>
        public string Nombre { get; set; }
    
		///<summary>
		///coleccion de relaciones con actividades
		///</summary>
        public virtual ICollection<Programa_Actividad> Programa_Actividad { get; set; }
		
		///<summary>
		///coleccion de relaciones con rutinas
		///</summary>
        public virtual ICollection<Rutina_Programa> Rutina_Programa { get; set; }
    }
}
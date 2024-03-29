﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entidades : DbContext
    {
        public Entidades()
            : base("name=Entidades")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<Actividad_Ejercicio> Actividad_Ejercicio { get; set; }
        public DbSet<Alergia> Alergia { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Alumno_Alergia> Alumno_Alergia { get; set; }
        public DbSet<Alumno_Medicamento> Alumno_Medicamento { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<Diagnostico_Discapacidad> Diagnostico_Discapacidad { get; set; }
        public DbSet<Discapacidad> Discapacidad { get; set; }
        public DbSet<Discapacidad_Factor> Discapacidad_Factor { get; set; }
        public DbSet<Ejercicio> Ejercicio { get; set; }
        public DbSet<Factor> Factor { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Grupo_Alumno> Grupo_Alumno { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Maestro> Maestro { get; set; }
        public DbSet<Maestro_Grupo> Maestro_Grupo { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Programa> Programa { get; set; }
        public DbSet<Programa_Actividad> Programa_Actividad { get; set; }
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<Rutina_Programa> Rutina_Programa { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}

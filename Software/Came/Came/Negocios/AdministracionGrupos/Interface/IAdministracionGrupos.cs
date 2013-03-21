using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Modelo;


namespace Came.Negocios.AdministracionGrupos.Interface
{
    interface IAdministracionGrupos
    {
        //METODOS PARA ACCEDER DESDE EL CASO DE USO ADMINISTRACION DE ALUMNOS 
        // metodo para agregar un alumno a un grupo
        void AgregarAlumnoGrupo(int idAlumno, int idGrupo);

        //metodo para agregar un alumno a un grupo
        void AgregarAlumnoGrupo(Alumno alumno, Grupo grupo);

        //elimina un alumno de un grupo
        void EliminaAlumnoGrupo(int idAlumno, int idGrupo);

        //cambia a un alumno de un grupo a otro 
        void CambiaAlumnoGrupo(int idAlumno, int grupoAnterior, int grupoNuevo);

        // METODOS PARA ACCEDER DESDE LA PANTALLA PRINCIPAL
        //agrega un grupo nuevo a la base de datos 
        void AgregarGrupo(Grupo grupo);

        //actualiza un grupo en la base de datos 
        void ActualizarGrupo(Grupo grupo);

        //obtiene un grupo de la base de datos 
        Grupo GetGrupo(int ID);

        //elimina un grupo de la base de dato s
        void EliminaGrupo(int ID);



    }
}

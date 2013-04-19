using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Came.Modelo.Interface;
using Came.Negocios.AdministracionRutinas.Interface;
using Came.Modelo.Fachada;
using Came.Negocios.AdministracionRutinas.Fachada;
using Came.Negocios.Excepciones;
using Came.Modelo;
using System.Collections.ObjectModel;


namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Rutinas.xaml
    /// </summary>
    public partial class Rutinas : Window
    {
        
        private int indice;
        private IModelo modelo;
        private IAdministracionRutinas admRutinas;
        public Rutina rutinaActual;
        public Programa programaCreado;
        public enum Acciones{Agregar,Actualizar,Eliminar,Ver}
        public Acciones accion;
        public Rutina rutinaSeleccionada;
        public ObservableCollection<Horario> horarios;
        public ObservableCollection<Actividad> actividadesPrograma;
        public ObservableCollection<Ejercicio> ejerciciosActividad;

        /// <summary>
        /// 
        /// </summary>
        public Rutinas(int idRutina, Acciones accion)
        {
            indice = 0;
            this.accion = accion;
            modelo = FachadaModelo.GetInstance();
            admRutinas = new FachadaAdministracionRutinas();
            InitializeComponent();
            //actualiza la lista de tipos de actividad
            try
            {
                rutinaSeleccionada = admRutinas.GetRutina(idRutina);
            }
            catch(AdministracionRutinasException e)
            {
                MessageBox.Show(e.Message, "Error");
                return;
            }
            //checa el tipo de accion 
            switch(accion)
            {
                case Acciones.Agregar:
                    //muestra la ventana en blanco para agregar una 
                    //rutina nueva
                    rutinaActual = new Rutina();
                    MuestraRutinaNueva();
                    break;

                case Acciones.Actualizar:
                    //Muestra la rutina para actualizarla 
                    MuestraRutina(rutinaSeleccionada);
                    break;

                case Acciones.Eliminar:
                    //Elimina la rutina por medio del ID 
                    break;

                case Acciones.Ver:
                    //se muestra la informacion en la pantalla 
                    //INEDITABLE
                    MuestraRutina(rutinaSeleccionada);

                    break;
            }
            
            
            
             
            


        }



        private void MuestraRutinaActualizar()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volverMenuButton_Click(object sender, RoutedEventArgs e)
        {

        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volverButton_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarEjercicioButton_Click(object sender, RoutedEventArgs e)
        {
            ejerciciosActividad = ejercicioDataGrid.ItemsSource as ObservableCollection<Ejercicio>;
            Actividad actividad = admRutinas.GetActividad(nombreActividadBox.Text);
            if(ejerciciosActividad.Count ==0)
            {
                MessageBox.Show("No se crearon ejercicios","Error");
                return;
            }
            else
            {
                foreach(Ejercicio ej in ejerciciosActividad)
                {
                    //agrega el ejercicio y la relacion a la actividad
                    admRutinas.AgregaEjercicio(ej);
                    Ejercicio nvo = admRutinas.GetEjercicio(ej.Nombre);
                    //liga los ejercicios a la actividad seleccionada 
                    admRutinas.AsignaEjercicioActividad(nvo.ID, actividad.ID);
                }
                
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitarActividadButton_Click(object sender, RoutedEventArgs e)
        {
            Actividad a = actividadesDataGrid.SelectedItem as Actividad;
            if(a == null)
            {
                MessageBox.Show("No se ha seleccionado ninguna actividad","Error");
                return;
            }
            else
            {

                admRutinas.EliminaActividad(a.ID);
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarActividadButton_Click(object sender, RoutedEventArgs e)
        {
            actividadesPrograma = actividadesDataGrid.ItemsSource as ObservableCollection<Actividad>;
            if(actividadesPrograma.Count == 0)
            {
                MessageBox.Show("No se agregaron actividades","Error");
                return;
            }
            else
            {
                //agrega el programa 
                if(string.IsNullOrEmpty(nombreProgramaBox.Text))
                {
                    MessageBox.Show("No se especifico el nombre del programa", "Error");
                    return;
                }
                else
                {
                    programaCreado = new Programa { Nombre = nombreProgramaBox.Text};
                }

                try
                {
                //agrega el programa a la bd 
                admRutinas.AgregaPrograma(programaCreado);
                //lo actualiza para obtener el id 
                programaCreado = admRutinas.GetPrograma(programaCreado.Nombre);
                //asigna el programa a la rutinaActual 
                admRutinas.AsignaProgramaRutina(programaCreado.ID,rutinaActual.ID);
                    foreach(Actividad a in actividadesPrograma)
                    {   //agrega las actividades y las liga con el programa
                        admRutinas.AgregaActividad(a);
                        Actividad actividad = admRutinas.GetActividad(a.Nombre);
                        admRutinas.AsignaActividadPrograma(actividad.ID, programaCreado.ID);
                    }

                    
                    
                    
                }
                catch(AdministracionRutinasException ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                
                
                


            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verActividadButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void quitarProgramaButton_Click(object sender, RoutedEventArgs e)
        {
            Programa programa = programaList.SelectedItem as Programa;
            if(programa == null)
            {
                MessageBox.Show("No se ha seleccionado ningun programa","Error");
                return;
            }
            else
            {
                try
                {
                    //elimina todas las relaciones del programa y sus actividades y ejercicios
                    if(programa.Rutina_Programa.Count >0)
                    {
                        foreach(Rutina_Programa rp in programa.Rutina_Programa)
                        {
                            
                        }
                    }
                    admRutinas.EliminaPrograma(programa.ID);
                    programaList.ItemsSource = new ObservableCollection<Programa>(admRutinas.GetProgramas());
                }
                catch(AdministracionRutinasException ex)
                {
                    MessageBox.Show(ex.Message, "Error");    
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualizarProgramaButton_Click(object sender, RoutedEventArgs e)
        {
            switch(accion)
            {
                case Acciones.Agregar:
                    
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitarMaestroButton_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarMaestroButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #region GUI Members

        private void MuestraRutina(Rutina rutina)
        {
            
            switch(accion)
            {
                case Acciones.Ver:
                agregarProgramaButton.Visibility = System.Windows.Visibility.Hidden;
                quitarProgramaButton.Visibility = System.Windows.Visibility.Hidden;
                actualizarProgramaButton.Visibility = System.Windows.Visibility.Hidden;
                nombreProgramaBox.IsEnabled = false;
                actividadesDataGrid.IsEnabled = true;
                actividadesDataGrid.CanUserAddRows = false;
                agregarActividadButton.Visibility = System.Windows.Visibility.Hidden;
                quitarActividadButton.Visibility = System.Windows.Visibility.Hidden;
                ejercicioDataGrid.IsEnabled = false;
                agregarEjercicioButton.Visibility = System.Windows.Visibility.Hidden;
                quitarEjercicioButton.Visibility = System.Windows.Visibility.Hidden;
            


                idRutinaBox.Text = rutina.ID.ToString();
                idRutinaBox.IsEnabled = false;
                nombreBox.Text = rutina.Nombre;
                nombreBox.IsEnabled = false;
                horarios = new ObservableCollection<Horario>(admRutinas.GetHorarios());
                horarioComboBox.ItemsSource = horarios;
                horarioComboBox.SelectedItem = rutinaSeleccionada.Horario;
                horarioComboBox.IsEnabled = false;
                finalidadTextBox.Text = rutinaSeleccionada.Finalidad;
                finalidadTextBox.IsEnabled = false;
                maestrosComboBox.ItemsSource = new ObservableCollection<Maestro>(admRutinas.GetMaestros());
                if(rutina.IdMaestro ==0)
                {
                    maestrosComboBox.SelectedItem = null;
                }
                else
                {
                    if(rutina.IdMaestro !=null)
                    {
                        int id = rutina.IdMaestro.Value;
                        maestrosComboBox.SelectedItem = admRutinas.GetMaestro(id);
                        maestrosComboBox.IsEnabled = false;
                    }
                    else
                    {
                        maestrosComboBox.SelectedItem = null;
                    }
                }
                //llena la lista de programas 
                programaList.ItemsSource = new ObservableCollection<Programa>(admRutinas.GetProgramasRutina(rutina.ID));
                break;

                case Acciones.Actualizar:

                    nombreBox.IsEnabled = true;
                    nombreBox.Text = rutina.Nombre;
                    horarioComboBox.ItemsSource = new ObservableCollection<Horario>(admRutinas.GetHorarios());
                    horarioComboBox.SelectedItem = rutina.Horario;
                    horarioComboBox.IsEnabled = true;

                    finalidadTextBox.Text = rutina.Finalidad;
                    finalidadTextBox.IsEnabled = true;

                    lugarTextBox.Text = rutina.Lugar;
                    lugarTextBox.IsEnabled = true;

                    maestrosComboBox.ItemsSource = new ObservableCollection<Maestro>(admRutinas.GetMaestros());
                    maestrosComboBox.SelectedItem = rutina != null ? admRutinas.GetMaestro(rutina.IdHorario.Value) : null;
                    maestrosComboBox.IsEnabled = true;

                    programaList.ItemsSource = new ObservableCollection<Programa>(admRutinas.GetProgramas());
                    programaList.IsEnabled = true;
                    
                    agregarProgramaButton.IsEnabled = true;
                    quitarProgramaButton.IsEnabled = true;
                    actualizarProgramaButton.IsEnabled = true;
                    break;

                    
            }
            
             //esconde todos los botones de agregar, modificar y eliminar
        }


        private void VerProgramas(Programa programa)
        {
            

        }
        #endregion

        
        
        


        private void MuestraRutinaNueva()
        {
            //muestra todos los campos necesarios para agregar una rutinaActual 
            idRutinaBox.Visibility = System.Windows.Visibility.Hidden;
            idRutinaLabel.Visibility = System.Windows.Visibility.Hidden;
            agregarProgramaButton.Visibility = System.Windows.Visibility.Visible;
            actualizarProgramaButton.Visibility = System.Windows.Visibility.Visible;
            quitarProgramaButton.Visibility = System.Windows.Visibility.Visible;
            horarios = new ObservableCollection<Horario>(admRutinas.GetHorarios());
            horarioComboBox.ItemsSource = horarios;
            horarioComboBox.SelectedItem = null;
            maestrosComboBox.ItemsSource = new ObservableCollection<Maestro>(admRutinas.GetMaestros());
            maestrosComboBox.SelectedItem = null;
            nombreProgramaBox.IsEnabled = false;
            agregarActividadButton.IsEnabled = false;
            quitarActividadButton.IsEnabled = false;
            agregarEjercicioButton.IsEnabled = false;
            quitarEjercicioButton.IsEnabled = false;
            actividadesDataGrid.ItemsSource = null;
            nombreProgramaBox.IsEnabled = true;
            nombreActividadBox.IsEnabled = false;
            ejercicioDataGrid.IsEnabled = false;
            actividadesDataGrid.ItemsSource = new ObservableCollection<Actividad>();
            programaList.ItemsSource = new ObservableCollection<Programa>(admRutinas.GetProgramas());
            nombreProgramaBox.IsEnabled = false;
            actividadesDataGrid.IsEnabled = false;
            ejercicioDataGrid.IsEnabled = false;
            ObservableCollection<Programa> ps = programaList.ItemsSource as ObservableCollection<Programa>;
            if(ps.Count ==0)
            {
                button4.IsEnabled = false;    
            }
            else
            {
                button4.IsEnabled = true;
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // crea la rutinaActual 
            Rutina rutina = CreaRutina();
        }

        private Rutina CreaRutina()
        {
            Rutina rutina = new Rutina();
            if(string.IsNullOrEmpty(nombreBox.Text))
            {
                MessageBox.Show("El campo de nombre se dejo vacio", "Error");
            }
            else
            {
                rutina.Nombre = nombreBox.Text;
            }
            return null;
        }

        private void agregarProgramaButton_Click(object sender, RoutedEventArgs e)
        {

            switch(accion)
            {
                case Acciones.Agregar:
                    //agrega la rutina
                    try
                    {
                        admRutinas.AgregaRutina(rutinaActual);
                        this.rutinaActual = admRutinas.GetRutina(rutinaActual.Nombre);
                    }
                    catch(AdministracionRutinasException ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }
                    
                    nombreProgramaBox.IsEnabled = true;
                    nombreActividadBox.Text = "";
                    actividadesDataGrid.IsEnabled = true;
                    actividadesDataGrid.CanUserAddRows = true;
                    button1.IsEnabled = false;
                    agregarActividadButton.IsEnabled = true;
                    quitarActividadButton.IsEnabled = true;
                    nombreActividadBox.IsEnabled = false;
                    ejercicioDataGrid.IsEnabled = false;
                    break;

                case Acciones.Actualizar:
                    actividadesDataGrid.ItemsSource = new ObservableCollection<Actividad>(admRutinas.GetActividadesPrograma(rutinaActual.ID));
                    actividadesDataGrid.IsEnabled = true;
                    actividadesDataGrid.CanUserAddRows = true;

                    break;
            }
            

        }

       
        
        

        private void programaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(accion)
            {
                case Acciones.Ver:
                    button4_Click_1(sender, e);
                    break;

                case Acciones.Agregar:
                    break;

                case Acciones.Actualizar:
                    button4_Click_1(sender, e);
                    nombreProgramaBox.IsEnabled = false;
                    actividadesDataGrid.IsEnabled = true;
                    actividadesDataGrid.CanUserAddRows = true;
                    break;


            }
            
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            Actividad actividad = actividadesDataGrid.SelectedItem as Actividad;
            if (actividad == null)
            {
                MessageBox.Show("No se ha seleccionado ninguna actividad", "Error");
                return;
            }
            else
            {
                nombreActividadBox.Text = actividad.Nombre;
                if (actividad.Actividad_Ejercicio.Count == 0)
                {
                    MessageBox.Show("La actividad no tiene ejercicios registrados", "Error");
                    return;
                }
                else
                {
                    ejerciciosActividad = new ObservableCollection<Ejercicio>(admRutinas.GetEjerciciosActividad(actividad.ID));
                    ejercicioDataGrid.ItemsSource = ejerciciosActividad;
                    ejercicioDataGrid.SelectedItem = null;
                    ejercicioDataGrid.IsEnabled = true;
                    ejercicioDataGrid.CanUserAddRows = false;
                }
            }
        }

        private void button4_Click_1(object sender, RoutedEventArgs e)
        {
            Programa programa = programaList.SelectedItem as Programa;
            if (programa == null)
            {
                MessageBox.Show("No se ha seleccionado ningun programa", "Error");
                return;
            }
            else
            {
                nombreProgramaBox.Text = programa.Nombre;
                if (programa.Programa_Actividad.Count == 0)
                {
                    MessageBox.Show("El programa no tiene actividades registradas", "Error");
                }
                else
                {

                    actividadesPrograma = new ObservableCollection<Actividad>(admRutinas.GetActividadesPrograma(programa.ID));
                    actividadesDataGrid.ItemsSource = actividadesPrograma;
                    actividadesDataGrid.SelectedItem = null;
                    actividadesDataGrid.IsEnabled = true;
                    
                }

            }
        }

        private void actividadesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
        //    //deshabilita la tabla de actividades para agregarle ejercicios a la actividad
        //    actividadesDataGrid.IsEnabled = false;
        //    //obtiene el elemento que se edito

        }

        private void actividadesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Actividad a = actividadesDataGrid.SelectedItem as Actividad;
            if (a == null)
            {
                return;
            }
            else
            {
                if(accion == Acciones.Ver)
                {
                    ejerciciosActividad = new ObservableCollection<Ejercicio>(admRutinas.GetEjerciciosActividad(a.ID));
                    //solo muestra los ejercicios de la actividad
                    //sin posibilidades de editar las filas de la tabla 
                    if(ejerciciosActividad.Count ==0)
                    {
                        //deja la tabla como esta sin lo botones agregar y quitar 
                        agregarEjercicioButton.IsEnabled = false;
                        quitarEjercicioButton.IsEnabled = false;
                        ejercicioDataGrid.IsEnabled = false;

                        return;
                    }
                    else
                    {
                        ejercicioDataGrid.ItemsSource = ejerciciosActividad;
                        agregarEjercicioButton.IsEnabled = false;
                        quitarEjercicioButton.IsEnabled = false;
                        ejercicioDataGrid.IsEnabled = false;
                    }
                }
                if(accion == Acciones.Agregar)
                {
                    //muestra la tabla en blanco para agregarle ejercicios a la actividad seleccionada 
                    //y la vuelve editable junto con los botones agregar y quitar
                    ejerciciosActividad = new ObservableCollection<Ejercicio>();
                    ejercicioDataGrid.ItemsSource = ejerciciosActividad;
                    agregarEjercicioButton.IsEnabled = true;
                    ejercicioDataGrid.IsEnabled=true;
                    quitarEjercicioButton.IsEnabled = true;
                    nombreActividadBox.Text = a.Nombre;
                    nombreActividadBox.IsEnabled = true;
                }
            }
        }

        private void quitarEjercicioButton_Click(object sender, RoutedEventArgs e)
        {
            Actividad ac = actividadesDataGrid.SelectedItem as Actividad;
            if(ac == null)
            {
                MessageBox.Show("No se ha seleccionado ninguna actividad","Error");
                return;
            }
            Ejercicio ej = ejercicioDataGrid.SelectedItem as Ejercicio;
            if(ej ==null)
            {
                MessageBox.Show("No se ha seleccionado ningun ejercicio","Error");
                return;
            }
            else
            {
                //elimina las relaciones con actividades
                if(ej.Actividad_Ejercicio.Count>0)
                {
                    admRutinas.EliminaRelacionEjercicioActividad(ej.ID, ac.ID);
                }
            }

        }

        private void nombreBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            rutinaActual.Nombre = nombreBox.Text;
                
        }

        private void horarioComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rutinaActual.Horario = horarioComboBox.SelectedItem as Horario;
        }

        private void finalidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            rutinaActual.Finalidad = finalidadTextBox.Text;
        }

        private void lugarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            rutinaActual.Lugar = lugarTextBox.Text;
        }

        private void maestrosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var maestro = maestrosComboBox.SelectedItem as Maestro;
            if(maestro == null)
            {
                rutinaActual.IdMaestro = null;
                return;
            }
            else
            {
                rutinaActual.IdMaestro = maestro.ID;
            }
        }
       

        
    }
}

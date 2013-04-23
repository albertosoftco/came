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
//directivas CAME
using Came.Negocios.AdministracionAlumnos;
using Came.Negocios.AdministracionAlumnos.Fachada;
using Came.Negocios.AdministracionAlumnos.Interface;
using Came.Modelo;
using Came.Modelo.Interface;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Alumnos.xaml
    /// </summary>
    public partial class Alumnos : Window
    {

        /// <summary>
        /// el grupo actual
        /// </summary>
        public Grupo grupoActual;
        /// <summary>
        /// rutina actual
        /// </summary>
        public Rutina rutinaActual;

        /// <summary>
        /// diagnostico actual
        /// </summary>
        public Diagnostico diagnosticoActual;

        /// <summary>
        /// alergia actual
        /// </summary>
        public Alergia alergiaActual;
        /// <summary>
        /// medicamento actual
        /// </summary>
        public Medicamento medicamentoActual;
        /// <summary>
        /// lista de alergias del alumno
        /// </summary>
        public ObservableCollection<Alergia> alergiasAlumno;
        /// <summary>
        /// lista de medicamentos del alumno
        /// </summary>
        public ObservableCollection<Medicamento> medicamentosAlumno;
        /// <summary>
        /// tutor cargado en memoria 
        /// </summary>
        public Tutor tutorActual;
        /// <summary>
        /// acciones disponibles en el subsistema
        /// </summary>
        public enum Acciones { Ver, Agregar, Actualizar, Eliminar }

        /// <summary>
        /// accion que se lleva a cabo
        /// </summary>
        public Acciones accion;
        /// <summary>
        /// alumnos actual 
        /// </summary>
        public Alumno alumnoActual;

        /// <summary>
        /// interface del subsistema de alumno
        /// </summary>
        private IAdministracionAlumnos admAlumnos;

        /// <summary>
        /// lista enlazada a la lista de los alumnos en la pantalla principal
        /// </summary>
        public ObservableCollection<Alumno> alumnos;


        public ObservableCollection<Grupo> grupos;
        /// <summary>
        /// constructor de la clase 
        /// </summary>
        public Alumnos(IModelo modelo)
        {
            InitializeComponent();
            admAlumnos = new FachadaAdministracionAlumnos(modelo);
            alumnoActual = new Alumno();
            //inicia la lista de alumnos
            alumnos = new ObservableCollection<Alumno>(admAlumnos.GetAlumnos());
            tAlumnos.ItemsSource = alumnos;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// boton agregar alumno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            accion = Acciones.Agregar;
            //inicializa un nuevo alumno 
            medicamentosAlumno = new ObservableCollection<Medicamento>();
            alergiasAlumno = new ObservableCollection<Alergia>();
            MenuAlumnos.IsEnabled = false;
            MenuAlumnos.Visibility = System.Windows.Visibility.Hidden;
            AccionAlumnos.IsEnabled = true;
            AccionAlumnos.Visibility = System.Windows.Visibility.Visible;
            if (admAlumnos.GetGrupos().Count() == 0)
            {
                grupoComboBox.ItemsSource = null;
            }
            grupoComboBox.ItemsSource = new ObservableCollection<Grupo>(admAlumnos.GetGrupos());
            textBox1.IsEnabled = false;
            nombreDiagnosticoTextBox.IsEnabled = false;
            medicamentosAlumno = new ObservableCollection<Medicamento>();
            alergiasAlumno = new ObservableCollection<Alergia>();
            medicamentoActual = new Medicamento();
            alergiaActual = new Alergia();
        }


        /// <summary>
        /// reestablece todos los valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reestablecerButton_Click(object sender, RoutedEventArgs e)
        {
            alumnoActual = null;
            matriculaBox.Text = "";
            datePicker1.SelectedDate = new DateTime();

        }



        #region GUIMembers
        /// <summary>
        /// si la matricula cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matriculaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            alumnoActual.Matricula = matriculaBox.Text;
        }


        /// <summary>
        /// si la curp cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void curpBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            alumnoActual.CURP = curpBox.Text;
        }


        /// <summary>
        /// si el nombre cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            alumnoActual.Nombre = nombreBox.Text;
        }


        /// <summary>
        /// si la direccion cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void direccionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            alumnoActual.Direccion = direccionBox.Text;
        }



        /// <summary>
        /// si el tipo de sangre cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tipoSangreComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tipo = tipoSangreComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(tipo))
                return;
            alumnoActual.TipoSangre = tipo;
        }


        /// <summary>
        /// si la talla del uniforme cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tallaUniformeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tallaUniformeBox.Text))
                return;
            alumnoActual.TallaUniforme = tallaUniformeBox.Text;
        }


        /// <summary>
        /// si el grado academico cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gradoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(gradoTextBox.Text))
                return;
            alumnoActual.GradoAcademico = gradoTextBox.Text;
        }


        /// <summary>
        /// si se desea agregar un tutor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (tutorActual != null)
            {


                if (MuestraMensaje("El alumno ya tiene un tutor asignado\n ¿Desea eliminarlo?", "Agregar Tutor", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
                    CanvasTutor.Visibility = System.Windows.Visibility.Visible;
                    //inicia un tutor nuevo y elimina el existente
                    tutorActual = new Tutor();

                }
                else
                {
                    return;
                }
            }
            else
            {
                AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
                CanvasTutor.Visibility = System.Windows.Visibility.Visible;
                tutorActual = new Tutor();
            }
        }



        /// <summary>
        /// muestra un cuadro con un mensaje y las opciones 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="btn"></param>
        /// <param name="img"></param>
        private MessageBoxResult MuestraMensaje(string mensaje, string tipo, MessageBoxButton btn, MessageBoxImage img)
        {
            return MessageBox.Show(mensaje, tipo, btn, img);
        }


        #region TutorMembers
        /// <summary>
        /// si el nombre del tutor cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreTutorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(nombreTutorTextBox.Text))
                return;
            if(admAlumnos.GetTutores().Where(i=>i.Nombre.Equals(nombreTutorTextBox.Text)).SingleOrDefault()!=null)
            {
                MuestraMensaje("El tutor ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            tutorActual.Nombre = nombreTutorTextBox.Text;
        }


        /// <summary>
        /// si la direccion del tutor cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void direccionTutorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(direccionTutorTextBox.Text))
                return;
            tutorActual.Direccion = direccionTutorTextBox.Text;
        }

        /// <summary>
        /// si el telefono del tutor cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void telefonoTutorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(telefonoTutorTextBox.Text))
                return;
            tutorActual.Telefono = telefonoTutorTextBox.Text;
        }


        /// <summary>
        /// si el celular del tutor cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void celularTutorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(celularTutorTextBox.Text))
                return;
            tutorActual.Celular = celularTutorTextBox.Text;
        }
        #endregion

        /// <summary>
        /// guarda el tutor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonGuardarTutor_Click(object sender, RoutedEventArgs e)
        {
            //checa si el tutor ya existe
            if (admAlumnos.GetTutores().Where(i => i.Nombre.Equals(tutorActual.Nombre)).SingleOrDefault() == null)
            {
                CanvasTutor.Visibility = System.Windows.Visibility.Hidden;
                AccionAlumnos.Visibility = System.Windows.Visibility.Visible;

                textBox1.Text = tutorActual.Nombre;
            }
            else
            {
                if (MuestraMensaje("El tutor ya existe,\n¿Desea ligarlo con el alumno?", "Tutor", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
                {
                    CanvasTutor.Visibility = System.Windows.Visibility.Hidden;
                    AccionAlumnos.Visibility = System.Windows.Visibility.Visible;

                    textBox1.Text = tutorActual.Nombre;
                }
                else
                {
                    return;
                }
            }

        }





        /// <summary>
        /// cancela el proceso de tutores
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCancelarTutor_Click(object sender, RoutedEventArgs e)
        {
            CanvasTutor.Visibility = System.Windows.Visibility.Hidden;
            AccionAlumnos.Visibility = System.Windows.Visibility.Visible;
            tutorActual = null;
        }


        #endregion


        /// <summary>
        /// reestablece todos los campos de la ventana 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reestablecerButton_Click_1(object sender, RoutedEventArgs e)
        {
            datePicker1.DisplayDate = new DateTime();
            matriculaBox.Text = "";
            curpBox.Text = "";
            nombreBox.Text = "";
            direccionBox.Text = "";
            textBox1.Text = "";
            tutorActual = new Tutor();
            tipoSangreComboBox.SelectedIndex = 0;
            grupoComboBox.SelectedItem = null;
            tallaUniformeBox.Text = "";
            gradoTextBox.Text = "";

        }


        /// <summary>
        /// si se desea actualizar el tutor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (tutorActual == null)
            {
                MuestraMensaje("El alumno no tiene asignado un tutor", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
            CanvasTutor.Visibility = System.Windows.Visibility.Visible;
            //llena los campos del tutor con los de tutor actual 
            if (tutorActual != null)
            {
                nombreTutorTextBox.Text = tutorActual.Nombre;
                direccionTutorTextBox.Text = direccionTutorTextBox.Text;
                telefonoTutorTextBox.Text = tutorActual.Telefono;
                celularTutorTextBox.Text = tutorActual.Celular;
            }
            else
            {
                MuestraMensaje("No se ha asignado ningun tutor al alumno", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }


        /// <summary>
        /// elimina al tutor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (accion == Acciones.Agregar)
            {
                tutorActual = null;
                textBox1.Text = "";
            }
        }


        /// <summary>
        /// muestra al tutor creado para el alumno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
            CanvasTutor.Visibility = System.Windows.Visibility.Visible;
            if (tutorActual != null)
            {
                nombreTutorTextBox.Text = tutorActual.Nombre;
                direccionTutorTextBox.Text = direccionTutorTextBox.Text;
                telefonoTutorTextBox.Text = tutorActual.Telefono;
                celularTutorTextBox.Text = tutorActual.Celular;
                //los pone como solo lectura
                nombreTutorTextBox.IsEnabled = false;
                direccionTutorTextBox.IsEnabled = false;
                telefonoTutorTextBox.IsEnabled = false;
                celularTutorTextBox.IsEnabled = false;
                botonGuardarTutor.IsEnabled = false;
            }
            else
            {
                MuestraMensaje("No se ha agregado ningun tutor", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }


        /// <summary>
        /// si se quiere agregar un medicamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            switch (accion)
            {
                case Acciones.Agregar:

                    //esconde el canvas de accion para mostras el de medicamento
                    AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
                    CanvasMedicamentos.Visibility = System.Windows.Visibility.Visible;
                    //limpia todos los campos y limpia el medicamento actual
                    nombreMedTextBox.Text = "";
                    descripcionMedTextBox.Text = "";
                    horasMedTextBox.Text = "";
                    medicamentoActual = new Medicamento();
                    break;
            }

        }


        #region MedicamentoMembers
        /// <summary>
        /// si el nombre del medicamento cambia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreMedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(nombreMedTextBox.Text))
                return;
            if(admAlumnos.GetMedicamentos().Where(i=>i.Nombre.Equals(nombreMedTextBox.Text)).SingleOrDefault()!=null)
            {
                MuestraMensaje("El medicamento ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            medicamentoActual.Nombre = nombreMedTextBox.Text;
        }


        /// <summary>
        /// si las horas del medicamento cambian 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void horasMedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(horasMedTextBox.Text))
                return;
            medicamentoActual.Horas = horasMedTextBox.Text;
        }

        /// <summary>
        /// si la descripcion del medicamento cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descripcionMedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(descripcionMedTextBox.Text))
                return;
            medicamentoActual.Descripcion = descripcionMedTextBox.Text;
        }

        /// <summary>
        /// esconde el canvas de medicamentos y se agrega a la lista de medicamentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonGuardarMed_Click(object sender, RoutedEventArgs e)
        {
            if (!MedicamentoVacio(medicamentoActual))
            {
                MuestraMensaje("Se dejaron campos vacios en el medicamento", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            else
            {
                switch (accion)
                {
                    case Acciones.Agregar:
                        //verifica si el medicamento existe en la bd
                        var med = admAlumnos.GetMedicamentos().Where(i => i.Nombre.Equals(medicamentoActual.Nombre)).SingleOrDefault();
                        if (med == null)
                        {
                            //agrega el nuevo medicamento a la lista
                            medicamentosAlumno.Add(medicamentoActual);
                            //actualiza la lista de medicamentos
                            listBox1.ItemsSource = medicamentosAlumno;
                            //muestra el canvas de alumno
                            CanvasMedicamentos.Visibility = System.Windows.Visibility.Hidden;
                            AccionAlumnos.Visibility = System.Windows.Visibility.Visible;
                            medicamentoActual = new Medicamento();
                        }
                        else
                        {
                            MuestraMensaje("El medicamento ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// verifica que un medicamento no este vacio
        /// </summary>
        /// <param name="med"></param>
        /// <returns></returns>
        private bool MedicamentoVacio(Medicamento med)
        {
            if (string.IsNullOrEmpty(med.Nombre))
                return false;
            if (string.IsNullOrEmpty(med.Horas))
                return false;
            if (string.IsNullOrEmpty(descripcionMedTextBox.Text))
                return false;
            return true;
        }


        /// <summary>
        /// si el usuario desea cancelar el canvas medicamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAtrasMed_Click(object sender, RoutedEventArgs e)
        {
            //esconde el canvas y borra el medicamento creado 
            CanvasMedicamentos.Visibility = System.Windows.Visibility.Hidden;
            AccionAlumnos.Visibility = System.Windows.Visibility.Visible;
            medicamentoActual = new Medicamento();

        }


        #endregion


        private void button2_Click_1(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// si se desea actualizar el medicamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    //se establecen los campos del medicamento 
                    medicamentoActual = listBox1.SelectedItem as Medicamento;
                    

                    if (medicamentoActual != null)
                    {
                        AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
                        CanvasMedicamentos.Visibility = System.Windows.Visibility.Visible;
                        nombreMedTextBox.Text = medicamentoActual.Nombre;
                        horasMedTextBox.Text = medicamentoActual.Horas;
                        descripcionMedTextBox.Text = medicamentoActual.Descripcion;
                        //vuelve ineditables los componentes 
                        nombreMedTextBox.IsEnabled = true;
                        horasMedTextBox.IsEnabled = true;
                        descripcionMedTextBox.IsEnabled = true;
                        botonGuardarMed.IsEnabled = true;

                    }
                    else
                    {
                        MuestraMensaje("No se ha seleccionado ningun medicamento", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        medicamentoActual = new Medicamento();
                    }
                    break;
            }
        }

        /// <summary>
        /// si se quiere eliminar el tutor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    if (tutorActual != null)
                    {
                        tutorActual = new Tutor();
                        nombreTutorTextBox.Text = " ";
                    }
                    else
                    {
                        MuestraMensaje("No se ha asignado un tutor al alumno", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    break;
            }
        }


        /// <summary>
        /// si se desea ver el tutor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click_1(object sender, RoutedEventArgs e)
        {
            if (tutorActual != null)
            {
                AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
                CanvasTutor.Visibility = System.Windows.Visibility.Visible;
                //llena los campos del tutor NO modificables 
                nombreTutorTextBox.Text = tutorActual.Nombre;
                direccionTutorTextBox.Text = tutorActual.Direccion;
                telefonoTutorTextBox.Text = tutorActual.Telefono;
                celularTutorTextBox.Text = tutorActual.Celular;
                textBox1.Text = tutorActual.Nombre;

                nombreTutorTextBox.IsEnabled = false;
                direccionTutorTextBox.IsEnabled = true;
                telefonoTutorTextBox.IsEnabled = false;
                celularTutorTextBox.IsEnabled = false;
                botonGuardarTutor.IsEnabled = false;
            }
            else
            {
                MuestraMensaje("El alumno no tiene asignado un tutor", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }

        /// <summary>
        /// si se desea eliminar el medicamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    var med = listBox1.SelectedItem as Medicamento;
                    if (med != null)
                        medicamentoActual = med;

                    if (medicamentoActual != null)
                    {
                        //se limina el medicamento de la lista 
                        medicamentosAlumno.Remove(medicamentoActual);
                        listBox1.ItemsSource = medicamentosAlumno;

                    }
                    else
                    {
                        MuestraMensaje("No se ha seleccionado un medicamento", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    break;
            }
        }


        /// <summary>
        /// si se desea ver un medicamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //muestra el medicamento ***solo lectura***
            var med = listBox1.SelectedItem as Medicamento;
            if (med != null)
                medicamentoActual = med;
            if (medicamentoActual != null)
            {
                //lo muestra
                nombreMedTextBox.Text = medicamentoActual.Nombre;
                horasMedTextBox.Text = medicamentoActual.Horas;
                descripcionMedTextBox.Text = medicamentoActual.Descripcion;
                nombreMedTextBox.IsEnabled = false;
                descripcionMedTextBox.IsEnabled = false;
                horasMedTextBox.IsEnabled = false;
                botonGuardarMed.IsEnabled = false;
                AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
                CanvasMedicamentos.Visibility = System.Windows.Visibility.Visible;

            }
            else
            {
                medicamentoActual = new Medicamento();
                MuestraMensaje("No se ha seleccionado un medicamento", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }

        /// <summary>
        /// si se desea agregar una alergia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAleButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            //limpia todos los componentes editables 
            alergiaActual.Nombre = "";
            alergiaActual.Descripcion = "";
            alergiaActual.Tratamiento = "";
            botonGuardarAlergia.IsEnabled = true;
            AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
            CanvasAlergias.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// si se desea guardar la alergia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonGuardarAlergia_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    if (alergiasAlumno.Where(i => i.Nombre.Equals(alergiaActual.Nombre)).SingleOrDefault() != null)
                    {
                        MuestraMensaje("Ya existe una alergia con ese nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    else if(admAlumnos.GetAlergias().Where(i => i.Nombre.Equals(alergiaActual.Nombre)).SingleOrDefault() != null)
                    {
                        MuestraMensaje("Ya existe una alergia con ese nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    else
                    {
                        //agrega la alergia y actualiza la lista
                        alergiasAlumno.Add(alergiaActual);
                        alergiaListBox.ItemsSource = alergiasAlumno;
                        //esconde el canvas 
                        CanvasAlergias.Visibility = System.Windows.Visibility.Hidden;
                        AccionAlumnos.Visibility = System.Windows.Visibility.Visible;
                    }
                    break;
            }

        }


        /// <summary>
        /// verifica si la alergia esta vacia o no
        /// </summary>
        /// <param name="alergia"></param>
        /// <returns></returns>
        private bool AlergiaVacia(Alergia alergia)
        {
            if (string.IsNullOrEmpty(nombreAlergiaTextBox.Text))
                return false;
            if (string.IsNullOrEmpty(descripcionAlergiaTextBox.Text))
                return false;
            if (string.IsNullOrEmpty(tratamientoAlergiaTextBox.Text))
                return false;
            return true;
        }


        /// <summary>
        /// si el nombre de la alergia cambia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreAlergiaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(nombreAlergiaTextBox.Text))
                return;
            if(admAlumnos.GetAlergias().Where(i=>i.Nombre.Equals(nombreAlergiaTextBox.Text)).SingleOrDefault()!=null)
            {
                MuestraMensaje("La alergia ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            alergiaActual.Nombre = nombreAlergiaTextBox.Text;
        }


        /// <summary>
        /// si el tratamiento de la alergia cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tratamientoAlergiaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tratamientoAlergiaTextBox.Text))
                return;
            alergiaActual.Tratamiento = tratamientoAlergiaTextBox.Text;
        }


        /// <summary>
        /// si la descripcion de la alergia cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descripcionAlergiaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(descripcionAlergiaTextBox.Text))
                return;
            alergiaActual.Descripcion = descripcionAlergiaTextBox.Text;
        }

        /// <summary>
        /// regresa a la pantalla de alumnos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonAtrasAlergia_Click(object sender, RoutedEventArgs e)
        {
            if (MuestraMensaje("¿Seguro que desea salir?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                CanvasAlergias.Visibility = System.Windows.Visibility.Hidden;
                AccionAlumnos.Visibility = System.Windows.Visibility.Visible;
                alergiaActual = new Alergia();

            }
            else
            {
                return;
            }

        }

        /// <summary>
        /// si se quiere actualizar una alergia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actAleButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {

                case Acciones.Agregar:
                    var al = alergiaListBox.SelectedItem as Alergia;
                    if (al == null)
                    {
                        MuestraMensaje("No se ha seleccionado ninguna alergia", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    //actualiza la alergia
                    alergiaActual = al;
                    //muestra sus datos
                    nombreAlergiaTextBox.Text = alergiaActual.Nombre;
                    descripcionAlergiaTextBox.Text = alergiaActual.Descripcion;
                    tratamientoAlergiaTextBox.Text = alergiaActual.Tratamiento;
                    //vuelve los campos editables
                    nombreAlergiaTextBox.IsEnabled = true;
                    descripcionAlergiaTextBox.IsEnabled = true;
                    tratamientoAlergiaTextBox.IsEnabled = true;
                    botonGuardarAlergia.IsEnabled = true;
                    //muestra el canvas
                    AccionAlumnos.Visibility = System.Windows.Visibility.Hidden;
                    CanvasAlergias.Visibility = System.Windows.Visibility.Visible;
                    break;
            }

        }

        /// <summary>
        /// si se desea eliminar una alergia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delAleButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    var alergia = alergiaListBox.SelectedItem as Alergia;
                    if (alergia != null)
                    {
                        // se elimina la alergia de la lista
                        alergiasAlumno.Remove(alergia);
                        alergiaListBox.ItemsSource = alergiasAlumno;
                    }
                    else
                    {
                        MuestraMensaje("No se ha seleccionado ninguna alergia", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }

                    break;
            }
        }


        /// <summary>
        /// si se desea agregar un diagnostico para el alumno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addDiaButton_Copy1_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    Diagnosticos d = new Diagnosticos(0, admAlumnos.GetModelo(), Diagnosticos.Acciones.Agregar);
                    if (admAlumnos.GetDiagnosticos().Where(i => i.ID.Equals(d.diagnosticoActual.ID)).SingleOrDefault() != null)
                    {
                        diagnosticoActual = d.diagnosticoActual;
                        alumnoActual.IdDiagnostico = diagnosticoActual.ID;
                        nombreDiagnosticoTextBox.Text = diagnosticoActual.Nombre;

                    }
                    else return;
                    break;
            }
        }

        /// <summary>
        /// si se desea actualizar el diagnostico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actDiaButton_Copy1_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    
                    var diag = admAlumnos.GetDiagnosticos().Where(i => i.ID.Equals(diagnosticoActual.ID)).SingleOrDefault();
                    if (diag != null)
                    {
                        Diagnosticos d = new Diagnosticos(diagnosticoActual.ID, admAlumnos.GetModelo(), Diagnosticos.Acciones.Actualizar);

                    }
                    else
                    {
                        MuestraMensaje("No se ha asignado un diagnostico al alumno", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    }
                    break;
            }
        }

        /// <summary>
        /// si se desea eliminar el diagnostico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, RoutedEventArgs e)
        {

            switch (accion)
            {
                case Acciones.Agregar:
                    var diagnostico = admAlumnos.GetDiagnosticos().Where(i => i.ID.Equals(diagnosticoActual.ID)).SingleOrDefault();
                    if (diagnostico != null)
                    {
                        if (MuestraMensaje("¿Seguro que desea eliminar el diagnostico?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
                        {
                            alumnoActual.Diagnostico = null;
                            nombreDiagnosticoTextBox.Text = "";
                            diagnosticoActual = new Diagnostico();
                            alumnoActual.Diagnostico = null;
                            alumnoActual.IdDiagnostico = 0;
                        }
                        else return;
                    }
                    break;
            }
        }


        /// <summary>
        /// si se desea ver el diagnostico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verDiaButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (diagnosticoActual.ID == 0)
            {
                MuestraMensaje("El alumno no tiene asigando un diagnostico", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            else
            {
                Diagnosticos d = new Diagnosticos(diagnosticoActual.ID, admAlumnos.GetModelo(), Diagnosticos.Acciones.Ver);
            }
        }

        /// <summary>
        /// si se desea agregar una rutina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addRutButton_Copy3_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    rutinaActual = new Rutina();
                    if (rutinaActual.ID == 0 || rutinaActual == null)
                    {
                        Rutinas r = new Rutinas(0, admAlumnos.GetModelo(), Rutinas.Acciones.Agregar);
                        rutinaActual = r.GetRutinaActual();
                        nombreRutinaTextBox.Text = rutinaActual.Nombre;
                        nombreRutinaTextBox.IsEnabled = false;

                    }
                    break;
            }
        }

        /// <summary>
        /// si se desea actualizar la rutina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actRutButton_Copy3_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    if (rutinaActual != null)
                    {
                        Rutinas r = new Rutinas(rutinaActual.ID, admAlumnos.GetModelo(), Rutinas.Acciones.Actualizar);
                        rutinaActual = r.GetRutinaActual();
                        nombreRutinaTextBox.Text = rutinaActual.Nombre;
                    }

                    break;
            }
        }


        /// <summary>
        /// si se desea eliminar la rutina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    if (rutinaActual.ID == 0)
                    {
                        MuestraMensaje("El alumno no tiene una rutina asignada", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    else
                    {
                        rutinaActual = new Rutina();
                        nombreRutinaTextBox.Text = "";
                        nombreRutinaTextBox.IsEnabled = false;

                    }
                    break;
            }
        }

        /// <summary>
        /// si se desea ver la rutina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verRutButton_Copy2_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:
                    if (rutinaActual.ID == 0)
                    {
                        MuestraMensaje("El alumno no tiene una rutina asignada", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    else
                    {
                        Rutinas r = new Rutinas(rutinaActual.ID, admAlumnos.GetModelo(), Rutinas.Acciones.Ver);
                    }
                    break;
            }
        }


        /// <summary>
        /// elimina un alumno 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var alumno = tAlumnos.SelectedItem as Alumno;
            if (alumno == null)
            {
                MuestraMensaje("No se ha seleccionado ningun alumno", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            else
            {

                admAlumnos.EliminaAlumno(alumno.ID, false);
                alumnos.Remove(alumno);
                tAlumnos.ItemsSource = alumnos;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var al = tAlumnos.SelectedItem as Alumno;
            if (al != null)
            {
                accion = Acciones.Actualizar;
                //muestra los datos del alumno
                datePicker1.SelectedDate = alumnoActual.FechaNacimiento;
                matriculaBox.Text = alumnoActual.Matricula;
                curpBox.Text = alumnoActual.CURP;
                nombreBox.Text = alumnoActual.Nombre;
                direccionBox.Text = alumnoActual.Direccion;
                tutorActual = admAlumnos.GetTutores().Where(i => i.ID.Equals(alumnoActual.IdTutor)).SingleOrDefault();
                nombreTutorTextBox.Text = tutorActual.Nombre;
                tipoSangreComboBox.SelectedItem = alumnoActual.TipoSangre;
                grupoComboBox.SelectedItem = alumnoActual.Grupo;
                tallaUniformeBox.Text = alumnoActual.TallaUniforme;
                gradoTextBox.Text = alumnoActual.GradoAcademico;
                //carga la lista de medicamentos 
                var relacionesMed = admAlumnos.GetRelacionesAlumnoMedicamento().Where(i => i.IdAlumno.Equals(alumnoActual.ID));
                medicamentosAlumno = new ObservableCollection<Medicamento>();
                foreach (var rm in relacionesMed)
                {
                    //obtiene el medicamento de las relaciones 
                    medicamentosAlumno.Add(rm.Medicamento);
                }
                listBox1.ItemsSource = medicamentosAlumno;
                //carga la lista de alergias 
                var relacionesAle = admAlumnos.GetRelacionesAlumnoAlergia().Where(i => i.IdAlumno.Equals(alumnoActual.ID));
                alergiasAlumno = new ObservableCollection<Alergia>();

                foreach (var a in relacionesAle)
                {
                    alergiasAlumno.Add(a.Alergia);
                }
                alergiaListBox.ItemsSource = alergiasAlumno;

                //obtiene el diagnostico y la rutina
                if (alumnoActual.IdDiagnostico != 0)
                {
                    diagnosticoActual = admAlumnos.GetDiagnosticos().Where(i => i.ID.Equals(alumnoActual.IdDiagnostico)).SingleOrDefault();
                    //lo muestra
                    nombreDiagnosticoTextBox.Text = diagnosticoActual.Nombre;
                    nombreDiagnosticoTextBox.IsEnabled = false;
                }
                //la rutina
                if (alumnoActual.IdRutina != 0)
                {
                    rutinaActual = admAlumnos.GetRutinas().Where(i => i.ID.Equals(alumnoActual.IdRutina)).SingleOrDefault();
                    nombreRutinaTextBox.Text = rutinaActual.Nombre;
                    nombreRutinaTextBox.IsEnabled = false;
                }

            }
            else
            {
                MuestraMensaje("No se ha seleccionado ningun alumno", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }


        /// <summary>
        /// guarda los cambios 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Agregar:

                    //agrega al tutor si no existe
                    admAlumnos.AgregaTutor(tutorActual);
                    //lo actualiza 
                    tutorActual = admAlumnos.GetTutores().Where(i => i.Nombre.Equals(tutorActual.Nombre)).SingleOrDefault();
                    alumnoActual.IdGrupo = grupoActual != null ? grupoActual.ID : 0;

                    //le agrega las relaciones al alumno
                    foreach (Medicamento am in medicamentosAlumno)
                    {
                        alumnoActual.Alumno_Medicamento.Add(new Alumno_Medicamento { IdMedicamento = am.ID, IdAlumno = alumnoActual.ID });
                    }
                    foreach (Alergia a in alergiasAlumno)
                    {
                        alumnoActual.Alumno_Alergia.Add(new Alumno_Alergia { IdAlergia = a.ID, IdAlumno = alumnoActual.ID });
                    }
                    //actualiza la lista de alumnos 
                    alumnoActual.IdRutina = rutinaActual != null ? rutinaActual.ID : 0;
                    //alumnoActual.FechaNacimiento = datePicker1.SelectedDate.Value;
                    alumnoActual.FechaRegistro = new DateTime();
                    admAlumnos.AgregaAlumno(alumnoActual);
                    //lo actualiza
                    alumnoActual = admAlumnos.GetAlumno(alumnoActual.CURP);
                    alumnos = new ObservableCollection<Alumno>(admAlumnos.GetAlumnos());
                    tAlumnos.ItemsSource = alumnos;
                    break;

                case Acciones.Actualizar:

                    break;
            }
        }


        /// <summary>
        /// regresa a la pantalla principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// si la seleccion del grupo cambia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grupoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grupo = grupoComboBox.SelectedItem as Grupo;
            if (grupo == null)
                return;
            grupoActual = grupo;
        }
    }
}

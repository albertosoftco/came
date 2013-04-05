using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using Came.Modelo;
using Came.Modelo.Interface;
using Came.Negocios.AdministracionGrupos.Fachada;
using Came.Negocios.AdministracionGrupos.Interface;
using Came.Modelo.Fachada;
using System.Collections.ObjectModel;
using Came.Negocios.AdministracionMaestros.Interface;
using Came.Negocios.AdministracionMaestros.Fachada;

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Grupos.xaml
    /// </summary>
    public partial class Grupos : Window
    {
        private IModelo modelo;
        public ObservableCollection<Maestro> maestros;
        public ObservableCollection<ParsedAlumno> lista;
        private IAdministracionGrupos admGrupos;
        public Grupo grupoSeleccionado;
        private IAdministracionMaestros admMaestros;
        private enum Acciones {VerGrupo,AgregaGrupo,ModificaGrupo,EliminaGrupo};
        private Acciones accion;
        /// <summary>
        /// 
        /// </summary>

        public Grupos()
        {

            InitializeComponent();
            modelo = FachadaModelo.GetInstance();
            admGrupos = new FachadaAdministracionGrupos(modelo);
            admMaestros = new FachadaAdministracionMaestros(modelo);

            System.Windows.Data.CollectionViewSource gruposViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("gruposViewSource")));


            admGrupos.GetModelo().GetGrupos().Load();

            gruposViewSource.Source = admGrupos.GetModelo().GetGrupos().Local;
            gruposDataGrid.SelectedItem = null;
            
        }




        #region Adm Grupos




        private void ActualizaComboBox()
        {
            maestros = new ObservableCollection<Maestro>();
            var maes = admMaestros.GetMaestros();
            foreach (Maestro m in maes)
            {
                maestros.Add(m);
            }

            maestrosComboBox.ItemsSource = maestros;
            
            maestrosComboBox.IsReadOnly = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verGrupoButton_Click(object sender, RoutedEventArgs e)
        {

            var pg = gruposDataGrid.SelectedItem as Grupo;

            if (pg == null)
            {
                MessageBox.Show("No se ha seleccionado ningun grupo.");
                return;
            }
            else
            {
                int id = pg.ID;
                grupoSeleccionado = admGrupos.GetGrupo(id);
                gruposGroupBox.Visibility = System.Windows.Visibility.Hidden;
                grupoActionsCanvas.Visibility = System.Windows.Visibility.Visible;
                modificarGrupoButton.Visibility = System.Windows.Visibility.Hidden;
                crearGrupoButton.Visibility = System.Windows.Visibility.Hidden;
                agregarAlumnoButton.Visibility = System.Windows.Visibility.Hidden;
                agregarMaestroButton.Visibility = System.Windows.Visibility.Hidden;
                eliminarAlumnoButton.Visibility = System.Windows.Visibility.Hidden;
                eliminarMaestroButton.Visibility = System.Windows.Visibility.Hidden;


                idGrupoBox.Text = pg.ID.ToString();
                nombreGrupoBox.Text = pg.Nombre;
                capacidadBox.Text = pg.Capacidad.ToString();
                ActualizaHorario();
                ActualizaComboBox();
                maestrosComboBox.SelectedItem = grupoSeleccionado.Maestro;
                ActualizaTablaAlumnos(id);
                
            }


        }

        private void ActualizaHorario()
        {
            Horario horario = grupoSeleccionado.Horario;
            diasBox.Text = horario.Dias;
            horasBox.Text = horario.Horas;
        }
        /// <summary>
        /// limpia todos los campos del la pantalla 
        /// </summary>
        private void LimpiaCampos()
        {
            idGrupoBox.Text = "";
            nombreGrupoBox.Text = "";
            capacidadBox.Text = "";
            maestrosComboBox.ItemsSource = null;
            maestrosComboBox.SelectedItem = null;
            alumnoDataGrid.ItemsSource = null;
            grupoSeleccionado = null;
            gruposDataGrid.SelectedItem = null;
            diasBox.Text = "";
            horasBox.Text = "";
            
        }

        /// <summary>
        /// actualiza la tabla de alumnos 
        /// </summary>
        /// <param name="id"></param>
        private void ActualizaTablaAlumnos(int id)
        {

            lista = new ObservableCollection<ParsedAlumno>();
            var alumnos = admGrupos.GetAlumnosGrupo(id);
            //checa los alumnos en el grupo
            foreach (Alumno a in alumnos)
            {
                if (a.Grupo.ID == id)
                {
                    lista.Add(ParsedAlumno.creaAlumno(a, true));
                }
                else
                {
                    lista.Add(ParsedAlumno.creaAlumno(a, false));
                }

            }
            alumnoDataGrid.ItemsSource = lista;


        }


        /// <summary>
        /// evento del boton agregargrupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarGrupoButton_Click(object sender, RoutedEventArgs e)
        {
            gruposGroupBox.Visibility = System.Windows.Visibility.Hidden;
            idGrupoLabel.Visibility = System.Windows.Visibility.Hidden;
            idGrupoBox.Visibility = System.Windows.Visibility.Hidden;
            idGrupoBox.Visibility = System.Windows.Visibility.Hidden;
            idGrupoLabel.Visibility = System.Windows.Visibility.Hidden;
            grupoActionsCanvas.Visibility = System.Windows.Visibility.Visible;
            agregarMaestroButton.Visibility = System.Windows.Visibility.Visible;
            agregarAlumnoButton.Visibility = System.Windows.Visibility.Visible;
            eliminarAlumnoButton.Visibility = System.Windows.Visibility.Visible;
            eliminarMaestroButton.Visibility = System.Windows.Visibility.Visible;
            crearGrupoButton.Visibility = System.Windows.Visibility.Visible;
            cancelarButton.Visibility = System.Windows.Visibility.Visible;
            ActualizaComboBox();

            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualizarGrupoButton_Click(object sender, RoutedEventArgs e)
        {
            grupoActionsCanvas.Visibility = System.Windows.Visibility.Visible;
            gruposGroupBox.Visibility = System.Windows.Visibility.Hidden;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarGrupoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Acciones Grupo

        #region Acciones de Maestros

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verMaestroButton_Click(object sender, RoutedEventArgs e)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarMaestroButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Acciones de Alumnos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verAlumnoButton_Click(object sender, RoutedEventArgs e)
        {


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarAlumnoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarAlumnoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Acciones de Grupo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificarGrupoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearGrupoButton_Click(object sender, RoutedEventArgs e)
        {
            Grupo grupo = new Grupo();
            try
            {
                if (capacidadBox.Text == null)
                {
                    MuestraMensaje("Se dejo un campo en blanco", "Error");

                }
                else
                {
                    grupo.Capacidad = int.Parse(capacidadBox.Text);
                }
                if(diasBox.Text == null || horasBox.Text == null)
                {
                    MuestraMensaje("Se dejo un campo en blanco", "Error");
                }
                else
                {
                    Horario h = new Horario();
                    h.Dias = diasBox.Text;
                }
                if(nombreGrupoBox.Text == null)
                {

                    Horario h = new Horario();
                    h.Dias = diasBox.Text;
                }
                else
                {
                    grupo.Nombre = nombreGrupoBox.Text;
                }
                if(maestrosComboBox.SelectedItem ==null)
                {
                    MuestraMensaje("Se dejo un campo en blanco", "Error");
                }
                else
                {
                    grupo.Maestro = maestrosComboBox.SelectedItem as Maestro;
                }
                IEnumerable<Alumno> alumnos = alumnoDataGrid.ItemsSource.Cast<Alumno>();
                
                if(alumnos.Count()==0)
                {
                    MuestraMensaje("Se dejo un campo en blanco", "Error");
                }
                else
                {
                    ICollection<Alumno> al = new Collection<Alumno>();
                    foreach(Alumno a in alumnos)
                    {
                        al.Add(a);
                    }
                    grupo.Alumno = al;

                    admGrupos.AgregarGrupo(grupo);
                    
                }

            }
            catch(Exception)
            {
                
            }
            
        }

        
        private void MuestraMensaje(string mensaje,string titulo)
        {
            MessageBox.Show(mensaje,titulo,MessageBoxButton.OK);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volverButton_Click(object sender, RoutedEventArgs e)
        {
            grupoActionsCanvas.Visibility = System.Windows.Visibility.Hidden;
            gruposGroupBox.Visibility = System.Windows.Visibility.Visible;
            LimpiaCampos();
        }

        #endregion

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volverMenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gruposDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?\nSe perderan los cambios no guardados", "Salir", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                volverButton_Click(sender, e);
            }
            else return;
        }

        

    }


    partial class ParsedGrupo
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string NombreMaestro { get; set; }
        public int Alumnos { get; set; }
        public int ID { get; set; }
        public IModelo modelo { get; set; }
        public ParsedGrupo()
        {

        }

        public ParsedGrupo creaParsedGrupo(Grupo grupo)
        {
            ParsedGrupo gp = new ParsedGrupo();
            gp.Alumnos = grupo.Grupo_Alumno.Count();
            gp.Capacidad = grupo.Capacidad;
            gp.Nombre = grupo.Nombre;
            gp.NombreMaestro = grupo.Maestro.Nombre;
            gp.ID = grupo.ID;
            return gp;
        }

    }

    public partial class ParsedAlumno
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }
        public bool Agregado { get; set; }
        public ParsedAlumno()
        {

        }

        public static ParsedAlumno creaAlumno(Alumno alumno, bool agregado)
        {
            ParsedAlumno al = new ParsedAlumno() { Matricula = alumno.ID, Nombre = alumno.Nombre, Grado = alumno.GradoAcademico, Agregado = agregado };
            return al;
        }

    }
}

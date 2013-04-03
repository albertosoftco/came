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

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Grupos.xaml
    /// </summary>
    public partial class Grupos : Window
    {
        private Entidades entidad = new Entidades();
        private IAdministracionGrupos admGrupos;
        private IModelo modelo;
        private Grupo grupoSeleccionado;

        /// <summary>
        /// 
        /// </summary>
        //public Grupos(IModelo modelo)
             public Grupos()
        {
   
            InitializeComponent();
            modelo = new FachadaModelo();
            //this.modelo = modelo;
            //admGrupos = new FachadaAdministracionGrupos(this.modelo);
                // grupoSeleccionado = null;
                 //ActualizarTablaGrupos();

                 System.Windows.Data.CollectionViewSource gruposViewSource =
                     ((System.Windows.Data.CollectionViewSource)(this.FindResource("gruposViewSource")));

                 entidad.Grupo.Load();

                 gruposViewSource.Source = entidad.Grupo.Local;
        }


        private void ActualizarTablaGrupos()
        {
            //ParsedGrupo par = new ParsedGrupo();
            //par.modelo = modelo;
            //IEnumerable<Grupo> grupos = admGrupos.GetGrupos().AsEnumerable();
            //List<Grupo> gs = grupos.ToList();
            //gruposDataGrid.ItemsSource = gs;
            ////agrega las columas 
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID",typeof(int));
            //dt.Columns.Add("Nombre", typeof(string));
            //dt.Columns.Add("Capacidad", typeof(int));
            //dt.Columns.Add("Maestro", typeof(string));
            //dt.Columns.Add("Alumnos", typeof(int));

            //foreach(Grupo g in grupos)
            //{
            //    ParsedGrupo pg = par.creaParsedGrupo(g);
            //    dt.Rows.Add(g.ID,pg.Nombre, pg.Capacidad, pg.NombreMaestro, pg.Alumnos);
            //}

            
            //gruposDataGrid.ItemsSource = dt.AsDataView();
            
            
            
        }
        #region Adm Grupos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verGrupoButton_Click(object sender, RoutedEventArgs e)
        {
            var pg = gruposDataGrid.SelectedItem as DataRowView;
            
            if(pg == null)
            {
                MessageBox.Show("No se ha seleccionado ningun grupo.");
                return;
            }
            else
            {
                int id = int.Parse(pg.Row.ItemArray[0].ToString());
                

                grupoActionsCanvas.Visibility = System.Windows.Visibility.Visible;
                gruposGroupBox.Visibility = System.Windows.Visibility.Hidden;
                ActualizaCanvasDetallesGrupo(id);
            }

            
        }

        private void ActualizaCanvasDetallesGrupo(int idGrupo)
        {
            IEnumerable<Alumno> alumnos = admGrupos.GetAlumnosGrupo(idGrupo).AsEnumerable();
            Grupo grupo = admGrupos.GetGrupo(idGrupo);
            idGrupoBox.Text = grupo.ID.ToString();
            nombreGrupoBox.Text = grupo.Nombre;
            capacidadBox.Text = grupo.Capacidad.ToString();
            nombreMaestroBox.Text = grupo.Maestro.Nombre;
            nombreMaestroBox.IsReadOnly = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("Matricula", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Grado escolar", typeof(string));

            foreach(Alumno a in alumnos)
            {
                ParsedAlumno al = new ParsedAlumno();
                al.Nombre = a.Nombre;
                al.Matricula = a.ID;
                al.Grado = a.GradoAcademico;

                dt.Rows.Add(al.Matricula, al.Nombre, al.Grado);
            }
            
            alumnoDataGrid.ItemsSource = dt.AsDataView();
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarGrupoButton_Click(object sender, RoutedEventArgs e)
        {
            grupoActionsCanvas.Visibility = System.Windows.Visibility.Visible;
            gruposGroupBox.Visibility = System.Windows.Visibility.Hidden;
            idGrupoLabel.Visibility = System.Windows.Visibility.Hidden;
            idGrupoBox.Visibility = System.Windows.Visibility.Hidden;
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

    partial class ParsedAlumno
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }

        public ParsedAlumno()
        {
            
        }

        public ParsedAlumno creaAlumno(Alumno alumno)
        {
            ParsedAlumno al = new ParsedAlumno() { Matricula = alumno.ID,Nombre = alumno.Nombre,Grado = alumno.GradoAcademico};
            return al;
        }

    }
}

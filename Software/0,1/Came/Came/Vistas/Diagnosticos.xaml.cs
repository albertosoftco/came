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
using Came.Modelo;
using Came.Negocios.AdministracionDiagnosticos.Interface;
using System.Collections.ObjectModel;
using Came.Negocios.AdministracionDiagnosticos.Fachada;
using Came.Negocios.Excepciones;

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Diagnosticos.xaml
    /// </summary>
    public partial class Diagnosticos : Window
    {
        public ObservableCollection<Discapacidad> discapacidadesDiagnostico;
        public ObservableCollection<Factor> factoresDiscapacidad;
        private Acciones accion;
        public enum Acciones { Ver,Actualizar,Agregar,Eliminar}
        public Diagnostico diagnosticoActual;
        private IAdministracionDiagnosticos admDiagnosticos;
        public Discapacidad discapacidadActual;
        public Factor factorActual;

        /// <summary>
        /// 
        /// </summary>
        public Diagnosticos(int idDiagnostico, Acciones accion)
        {
            discapacidadActual = new Discapacidad();
            diagnosticoActual = new Diagnostico();
            factorActual = new Factor();
            this.accion = accion;
            discapacidadesDiagnostico = new ObservableCollection<Discapacidad>();
            factoresDiscapacidad = new ObservableCollection<Factor>();
            InitializeComponent();
            admDiagnosticos = new FachadaAdministracionDiagnosticos();
            if(accion == Acciones.Agregar)
            {
                MuestraDiagnosticoNuevo();
                
            }
            
                if(accion == Acciones.Ver)
                {
                    MuestraDiagnostico(idDiagnostico);
                }
                if(accion == Acciones.Actualizar)
                {
                    MuestraDiagnostico(idDiagnostico);
                }
                if(accion == Acciones.Eliminar)
                {
                    EliminaDiagnostico(idDiagnostico);
                }
            

        }


        /// <summary>
        /// elimina el diagnosticoActual 
        /// </summary>
        /// <param name="id"></param>
        private void EliminaDiagnostico(int id)
        {
            
        }

        /// <summary>
        /// muestra un diagnosticoActual
        /// </summary>
        /// <param name="id"></param>
        private void MuestraDiagnostico(int id)
        {
            
        }

        /// <summary>
        /// muestra un diagnosticoActual nuevo 
        /// </summary>
        private void MuestraDiagnosticoNuevo()
        {
            
            discapacidadesGroupBox.IsEnabled = false;
            

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearDiagnosticoButton_Click(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificarDiagnosticoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// cada vez que el contenido del campo cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            diagnosticoActual.Nombre = nombreBox.Text;
        }

        /// <summary>
        /// cada vez que el contenido del campo cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descripcionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            diagnosticoActual.Descripcion = descripcionBox.Text;
        }


        /// <summary>
        /// crea el diagnosticoActual en la ventana 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearDiscapacidadButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(diagnosticoActual.Nombre))
            {
                MessageBox.Show("El diagnosticoActual esta vacio","Error");
                return;
            }
            discapacidadesGroupBox.IsEnabled = true;
            factoresGroupBox.IsEnabled = false;
            
            diagnosticoGrupoBox.IsEnabled = false;

        }


        /// <summary>
        /// si cambia el contenido del componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreDiscapacidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            discapacidadActual.Nombre = nombreDiscapacidadTextBox.Text;

        }


        /// <summary>
        /// si cambia el contenido del componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descripcionDiscapacidadtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            discapacidadActual.Descripcion = descripcionDiscapacidadtBox.Text;
        }


        /// <summary>
        /// si se quiere guardar la discapacidad creada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (accion == Acciones.Agregar)
            {
                discapacidadesDiagnostico = new ObservableCollection<Discapacidad>();
                if (string.IsNullOrEmpty(discapacidadActual.Nombre) && string.IsNullOrEmpty(discapacidadActual.Descripcion))
                {
                    MessageBox.Show("La discapacidad esta vacia", "Error");
                    return;
                }
                try
                {
                    discapacidadesDiagnostico.Add(discapacidadActual);
                    discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;
                    //agrega la discapacidad
                    discapacidadesListBox.SelectedItem = discapacidadActual;
                    nombreDiscapacidadTextBox.IsEnabled = false;
                    descripcionDiscapacidadtBox.IsEnabled = false;
                    discapacidadesListBox.IsEnabled = false;
                    button4.IsEnabled = false;
                    button3.IsEnabled = false;
                    button1.IsEnabled = false;

                    factoresGroupBox.IsEnabled = true;
                    

                }
                catch (AdministracionDiagnosticosException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }
            }


        }


        /// <summary>
        /// si la seleccion de la lista cambia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void discapacidadesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dis = discapacidadesListBox.SelectedItem as Discapacidad;
            if (dis == null)
            {
                factoresGroupBox.IsEnabled = false;
                return;
            }
            factoresGroupBox.IsEnabled = true;


        }


        /// <summary>
        /// si el contendido del contenido cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreFactorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            factorActual.Nombre = nombreFactorBox.Text;
        }

        


        /// <summary>
        /// se se pula el boton crear factor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearFactorButton_Click(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(factorActual.Nombre))
            {
                MessageBox.Show("El factor esta vacio", "Error");
                return;
            }

            try
            {
                factoresDiscapacidad.Add(factorActual);
                FactorListBox.ItemsSource = factoresDiscapacidad;
                FactorListBox.SelectedItem = factorActual;
            }
            catch(AdministracionDiagnosticosException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }



    }
}

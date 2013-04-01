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

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Grupos.xaml
    /// </summary>
    public partial class Grupos : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public Grupos()
        {
            InitializeComponent();
        }

        #region Adm Grupos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verGrupoButton_Click(object sender, RoutedEventArgs e)
        {
            grupoActionsCanvas.Visibility = System.Windows.Visibility.Visible;
            gruposGroupBox.Visibility = System.Windows.Visibility.Hidden;
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

       
    }
}

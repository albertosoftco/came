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

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Alumnos.xaml
    /// </summary>
    public partial class Alumnos : Window
    {
		
		public enum Acciones {Ver, Agregar, Actualizar, Eliminar}
		
        /// <summary>
        /// 
        /// </summary>
        public Alumnos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

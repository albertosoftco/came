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
    /// Lógica de interacción para Diagnosticos.xaml
    /// </summary>
    public partial class Diagnosticos : Window
    {
        public enum Acciones { Ver,Actualizar,Agregar,Eliminar}


        public Diagnosticos()
        {
            InitializeComponent();
        }

        private void crearDiagnosticoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void modificarDiagnosticoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

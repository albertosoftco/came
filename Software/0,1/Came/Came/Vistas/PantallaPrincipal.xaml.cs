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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Came.Modelo.Interface;
using Came.Modelo.Fachada;
using Came.Modelo;
using Came.Negocios.InicioSesion.Interface;
using Came.Negocios.InicioSesion.Fachada;
using Came.Negocios.Excepciones;

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal : Window
    {
        private ILogin login;
        private IModelo modelo;
        private int usuarioActual;
        /// <summary>
        /// 
        /// </summary>
        public PantallaPrincipal()
        {
           InitializeComponent();
           modelo = FachadaModelo.GetInstance();
           login = new FachadaInicioSesion(modelo);
           usuarioActual = 0;
        }

        #region login Canvas

        private void pwdRecButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("", "", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(usuarioBox.Text) || String.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Debe Ingresar \nUsuario y Contraseña","Sin especificar Usuario",MessageBoxButton.OK,MessageBoxImage.Exclamation,MessageBoxResult.OK,MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                //crea el usuario en el inicio de sesion
                Usuario usuario = new Usuario();
                usuario.UserName = usuarioBox.Text;
                usuario.Contrasenha = passwordBox.Password;
                bool sesion = false;
                try
                {
                     sesion = login.IniciarSesion(usuario); 
                    if (sesion)
                {
                    StringBuilder resource = new StringBuilder("login");
                    resource.Append(login.GetPermisoActual());

                    StringBuilder builder = new StringBuilder("Bienvenido ");
                        builder.Append(usuario.UserName);
                        builder.Append(" !!");
                    MessageBox.Show(builder.ToString(),"Bienvendo", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                    Storyboard sb = (Storyboard)TryFindResource(resource.ToString());
                    sb.Begin();
                    passwordBox.Password = "";
                    usuarioBox.Text = "";
                    

                    
                    

                    
                }
                }
                catch(LoginException)
                {
                    MessageBox.Show("Usuario o contraseña Incorrecta", null,
                            MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                        usuarioBox.Text = "";
                        passwordBox.Password = "";
                }
                

            }
        }

        private void shutdownButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("", "", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        #endregion loginCanvas

        #region menu Canvas

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder resource = new StringBuilder("logout");
            resource.Append(login.GetPermisoActual());
            Storyboard sb = (Storyboard)TryFindResource(resource.ToString());
            if (MessageBox.Show("Desea terminar su sesion?", null, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.Yes)
            {
                login.CierraSesion();
                sb.Begin();
            }
        }

        private void alumnosButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumnos alumnos = new Alumnos();
                alumnos.ShowDialog();
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("Pantalla no disponible");
            }
        }

        private void diganosticosButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void rutinasButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rutinas rutinas = new Rutinas(1,Rutinas.Acciones.Agregar);
                rutinas.Show();
            }
            catch(NotImplementedException)
            {
                MessageBox.Show("Pantalla no disponible");
            }
        }

        private void gruposButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void maestrosButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void documentosButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usuariosButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void productosButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion menu Canvas

    }
}

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
using Came.Modelo.Interface;

namespace Came.Vistas
{
    /// <summary>
    /// Lógica de interacción para Diagnosticos.xaml
    /// </summary>
    public partial class Diagnosticos : Window
    {
        public ObservableCollection<Discapacidad> tDiscapacidades;
        public ObservableCollection<Factor> tFactores;
        public ObservableCollection<Discapacidad> discapacidadesDiagnostico;
        public ObservableCollection<Factor> factoresDiscapacidad;
        private Acciones accion;
        public enum Acciones { Ver, Actualizar, Agregar, Eliminar }
        public Diagnostico diagnosticoActual;
        private IAdministracionDiagnosticos admDiagnosticos;
        public Discapacidad discapacidadActual;
        public Factor factorActual;

        /// <summary>
        /// 
        /// </summary>
        public Diagnosticos(int idDiagnostico, IModelo modelo, Acciones accion)
        {
            InitializeComponent();
            discapacidadActual = new Discapacidad();
            diagnosticoActual = new Diagnostico();
            factorActual = new Factor();
            this.accion = accion;
            discapacidadesDiagnostico = new ObservableCollection<Discapacidad>();
            factoresDiscapacidad = new ObservableCollection<Factor>();
            admDiagnosticos = new FachadaAdministracionDiagnosticos(modelo);
            tFactores = new ObservableCollection<Factor>(admDiagnosticos.GetFactores());
            tDiscapacidades = new ObservableCollection<Discapacidad>(admDiagnosticos.GetDiscapacidades());
            ActualizaFactoresDiscapacidades();
            if (accion == Acciones.Agregar)
            {
                MuestraDiagnosticoNuevo();
                ShowDialog();

            }

            if (accion == Acciones.Ver)
            {
                MuestraDiagnostico(idDiagnostico);
                ShowDialog();
            }
            if (accion == Acciones.Actualizar)
            {

                listBox1.ItemsSource = tDiscapacidades;
                factores.ItemsSource = tFactores;
                MuestraDiagnostico(idDiagnostico);
                ShowDialog();
            }
            if (accion == Acciones.Eliminar)
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
            if (MessageBox.Show("¿Seguro que desea borrar el diagnostico?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //elimina el diagnostico
                admDiagnosticos.EliminaDiagnostico(id);
                MessageBox.Show("Diagnostico Eliminado", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();

            }
        }

        /// <summary>
        /// muestra un diagnosticoActual
        /// </summary>
        /// <param name="id"></param>
        private void MuestraDiagnostico(int id)
        {
            if (accion == Acciones.Ver)
            {
                //verifica el id 
                if (admDiagnosticos.GetDiagnostico(id) == null)
                {
                    MessageBox.Show("El diagnostico no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

                else
                {
                    //muestra la discapacidad
                    diagnosticoActual = admDiagnosticos.GetDiagnostico(id);
                    //muestra la informacion de el diagnostico
                    nombreBox.Text = diagnosticoActual.Nombre;
                    descripcionBox.Text = diagnosticoActual.Nombre;
                    diagnosticoGrupoBox.IsEnabled = false;
                    //muestra las discapacidades del diagnostico
                    discapacidadesDiagnostico = new ObservableCollection<Discapacidad>(admDiagnosticos.GetDiscapacidadesDiagnostico(id));
                    if (discapacidadesDiagnostico.Count == 0)
                    {
                        MessageBox.Show("El diagnostico no tiene discapacidades", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        discapacidadesGroupBox.IsEnabled = false;
                        factoresGroupBox.IsEnabled = false;
                        crearDiagnosticoButton.IsEnabled = false;
                        return;
                    }
                    discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;
                    //muestra todas las discapacidades 
                    tDiscapacidades = new ObservableCollection<Discapacidad>(admDiagnosticos.GetDiscapacidades());
                    listBox1.ItemsSource = tDiscapacidades;
                    //deshabilita los campos de la discapacidad dejando solo la lista de discapacidades activa
                    nombreDiscapacidadTextBox.IsEnabled = false;
                    descripcionDiscapacidadtBox.IsEnabled = false;
                    button7.IsEnabled = false;
                    button8.IsEnabled = false;
                    button4.IsEnabled = false;
                    button3.IsEnabled = false;
                    crearDiscapacidadButton.IsEnabled = false;
                    listBox1.IsEnabled = false;
                    factoresGroupBox.IsEnabled = false;
                    crearDiagnosticoButton.IsEnabled = false;


                }
            }
            if (accion == Acciones.Actualizar)
            {
                //muestra la informacion del diagnostico editable
                diagnosticoActual = admDiagnosticos.GetDiagnostico(id);
                if (diagnosticoActual == null)
                {
                    MessageBox.Show("El diagnostico no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }
                else
                {
                    nombreBox.Text = diagnosticoActual.Nombre;
                    descripcionBox.Text = diagnosticoActual.Descripcion;
                    //carga las discapacidades del diagnostico 
                    discapacidadesDiagnostico = new ObservableCollection<Discapacidad>(admDiagnosticos.GetDiscapacidadesDiagnostico(diagnosticoActual.ID));
                    discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;
                    //todas las discapacidades para la interaccion
                    listBox1.ItemsSource = tDiscapacidades;

                }
            }
        }

        /// <summary>
        /// muestra un diagnosticoActual nuevo 
        /// </summary>
        private void MuestraDiagnosticoNuevo()
        {

            discapacidadesGroupBox.IsEnabled = false;
            factoresGroupBox.IsEnabled = false;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearDiagnosticoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (accion == Acciones.Agregar)
                {
                    //crea el diagnostico nuevo en la bd 
                    admDiagnosticos.AgregaDiagnostico(diagnosticoActual);
                    diagnosticoActual = admDiagnosticos.GetDiagnostico(diagnosticoActual.Nombre);
                    //agrega cada una de las discapacidades en la lista con su relacion
                    foreach (Discapacidad d in discapacidadesDiagnostico)
                    {
                        
                        var actual = admDiagnosticos.GetDiscapacidad(d.Nombre);
                        //agrega la relaciom
                        
                        admDiagnosticos.AgregaRelacionDiagnosticoDiscapacidad(diagnosticoActual.ID, actual.ID);
                    }
                    //desicion para agregar otro diagnostico
                    if (MessageBox.Show("¿Desea agregar otra discapacidad?", "Agregar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        //limpia todos los atributos de la interfas grafica 
                        discapacidadesDiagnostico = new ObservableCollection<Discapacidad>();
                        factoresDiscapacidad = new ObservableCollection<Factor>();
                        discapacidadesGroupBox.IsEnabled = false;
                        discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;
                        FactorListBox.ItemsSource = factoresDiscapacidad;
                        diagnosticoGrupoBox.IsEnabled = true;
                        discapacidadesDiagnostico = new ObservableCollection<Discapacidad>();
                        discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;

                        factoresDiscapacidad = new ObservableCollection<Factor>();
                        FactorListBox.ItemsSource = factoresDiscapacidad;

                    }
                    else
                    {
                        this.Close();
                    }

                }
                if (accion == Acciones.Actualizar)
                {
                    //Actualiza el diagnostico
                    foreach (Factor f in factoresDiscapacidad)
                    {
                        if (admDiagnosticos.GetFactor(f.Nombre) == null)
                        {
                            MessageBox.Show("No se han guardado todos los factores", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }

                    }
                    foreach (Discapacidad d in discapacidadesDiagnostico)
                    {
                        if (admDiagnosticos.GetDiscapacidad(d.Nombre) == null)
                        {
                            MessageBox.Show("No se han guardado todos los diagnosticos", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }

                    }
                    foreach (Discapacidad d in discapacidadesDiagnostico)
                    {
                        if (admDiagnosticos.GetRelacionesDiagnosticoDiscapacidad().Where(i => i.IdDiagnostico.Equals(diagnosticoActual.ID)
                            && i.IdDiscapacidad.Equals(d.ID)).SingleOrDefault() != null)
                        {
                            continue;
                        }
                        diagnosticoActual.Diagnostico_Discapacidad.Add(new Diagnostico_Discapacidad { IdDiagnostico = diagnosticoActual.ID, IdDiscapacidad = d.ID });
                    }
                    admDiagnosticos.ActualizaDiagnostico(diagnosticoActual);
                }


            }
            catch (AdministracionDiagnosticosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
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

            switch (accion)
            {
                //si se va a ver un diagnostico
                case Acciones.Ver:
                    return;

                // si se desea agregar un diagnostico
                case Acciones.Agregar:
                    try
                    {
                        if (admDiagnosticos.GetDiagnostico(nombreBox.Text) != null)
                        {
                            MessageBox.Show("Ya existe un diagnostico con ese nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return;
                        }
                        if (string.IsNullOrEmpty(nombreBox.Text))
                            return;
                        diagnosticoActual.Nombre = nombreBox.Text;

                    }
                    catch (AdministracionDiagnosticosException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    break;
                //si se desea actualizar un diagnostico
                case Acciones.Actualizar:

                    break;
                //si se desea eliminar un diagnostico
                case Acciones.Eliminar:

                    break;
            }
        }

        /// <summary>
        /// cada vez que el contenido del campo cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descripcionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (accion)
            {
                //si se desea ver
                case Acciones.Ver:
                    return;
                //si se desea agregar un diagnostico
                case Acciones.Agregar:
                    diagnosticoActual.Descripcion = descripcionBox.Text;
                    break;
                //si se desea actualizar el diagnostico
                case Acciones.Actualizar:
                    break;
                //si se desea eliminar el diagnostico
                case Acciones.Eliminar:
                    break;
            }
        }


        /// <summary>
        /// crea el diagnosticoActual en la ventana 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearDiscapacidadButton_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                //si se desea ver
                case Acciones.Ver:
                    return;


                //si se desea agregar un diagnostico
                case Acciones.Agregar:
                    if (string.IsNullOrEmpty(diagnosticoActual.Nombre) && string.IsNullOrEmpty(diagnosticoActual.Descripcion))
                    {
                        MessageBox.Show("El diagnostico esta vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    discapacidadesGroupBox.IsEnabled = true;
                    factoresGroupBox.IsEnabled = false;
                    diagnosticoGrupoBox.IsEnabled = false;
                    break;

                //si se desea actualizar el diagnostico
                case Acciones.Actualizar:
                    break;
                //si se desea eliminar el diagnostico
                case Acciones.Eliminar:
                    break;
            }


        }


        /// <summary>
        /// si cambia el contenido del componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreDiscapacidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (accion)
            {
                //si se desea ver
                case Acciones.Ver:
                    return;

                //si se desea agregar un diagnostico
                case Acciones.Agregar:
                    if (admDiagnosticos.GetDiscapacidad(nombreDiscapacidadTextBox.Text) != null)
                    {
                        MessageBox.Show("Ya existe una discapacidad con este nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    if (string.IsNullOrEmpty(nombreDiscapacidadTextBox.Text))
                        return;
                    discapacidadActual.Nombre = nombreDiscapacidadTextBox.Text;
                    break;

                //si se desea actualizar el diagnostico
                case Acciones.Actualizar:
                    if (admDiagnosticos.GetDiscapacidad(nombreDiscapacidadTextBox.Text) != null)
                    {
                        MessageBox.Show("Ya existe una discapacidad con este nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    discapacidadActual.Nombre = nombreDiscapacidadTextBox.Text;
                    break;

                //si se desea eliminar el diagnostico
                case Acciones.Eliminar:
                    break;
            }

        }


        /// <summary>
        /// si cambia el contenido del componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descripcionDiscapacidadtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (accion)
            {
                //si se desea ver
                case Acciones.Ver:
                    return;

                //si se desea agregar un diagnostico
                case Acciones.Agregar:
                    if (string.IsNullOrEmpty(descripcionDiscapacidadtBox.Text))
                        return;

                    discapacidadActual.Descripcion = descripcionDiscapacidadtBox.Text;
                    break;

                //si se desea actualizar el diagnostico
                case Acciones.Actualizar:
                    if (string.IsNullOrEmpty(descripcionDiscapacidadtBox.Text))
                        return;
                    discapacidadActual.Descripcion = descripcionDiscapacidadtBox.Text;
                    break;

                //si se desea eliminar el diagnostico
                case Acciones.Eliminar:
                    break;
            }
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
                if (string.IsNullOrEmpty(discapacidadActual.Nombre) && string.IsNullOrEmpty(discapacidadActual.Descripcion))
                {
                    MessageBox.Show("La discapacidad esta vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                    button1.IsEnabled = false;

                    factoresGroupBox.IsEnabled = true;
                    factoresDiscapacidad = new ObservableCollection<Factor>();
                    nombreFactorBox.IsEnabled = false;
                    factores.ItemsSource = tFactores;

                }
                catch (AdministracionDiagnosticosException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
            }
            if (accion == Acciones.Actualizar)
            {
                factoresGroupBox.IsEnabled = true;
                discapacidadesGroupBox.IsEnabled = false;

            }


        }


        /// <summary>
        /// si la seleccion de la lista cambia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void discapacidadesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (accion)
            {
                //si se desea ver 
                case Acciones.Ver:
                    //toma la lista de factoresD de la discapacidad seleccionada
                    var dis = discapacidadesListBox.SelectedItem as Discapacidad;

                    if (dis == null)
                    {
                        return;
                    }
                    else
                    {
                        discapacidadActual = discapacidadesListBox.SelectedItem as Discapacidad;
                        var factoresD = admDiagnosticos.GetFactoresDiscapacidad(dis.ID);
                        if (factoresD.Count() == 0)
                        {
                            factoresGroupBox.IsEnabled = false;
                            MessageBox.Show("La discapacidad no contiene factores", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                        else
                        {
                            //muestra los factoresD de la discapacidad 
                            factoresDiscapacidad = new ObservableCollection<Factor>(factoresD);
                            FactorListBox.ItemsSource = factoresDiscapacidad;
                            factores.ItemsSource = factoresDiscapacidad;
                            factores.IsEnabled = false;
                            button5.IsEnabled = false;
                            crearFactorButton.IsEnabled = false;
                            button6.IsEnabled = false;
                            nombreFactorBox.IsEnabled = false;
                            button2.IsEnabled = false;
                            crearDiagnosticoButton.IsEnabled = false;


                        }

                    }
                    break;

                //si se desea agregar
                case Acciones.Agregar:
                    var disc = discapacidadesListBox.SelectedItem as Discapacidad;
                    if (disc == null)
                    {
                        return;
                    }
                    disc = admDiagnosticos.GetDiscapacidad(disc.Nombre);
                    if (disc != null)
                    {
                        factoresGroupBox.IsEnabled = true;
                        //obtiene los factoresD de la discapacidad 
                        factoresDiscapacidad = new ObservableCollection<Factor>(admDiagnosticos.GetFactoresDiscapacidad(disc.ID));
                        FactorListBox.ItemsSource = factoresDiscapacidad;
                    }
                    else
                    {
                        factoresGroupBox.IsEnabled = true;
                        factoresDiscapacidad = new ObservableCollection<Factor>();
                        FactorListBox.ItemsSource = factoresDiscapacidad;
                    }
                    break;

                //si se desea actualizar
                case Acciones.Actualizar:
                    //carga los factores de la discapacidad y espera a que se presione el boton 'continuar'

                    factoresDiscapacidad = new ObservableCollection<Factor>(admDiagnosticos.GetFactoresDiscapacidad(discapacidadActual.ID));
                    if (factoresDiscapacidad.Count == 0)
                    {
                        //habilita la lista para agregar factores a la nueva discapacidad
                        factoresDiscapacidad = new ObservableCollection<Factor>();
                        FactorListBox.ItemsSource = factoresDiscapacidad;
                        factoresGroupBox.IsEnabled = true;

                        return;
                    }
                    FactorListBox.ItemsSource = factoresDiscapacidad;
                    factores.ItemsSource = tFactores;


                    break;
                //si se desea eliminar
                case Acciones.Eliminar:
                    break;

            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void ActualizaFactoresDiscapacidades()
        {
            tFactores = new ObservableCollection<Factor>(admDiagnosticos.GetFactores());
            tDiscapacidades = new ObservableCollection<Discapacidad>(admDiagnosticos.GetDiscapacidades());
            listBox1.ItemsSource = tDiscapacidades;
            factores.ItemsSource = tFactores;
        }

        /// <summary>
        /// si el contendido del campo cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nombreFactorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (accion)
            {

                case Acciones.Ver:
                    break;

                case Acciones.Agregar:
                    try
                    {
                        factorActual.Nombre = nombreFactorBox.Text;
                        //si el factor ya existe en la BD 
                        if (admDiagnosticos.GetFactor(factorActual.Nombre) != null)
                        {
                            MessageBox.Show("Ya existe un factor con ese nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return;
                        }
                        // si el factor ya existe en la tabla de factoresD
                        if (factoresDiscapacidad.Where(i => i.Nombre.Equals(factorActual.Nombre)).SingleOrDefault() != null)
                        {
                            MessageBox.Show("El factor ya existe en la discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                    }
                    catch (AdministracionDiagnosticosException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    break;

                case Acciones.Actualizar:
                    try
                    {
                        factorActual.Nombre = nombreFactorBox.Text;
                        //si el factor ya existe en la BD 
                        if (admDiagnosticos.GetFactor(factorActual.Nombre) != null)
                        {
                            MessageBox.Show("Ya existe un factor con ese nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            return;
                        }
                        // si el factor ya existe en la tabla de factoresD
                        if (factoresDiscapacidad.Where(i => i.Nombre.Equals(factorActual.Nombre)).SingleOrDefault() != null)
                        {
                            MessageBox.Show("El factor ya existe en la discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                    }
                    catch (AdministracionDiagnosticosException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                    break;

                case Acciones.Eliminar:
                    //confirma la eliminacion

                    break;
            }
        }




        /// <summary>
        /// si se pulsa el boton crear factor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crearFactorButton_Click(object sender, RoutedEventArgs e)
        {
            if (FactorListBox.SelectedItem == null)
            {
                MessageBox.Show("No se ha seleccionado ningun factor", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            factoresDiscapacidad = FactorListBox.ItemsSource as ObservableCollection<Factor>;
            factoresDiscapacidad.Remove(FactorListBox.SelectedItem as Factor);
            FactorListBox.ItemsSource = factoresDiscapacidad;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            switch (accion)
            {
                case Acciones.Ver:

                    break;

                case Acciones.Agregar:
                    //agrega el factor seleccionado a la lista de factoresD de la discapacidad 
                    if (factores.SelectedItem == null)
                    {
                        MessageBox.Show("No se ha seleccionado ningun factor", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    //si el factor ya existe en la lista de factoresD

                    else
                    {
                        //checa si el factor existe ya en la lista 
                        var f = factores.SelectedItem as Factor;
                        if (factoresDiscapacidad.Where(i => i.Nombre.Equals(f.Nombre)).SingleOrDefault() != null)
                        {
                            MessageBox.Show("No se pueden duplicar factoresD en una misma discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                        if (f != null)
                        {
                            factoresDiscapacidad.Add(f);
                            FactorListBox.ItemsSource = factoresDiscapacidad;
                        }
                        else
                        {
                            MessageBox.Show("No se pueden duplicar factoresD en una misma discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                    }

                    break;

                case Acciones.Actualizar:
                    var ff = factores.SelectedItem as Factor;

                    if (ff == null)
                    {
                        MessageBox.Show("No se ha seleccionado ningun factor", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    else
                    {

                        if (factoresDiscapacidad.Where(i => i.Nombre.Equals(ff.Nombre)).SingleOrDefault() != null)
                        {
                            MessageBox.Show("No se pueden repetir factores", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                        else
                        {
                            factoresDiscapacidad.Add(ff);
                            FactorListBox.ItemsSource = factoresDiscapacidad;
                        }
                    }
                    break;

                case Acciones.Eliminar:

                    break;
            }
        }

        private void VerDiagnostico(int idDiagnostico)
        {
            diagnosticoActual = new Diagnostico { };
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // se guardan los factoresD dentro de la discapacidad actual junto con sus relaciones 
            switch (accion)
            {
                case Acciones.Ver:

                    break;

                case Acciones.Agregar:

                    try
                    {
                        //agrega la discapacidad
                        admDiagnosticos.AgregaDiscapacidad(discapacidadActual);
                        discapacidadActual = admDiagnosticos.GetDiscapacidad(discapacidadActual.Nombre);
                        foreach (Factor f in factoresDiscapacidad)
                        {
                            //agrega el factor y su relacion
                            //si el factor que se agrego proviene de la lista de factoresD
                            if (admDiagnosticos.GetFactor(f.Nombre) != null)
                            {
                                //solo agrega la relacion y continua con el siguiente factor
                                //si ya la tiene
                                var fac = admDiagnosticos.GetFactor(f.Nombre);
                                if (fac.Discapacidad_Factor.Where(i=>i.IdDiscapacidad.Equals(discapacidadActual.ID)).SingleOrDefault()!=null)
                                {
                                    
                                    continue;
                                }
                                else
                                {
                                    admDiagnosticos.AgregaRelacionDiscapacidadFactor(discapacidadActual.ID, f.ID); 
                                    continue;
                                }
                            }
                            admDiagnosticos.AgregaFactor(f);
                            Factor nvo = admDiagnosticos.GetFactor(f.Nombre);
                            admDiagnosticos.AgregaRelacionDiscapacidadFactor(discapacidadActual.ID, nvo.ID);
                        }
                        MessageBox.Show("Se guardo la discapacidad", "Agregado", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        //regresa a la seccion de discapacidades
                        ActualizaFactoresDiscapacidades();
                        discapacidadesGroupBox.IsEnabled = true;
                        nombreDiscapacidadTextBox.IsEnabled = true;
                        descripcionDiscapacidadtBox.IsEnabled = true;
                        discapacidadesListBox.IsEnabled = true;
                        button4.IsEnabled = true;
                        button3.IsEnabled = true;
                        button1.IsEnabled = true;
                        factoresGroupBox.IsEnabled = false;
                        nombreDiscapacidadTextBox.Text = "";
                        descripcionDiscapacidadtBox.Text = "";
                        factoresDiscapacidad = new ObservableCollection<Factor>();
                        FactorListBox.ItemsSource = factoresDiscapacidad;
                        break;

                    }
                    catch (AdministracionDiagnosticosException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                case Acciones.Actualizar:
                    var discapacidad = discapacidadesListBox.SelectedItem as Discapacidad;
                    if (admDiagnosticos.GetDiscapacidad(discapacidad.Nombre) == null)
                    {
                        //se agrega
                        admDiagnosticos.AgregaDiscapacidad(discapacidad);
                        //se actualiza para usar el ID 
                        discapacidadActual = admDiagnosticos.GetDiscapacidad(discapacidad.Nombre);
                    }


                    //si la discapacidad es nueva
                    if (discapacidad == null)
                    {
                        MessageBox.Show("No se ha seleccionado ninguna discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }
                    //se toman los factores a agregar 
                    factoresDiscapacidad = FactorListBox.ItemsSource as ObservableCollection<Factor>;
                    if (factoresDiscapacidad.Count > 0)
                    {
                        foreach (Factor f in factoresDiscapacidad)
                        {
                            //si ya existe
                            if (admDiagnosticos.GetFactor(f.Nombre) != null)
                            {
                                //se checa si tiene relacion con el diagnostico
                                var factor = admDiagnosticos.GetFactor(f.Nombre);
                                var relaciones = admDiagnosticos.GetRelacionesDiscapacidadFactor().Where(i => i.IdDiscapacidad.Equals(discapacidad.ID) && i.IdFactor.Equals(factor.ID));
                                if (relaciones.Count() > 0)
                                {
                                    continue;
                                }
                                //si ni la tiene se agrega
                                else
                                {
                                    admDiagnosticos.AgregaRelacionDiscapacidadFactor(discapacidad.ID, admDiagnosticos.GetFactor(f.Nombre).ID);
                                }
                            }
                            //si no existe el factor
                            else
                            {
                                //se agrega junto con su relacion
                                admDiagnosticos.AgregaFactor(f);
                                var factor = admDiagnosticos.GetFactor(f.Nombre);
                                admDiagnosticos.AgregaRelacionDiscapacidadFactor(discapacidadActual.ID, f.ID);
                            }
                        }
                    }



                    break;
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            nombreFactorBox.IsEnabled = true;
        }

        private void nombreFactorBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (string.IsNullOrEmpty(nombreFactorBox.Text))
                {
                    MessageBox.Show("El factor esta vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    return;
                }
                factoresDiscapacidad.Add(new Factor { Nombre = nombreFactorBox.Text });
                FactorListBox.ItemsSource = factoresDiscapacidad;
                nombreFactorBox.Text = "";
            }
        }

        private void volverButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Volver", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();



        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            factoresGroupBox.IsEnabled = false;
            discapacidadesGroupBox.IsEnabled = true;
            discapacidadesListBox.SelectedItem = null;
        }

        private void descripcionDiscapacidadtBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            //agrega la nueva discapacidad a la lista
            var discapacidad = new Discapacidad { Nombre = nombreDiscapacidadTextBox.Text, Descripcion = descripcionDiscapacidadtBox.Text };
            if (admDiagnosticos.GetDiscapacidad(discapacidad.ID) != null)
            {
                MessageBox.Show("Ya existe una discapacidad con ese nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            if (discapacidadesDiagnostico.Where(i => i.Nombre.Equals(nombreDiscapacidadTextBox.Text)).SingleOrDefault() != null)
            {
                MessageBox.Show("Un diagnostico no puede tener dos discapacidades iguales", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            discapacidadesDiagnostico.Add(new Discapacidad { Nombre = nombreDiscapacidadTextBox.Text, Descripcion = descripcionDiscapacidadtBox.Text });
            discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;
            nombreDiscapacidadTextBox.Text = "";
            descripcionDiscapacidadtBox.Text = "";
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            var dis = listBox1.SelectedItem as Discapacidad;
            if (dis == null)
            {
                MessageBox.Show("No se ha seleccionado ninguna discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            if (discapacidadesDiagnostico.Where(i => i.Nombre.Equals(dis.Nombre)).SingleOrDefault() != null)
            {
                MessageBox.Show("No se pueden repetir las discapacidades", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }

            else
            {
                discapacidadesDiagnostico.Add(dis);
                discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            var dis = discapacidadesListBox.SelectedItem as Discapacidad;
            if (dis == null)
            {
                MessageBox.Show("No se ha seleccionado ninguna discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            else
            {
                discapacidadActual = dis;
                discapacidadesDiagnostico.Remove(dis);
                discapacidadesListBox.ItemsSource = discapacidadesDiagnostico;
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (MessageBox.Show("¿Seguro que desea eliminar la discapacidad?", "Eliminar Discapacidad", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    //obtiene la lista de discapacidades para borrarla
                    try
                    {
                        var d = listBox1.SelectedItem as Discapacidad;
                        discapacidadesDiagnostico.Remove(d);
                        admDiagnosticos.EliminaDiscapacidad(d.ID);
                        //actualiza la lista de discapacidades 
                        listBox1.ItemsSource = tDiscapacidades;
                        ActualizaFactoresDiscapacidades();

                    }
                    catch (AdministracionDiagnosticosException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna discapacidad", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }


        /// <summary>
        /// obtiene el diagnostico creado 
        /// </summary>
        /// <returns></returns>
        public Diagnostico GetDiagnosticoCreado()
        {
            return diagnosticoActual;    
        }
        
        
        
    }
}

using ConvertidoresFormato.Code;

namespace ConvertidoresFormato
{
    public partial class FormatSwitcher : Form
    {
        public string rutaArchivoSeleccionado = "";
        public string rutaArchivoDestino = "";
        public string contenidoArchivo = "";

        public FormatSwitcher()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento click seleccionar archivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            rutaArchivoSeleccionado = Funcionalidades.SeleccionarArchivo();
            txtArchivoSeleccionado.Text = rutaArchivoSeleccionado;

        }

        /// <summary>
        /// Evento click seleccionar ruta de destino archivo. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            rutaArchivoDestino = Funcionalidades.SeleccionarCarpeta();
            txtRutaDestino.Text = rutaArchivoDestino;
        }

        /// <summary>
        /// Evento click boton convertir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones 
                if (rutaArchivoSeleccionado.Length == 0)
                {
                    MessageBox.Show("Seleccione un archivo para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (rutaArchivoDestino.Length == 0)
                {
                    MessageBox.Show("Seleccione una ruta de destino para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtNombreArchivo.Text.Length == 0)
                {
                    MessageBox.Show("Escriba el nombre de archivo nuevo para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (cmbSelecconArchivo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un formato de salida para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string formatoArchivoEntrada = Funcionalidades.ObtenerExtension(rutaArchivoSeleccionado);

                int FormatoIndiceSeleccionado = cmbSelecconArchivo.SelectedIndex;

                Formato_ formatoArchivoSalida = Formato.GetFormatoPorIndice(FormatoIndiceSeleccionado);

                //Validaciones forzada
                if (txtForzarSeparadorEntrada.Text.Length > 0 && formatoArchivoEntrada.Replace(".","") != "csv")
                {
                    MessageBox.Show("El caracter separador forzado es valido unicamente en archivos csv. (En archivo a transformar)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (formatoArchivoSalida != Formato_.CSV && txtForzarSeparadorSalida.Text.Length > 0)
                {
                    MessageBox.Show("El caracter separador forzado es valido unicamente en archivos csv o tsv. (En archivo nuevo)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Formato_ formatoArchivoEntrada_ = Formato.GetFormato(formatoArchivoEntrada);

                bool exito = Conversor.ArmarArchivoSalida(rutaArchivoSeleccionado, rutaArchivoDestino, txtNombreArchivo.Text, formatoArchivoEntrada_, formatoArchivoSalida, txtForzarSeparadorEntrada.Text, txtForzarSeparadorSalida.Text);

                if (exito)
                {
                    MessageBox.Show("Conversion exitosa.", "Mnesaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else {
                    MessageBox.Show("No se escribieron filas. Intente nuevamente", "Mnesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        /// <summary>
        /// Evento click salir 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Publicidad
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.linkedin.com/in/nahuel-maquieyra-69b774253/",
                    UseShellExecute = true
                });
            }
            catch { }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/nahue-prg/FormatSwitcher",
                    UseShellExecute = true
                });
            }
            catch { }
        }
        #endregion

    }
}
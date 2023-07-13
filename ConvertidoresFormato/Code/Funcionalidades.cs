using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertidoresFormato.Code
{
    public class Funcionalidades
    {
        /// <summary>
        /// Selecciona un archivo con el explorador de archivos y retorna la ruta. 
        /// </summary>
        /// <returns>Ruta del archivo seleccionado</returns>
        public static string SeleccionarArchivo()
        {
            string rutaArchivo = "";

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Seleccionar archivo";
                openFileDialog.Filter = "Archivos validos (*.tsv;*.csv;*.json;*.xlsx)|*.tsv;*.csv;*.json;*.xlsx|Archivos TSV (*.tsv)|*.tsv|Archivos CSV (*.csv)|*.csv|Archivos JSON (*.json)|*.json|Archivos XLSX (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaArchivo = openFileDialog.FileName;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ocurrio un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                return rutaArchivo;
        }

        /// <summary>
        /// Seleccionar una carptea 
        /// </summary>
        /// <returns></returns>
        public static string SeleccionarCarpeta()
        {
            string rutaCarpeta = "";

            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Seleccionar carpeta";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaCarpeta = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return rutaCarpeta;
        }

        /// <summary>
        /// Lee un archivo por medio de su ruta.
        /// </summary>
        /// <returns>Contenido del archivo</returns>
        public static string LeerArchivo(string rutaArchivo)
        {

            string contenido = "";

            try
            {
                contenido = File.ReadAllText(rutaArchivo);
            }
            catch (Exception ex) { MessageBox.Show("Ocurrio un error inesperado: " + ex.Message); }

            return contenido;
        }

        /// <summary>
        /// Escribir un nuevo archivo
        /// </summary>
        /// <param name="contenido"></param>
        /// <param name="rutaArchivo"></param>
        public static void EscribirArchivo(string contenido, string rutaArchivo)
        {
            // Escribe el contenido en el archivo especificado
            File.WriteAllText(rutaArchivo, contenido);
        }

        /// <summary>
        /// Obtener la extension de un archivo
        /// </summary>
        /// <returns></returns>
        public static string ObtenerExtension(string rutaArchivo) {

            string fileExtension = Path.GetExtension(rutaArchivo);
            return fileExtension;
        }

    }
}

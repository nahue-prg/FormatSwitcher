using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ConvertidoresFormato
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbSelecconArchivo.SelectedValue = "JSON";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string archivoEnCsv = AbrirArchivo();

            List<Comercio> comercios = new List<Comercio>();

            List<string> listaCsv = archivoEnCsv.Split("\r\n").ToList();

            for (int i = 0; i < listaCsv.Count(); i++)
            {

                List<string> valoresDeFila = listaCsv[i].Split("\t").ToList();

                Comercio auxiliarComercio = new Comercio()
                {
                    Numero_de_registro = valoresDeFila[0],
                    Ubicacion  = valoresDeFila[1],
                    Contacto_principal  = valoresDeFila[2],
                    Fecha_de_Vencimiento   = valoresDeFila[3],
                    Estado   = valoresDeFila[4],
                    Usos   = valoresDeFila[5],
                    Tipo   = valoresDeFila[6],
                    Familia   = valoresDeFila[7],
                    Rubro_ordenanza_fiscal   = valoresDeFila[8],
                    Nombre_de_Fantasía   = valoresDeFila[9],
                    Facebook   = valoresDeFila[10],
                    Instagram   = valoresDeFila[11],
                    Rubro   = valoresDeFila[12],
                    Superficie_m2   = valoresDeFila[13],
                    Ubicacion_catastral   = valoresDeFila[14],
                    Cuenta_de_comercio   = valoresDeFila[15],
                    Fecha_de_censado   = valoresDeFila[16],
                    DNI_del_contacto_principal   = valoresDeFila[17],
                    EMail_Contacto_principal   = valoresDeFila[18],
                    Telefono_Contacto_principal   = valoresDeFila[19],
                    Latitud   = valoresDeFila[20],
                    Longitud   = valoresDeFila[21],
                    Sector =  valoresDeFila[22]
                };

                comercios.Add(auxiliarComercio);
            }

            string nombreArchivo = txtNombreArchivo.Text;

            string json = JsonSerializer.Serialize(comercios, new JsonSerializerOptions
            {
                WriteIndented = true // Opcional: Formatear el JSON con sangrías
            });

            EscribirArchivo(json, "C:\\Users\\juani\\OneDrive\\Escritorio\\excel\\" + nombreArchivo + ".json");
        }

        private string AbrirArchivo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar archivo";
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            string contenidoArchivo = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;

                // Leer el contenido del archivo y guardarlo en una variable string
                contenidoArchivo = File.ReadAllText(rutaArchivo);
            }

            return contenidoArchivo;
        }

        private void EscribirArchivo(string contenido, string rutaArchivo)
        {
            // Escribe el contenido en el archivo especificado
            File.WriteAllText(rutaArchivo, contenido);
        }

    }
}
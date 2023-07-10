using ConvertidoresFormato.Code;
using ConvertidoresFormato.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ConvertidoresFormato
{
    public partial class FormatSwitcher : Form
    {
        public string archivoSeleccionado = "";
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
            archivoSeleccionado = Funcionalidades.SeleccionarArchivo();
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

        private void button2_Click(object sender, EventArgs e)
        {
            string hola = "";
        }
    }
}
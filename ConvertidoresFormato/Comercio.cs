using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConvertidoresFormato
{
    /// <summary>
    /// Comercios habilitados
    /// </summary>
    public class Comercio
    {
        /// <summary>
        /// Numero de registro de comercio
        /// </summary>
        public string Numero_de_registro {get; set;}
        public string Ubicacion {get; set;}
        public string Contacto_principal {get; set;} 
        public string Fecha_de_Vencimiento {get; set;} 
        public string Estado {get; set;} 
        public string Usos {get; set;} 
        public string Tipo {get; set;} 
        public string Familia {get; set;} 
        public string Rubro_ordenanza_fiscal {get; set;} 
        public string Nombre_de_Fantasía {get; set;} 
        public string Facebook {get; set;} 
        public string Instagram {get; set;} 
        public string Rubro {get; set;} 
        public string Superficie_m2 {get; set;} 
        public string Ubicacion_catastral {get; set;}
        public string Cuenta_de_comercio {get; set;}
        public string Fecha_de_censado {get; set;}
        public string DNI_del_contacto_principal {get; set;} 
        public string EMail_Contacto_principal {get; set;}
        public string Telefono_Contacto_principal {get; set;}
        public string Latitud {get; set;}
        public string Longitud {get; set;}
        public string Sector { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConvertidoresFormato.Code
{
    public class Formato
    {

        public static string GetCaracterFormato(Formato_ formato)
        {
            switch (formato)
            {
                case Formato_.CSV:
                    return ",";
                case Formato_.JSON:
                    return "";
                case Formato_.JSONOPTIMIZADO:
                    return "";
                case Formato_.TSV:
                    return "\t";
                case Formato_.XLSX:
                    return ""; // No se aplica un carácter separador para XLSX
                default:
                    throw new ArgumentException("Formato no válido.");
            }
        }
    }

    /// <summary>
    /// Formatos 
    /// </summary>
    public enum Formato_
    {
        CSV = 0,
        JSON = 1,
        TSV = 2,
        XLSX = 3,
        JSONOPTIMIZADO = 4
    }
}

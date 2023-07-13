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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formato"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetCaracterFormato(Formato_ formato)
        {
            switch (formato)
            {
                case Formato_.CSV:
                    return ",";
                case Formato_.JSON:  // No se aplica un carácter separador
                    return "";
                case Formato_.JSONOPTIMIZADO:// No se aplica un carácter separador 
                    return "";
                case Formato_.TSV:
                    return "\t";
                case Formato_.XLSX:
                    return ""; // No se aplica un carácter separador
                default:
                    throw new ArgumentException("Formato no válido.");
            }
        }

        /// <summary>
        /// Devolver una string con la extension correspondiente al formato
        /// </summary>
        /// <param name="formato"></param>
        /// <returns></returns>
        public static string ToString(Formato_ formato)
        {
            switch (formato)
            {
                case Formato_.CSV:
                    return "csv";
                case Formato_.JSON:
                    return "json";
                case Formato_.JSONOPTIMIZADO:
                    return "json";
                case Formato_.TSV:
                    return "tsv";
                case Formato_.XLSX:
                    return "xlsx"; 
                default:
                    throw new ArgumentException("Formato no válido.");
            }
        }
        /// <summary>
        /// Devolver una string con la extension correspondiente al formato
        /// </summary>
        /// <param name="formato"></param>
        /// <returns></returns>
        public static Formato_ GetFormato(string formato)
        {
            switch (formato.Replace(".",""))
            {
                case "csv":
                    return Formato_.CSV;
                case "json":
                    return Formato_.JSON;
                case "tsv":
                    return Formato_.TSV;
                case "xlsx":
                    return Formato_.XLSX;
                default:
                    throw new ArgumentException("Formato no válido.");
            }
        }

        /// <summary>
        /// Analiza cual es el caracter separador que corresponde, util para csv donde se aplica una , o un ; o un tabulador y no se forzo a este caracter. 
        /// </summary>
        /// <param name="content">Contenido del archivo en una string</param>
        /// <returns></returns>
        public static string? GetCaracterSeparador(string content, Formato_ formato )
        {
            if(formato != Formato_.CSV && formato != Formato_.TSV)
            {
                throw new ArgumentException("No es posible buscar caracter separador en un archivo que no sea csv o tsv.");
            }

            string[] lineBreaks = { "\r\n", "\n" };
            string[] separators = { ",", ";", "\t" };

            string[] lines = content.Split(lineBreaks, StringSplitOptions.RemoveEmptyEntries);

            foreach (string separator in separators )
            {
                bool separatorFoundInAllLines = true;

                int separatorCountInFirstLine = lines[0].Split(separator).Length;

                Parallel.ForEach(lines, line => {
                    int separatorCount = line.Split(separator).Length;

                    if (separatorCount == 0 || separatorCount != separatorCountInFirstLine)
                    {
                        separatorFoundInAllLines = false;
                    }
                });

                if (separatorFoundInAllLines)
                {
                    return separator;
                }
            };

            throw new ArgumentException("La cantidad de columnas no coincide, el archivo no es valido.");
            return null; // No se encontro ningun caracter separador valido. 
        }

        /// <summary>
        /// Obtener formato por indice
        /// </summary>
        /// <param name="indice"></param>
        public static Formato_ GetFormatoPorIndice(int indice)
        {
            try
            {
                return (Formato_)indice;
            }
            catch { throw new ArgumentException("El formato con el indice especificado no existe"); }
        }
    }

    /// <summary>
    /// Formatos, acoplados al indice del combo de seleccion de la vista. 
    /// </summary>
    public enum Formato_
    {
        JSON = 0,
        CSV = 1,
        XLSX = 2,
        TSV = 3,
        JSONOPTIMIZADO = 4
    }
}

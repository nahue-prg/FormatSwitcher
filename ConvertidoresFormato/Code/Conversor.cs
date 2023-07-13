using MathNet.Numerics.Interpolation;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using WebApiProactivo.Modelos;

namespace ConvertidoresFormato.Code
{
    public class Conversor
    {   
        /// <summary>
        /// Armar y escribir archivo de salida. 
        /// </summary>
        /// <param name="rutaArchivoSeleccionado"></param>
        /// <param name="rutaArchivoDestino"></param>
        /// <param name="NombreArchivoSalida"></param>
        /// <param name="formatoArchivoEntrada"></param>
        /// <param name="formatoSalida"></param>
        /// <param name="ForzarSeparadorEntrada"></param>
        /// <param name="ForzarSeparadorSalida"></param>
        /// <returns></returns>
        public static bool ArmarArchivoSalida(string rutaArchivoSeleccionado, string rutaArchivoDestino, string NombreArchivoSalida, Formato_ formatoArchivoEntrada, Formato_ formatoSalida,string ForzarSeparadorEntrada, string ForzarSeparadorSalida)
        {

            string contentArchivo = "";

            if (formatoArchivoEntrada == Formato_.XLSX)
            {
                contentArchivo = ConvertExcelToAny(rutaArchivoSeleccionado, Formato_.TSV);
                formatoArchivoEntrada = Formato_.TSV;
                ForzarSeparadorEntrada = Formato.GetCaracterFormato(Formato_.TSV);
            }
            else
            {
                contentArchivo = Funcionalidades.LeerArchivo(rutaArchivoSeleccionado);

                if (formatoArchivoEntrada == Formato_.JSON)
                {
                    contentArchivo = ConvertJsonToString(contentArchivo, Formato.GetCaracterFormato(Formato_.TSV));
                    formatoArchivoEntrada = Formato_.TSV;
                    ForzarSeparadorEntrada = Formato.GetCaracterFormato(Formato_.TSV);
                }
            }

            int filasAfectadas = 0;

            string separadorEntrada = "";

            string separadorSalida = "";

            if (formatoArchivoEntrada == Formato_.CSV || formatoArchivoEntrada == Formato_.TSV){

                if (string.IsNullOrEmpty(ForzarSeparadorEntrada))
                    separadorEntrada = Formato.GetCaracterSeparador(contentArchivo, formatoArchivoEntrada)!;
                else
                    separadorEntrada = ForzarSeparadorEntrada;
            }


            if ((formatoSalida == Formato_.CSV || formatoSalida == Formato_.TSV)) { 

                if(string.IsNullOrEmpty(ForzarSeparadorSalida))
                    separadorSalida = Formato.GetCaracterFormato(formatoSalida);
                else
                    separadorSalida = ForzarSeparadorSalida;
            }

            //Armar ruta de salida para el archivo con nombre y extension.
            rutaArchivoDestino +=$"\\{NombreArchivoSalida}.{Formato.ToString(formatoSalida)}";

            switch (formatoSalida) {

                case Formato_.CSV:
                case Formato_.TSV:
                    filasAfectadas = ConvertAndWriteStringToCsvOrTsv(contentArchivo, rutaArchivoDestino, separadorEntrada, separadorSalida);
                    break;
                  
                case Formato_.JSON:
                    filasAfectadas = ConvertAndWriteStringToJson(contentArchivo, rutaArchivoDestino, separadorEntrada);
                    break;

                case Formato_.JSONOPTIMIZADO:
                    filasAfectadas = ConvertAndWriteCsvToOptimizedJson(contentArchivo, separadorEntrada, rutaArchivoDestino);
                    break;

                case Formato_.XLSX:
                    filasAfectadas = ConvertAndWriteStringToExcel(contentArchivo, rutaArchivoDestino, separadorEntrada);
                    break;
                default:
                    throw new Exception("Formato de salida desconocido.");
                    break;
            }

            if (filasAfectadas > 0)
                return true;
    
            return false; 
        }


        /// <summary>
        /// Convertir archivo a excel
        /// </summary>
        /// <param name="stringContent"></param>
        /// <param name="excelFilePath"></param>
        public static int ConvertAndWriteStringToExcel(string stringContent, string excelFilePath, string caracterSeparador)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            int rowNumber = 0;

            using (StringReader reader = new StringReader(stringContent))
            {
                string line;
                
                while ((line = reader.ReadLine()!) != null)
                {
                    string[] cells = line.Split(caracterSeparador);
                    IRow row = sheet.CreateRow(rowNumber);
                    for (int i = 0; i < cells.Length; i++)
                    {
                        row.CreateCell(i).SetCellValue(cells[i]);
                    }
                    rowNumber++;
                }
            }

            using (FileStream fs = new(excelFilePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs, false);
            }

            return rowNumber;
        }

        /// <summary>
        /// Convertir string en JSON. 
        /// </summary>
        /// <param name="stringContent"></param>
        /// <param name="jsonFilePath"></param>
        /// <param name="caracterSeparador"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int ConvertAndWriteStringToJson(string stringContent, string jsonFilePath, string caracterSeparador)
        {
            string[] lines = stringContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string[] headers = lines[0].Split(caracterSeparador);

            List<Dictionary<string, string>> jsonData = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(caracterSeparador);

                if (data.Length != headers.Length)
                {
                    throw new ArgumentException("El número de columnas en los datos no coincide con el número de encabezados.");
                }

                Dictionary<string, string> row = headers.Zip(data, (h, d) => new { Header = h, Data = d })
                    .ToDictionary(x => x.Header, x => x.Data);

                jsonData.Add(row);
            }

            string json = JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(jsonFilePath, json);

            return jsonData.Count;
        }

        /// <summary>
        /// Convertir y escribir json en un archivo csv
        /// </summary>
        /// <param name="jsonContent"></param>
        /// <param name="csvFilePath"></param>
        /// <param name="caracterSeparador"></param>
        /// <exception cref="ArgumentException"></exception>
        public static int ConvertAndWriteJsonToCsv(string jsonContent, string csvFilePath, string caracterSeparador)
        {
            try
            {
                // Convertir el JSON a una lista de diccionarios
                List<Dictionary<string, string>> jsonData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);

                // Obtener los encabezados del CSV a partir de las claves del primer diccionario
                string[] headers = jsonData[0].Keys.ToArray();

                // Crear una lista de cadenas para almacenar las líneas del CSV
                List<string> csvLines = new List<string>();

                // Agregar la primera línea al CSV con los encabezados
                csvLines.Add(string.Join(caracterSeparador, headers));

                // Recorrer los datos y convertirlos a líneas de CSV
                foreach (var data in jsonData)
                {
                    // Obtener los valores de cada columna en el mismo orden que los encabezados
                    string[] values = headers.Select(header => data[header]).ToArray();

                    // Agregar la línea al CSV
                    csvLines.Add(string.Join(caracterSeparador, values));
                }

                // Escribir el contenido del CSV en un archivo
                File.WriteAllLines(csvFilePath, csvLines);

                return csvLines.Count;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Convertir json en string con contenido tipo csv. 
        /// </summary>
        /// <param name="jsonContent"></param>
        /// <param name="caracterSeparador"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ConvertJsonToString(string jsonContent, string caracterSeparador)
        {
            try
            {
                // Convertir el JSON a una lista de diccionarios
                List<Dictionary<string, string>> jsonData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);

                // Obtener los encabezados del CSV a partir de las claves del primer diccionario
                string[] headers = jsonData[0].Keys.ToArray();

                // Crear una lista de cadenas para almacenar las líneas del CSV
                List<string> csvLines = new List<string>();

                // Agregar la primera línea al CSV con los encabezados
                csvLines.Add(string.Join(caracterSeparador, headers));

                // Recorrer los datos y convertirlos a líneas de CSV
                foreach (var data in jsonData)
                {
                    // Obtener los valores de cada columna en el mismo orden que los encabezados
                    string[] values = headers.Select(header => data[header]).ToArray();

                    // Agregar la línea al CSV
                    csvLines.Add(string.Join(caracterSeparador, values));
                }

                // Retornar el contenido del CSV como una sola cadena
                return string.Join(Environment.NewLine, csvLines);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Convierte string en un formato determinado de entrada y lo escribe en un nuevo archivo en u formato determinado. 
        /// </summary>
        /// <param name="stringContent"></param>
        /// <param name="filePath"></param>
        /// <param name="formatoEntrada"></param>
        /// <param name="formatoSalida"></param>
        /// <exception cref="ArgumentException"></exception>
        public static int ConvertAndWriteStringToCsvOrTsv(string stringContent, string filePath, string separadorEntrada, string separadorSalida)
        {
            if (separadorSalida.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es valido para esta operacion");
            }

            if (separadorSalida.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es valido para esta operacion");
            }

            string[] lines = stringContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int filasAfectadas = 0;

            int cont = 1;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {

                    string[] data = line.Split(separadorEntrada);
                    
                    if (data.Length < 2)
                        throw new Exception($"El archivo contiene 1 campo o menos en la linea {cont}. La conversion no tiene efecto. Prueba cambiando el separador");

                    string formattedLine = string.Join(separadorSalida, data);
                    writer.WriteLine(formattedLine);
                    cont++;
                }

                filasAfectadas = lines.Length;
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Convertir csv o tsv a json optimizado 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="caracterSeparador"></param>
        /// <param name="jsonFilePath"></param>
        /// <exception cref="ArgumentException"></exception>
        public static int ConvertAndWriteCsvToOptimizedJson(string content, string caracterSeparador, string jsonFilePath)
        {
            if (caracterSeparador.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es válido para esta operación.");
            }

            string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length < 2)
            {
                throw new ArgumentException("El archivo de entrada contener al menos dos líneas (encabezados y datos).");
            }

            string[] headers = lines[0].Split(caracterSeparador);

            JsonOptimizado jsonOptimizado = new JsonOptimizado();
            Tabla tabla = new Tabla();
            tabla.name = "Tabla";

            for (int i = 0; i < headers.Length; i++)
            {
                Column columna = new Column();
                columna.name = headers[i];
                columna.type = "string";
                tabla.columns.Add(columna);
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(caracterSeparador);

                if (data.Length != headers.Length)
                {
                    throw new ArgumentException("El número de columnas en los datos no coincide con el número de encabezados.");
                }

                List<string> fila = new List<string>(data);
                tabla.rows.Add(fila);
            }

            jsonOptimizado.tables.Add(tabla);

            string json = JsonConvert.SerializeObject(jsonOptimizado, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(jsonFilePath, json);

            return jsonOptimizado.tables[0].rows.Count();
        }

        /// <summary>
        /// Convertir excel en cualquier formato. 
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="formato">Formato en el que se desea recibir la string, soporta csv y tsv</param>
        /// /// <returns>String con</returns>
        public static string ConvertExcelToAny(string content, Formato_ formato)
        {
            string separador = Formato.GetCaracterFormato(formato);

            if (separador.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es valido para esta operacion");
            }
                IWorkbook workbook = new XSSFWorkbook(content);
                ISheet sheet = workbook.GetSheetAt(0); // Suponemos que es la primera hoja del libro

                StringWriter stringWriter = new StringWriter();

                int rowCount = sheet.LastRowNum;
                for (int i = 0; i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row != null)
                    {
                        int cellCount = row.LastCellNum;
                        for (int j = 0; j < cellCount; j++)
                        {
                            ICell cell = row.GetCell(j);
                            if (cell != null)
                            {
                                string cellValue = cell.ToString()!;
                                stringWriter.Write(cellValue);
                            }
                            if (j < cellCount - 1)
                            {
                                stringWriter.Write(separador);
                            }
                        }
                        stringWriter.WriteLine();
                    }
                }
                return stringWriter.ToString();
           }

    }
}

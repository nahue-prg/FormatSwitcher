using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Text;
using WebApiProactivo.Modelos;

namespace ConvertidoresFormato.Code
{
    public class Conversor
    {
        #region CSV
        /// <summary>
        /// Convertir archivo a excel
        /// </summary>
        /// <param name="stringContent"></param>
        /// <param name="excelFilePath"></param>
        public static void ConvertAndWriteStringToExcel(string stringContent, string excelFilePath, string caracterSeparador)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            using (StringReader reader = new StringReader(stringContent))
            {
                string line;
                int rowNumber = 0;
                while ((line = reader.ReadLine()) != null)
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
        }

        /// <summary>
        /// Convertir string en JSON. 
        /// </summary>
        /// <param name="stringContent"></param>
        /// <param name="jsonFilePath"></param>
        /// <param name="caracterSeparador"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static void ConvertAndWriteStringToJson(string stringContent, string jsonFilePath, string caracterSeparador)
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
        }

        /// <summary>
        /// Convierte string en un formato determinado de entrada y lo escribe en un nuevo archivo en u formato determinado. 
        /// </summary>
        /// <param name="stringContent"></param>
        /// <param name="filePath"></param>
        /// <param name="formatoEntrada"></param>
        /// <param name="formatoSalida"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ConvertAndWriteStringToCsvOrTsv(string stringContent, string filePath, Formato_ formatoEntrada, Formato_ formatoSalida )
        {
            string separadorSalida = Formato.GetCaracterFormato(formatoSalida);

            if (separadorSalida.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es valido para esta operacion");
            }

            string separadorEntrada = Formato.GetCaracterFormato(formatoEntrada);

            if (separadorSalida.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es valido para esta operacion");
            }

            string[] lines = stringContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    string[] data = line.Split(separadorEntrada);
                    string formattedLine = string.Join(separadorSalida, data);
                    writer.WriteLine(formattedLine);
                }
            }
        }

        /// <summary>
        /// Convertir csv o tsv a json optimizado 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="caracterSeparador"></param>
        /// <param name="isCsv"></param>
        /// <param name="jsonFilePath"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ConvertCsvOrTsvToOptimizedJson(string content, Formato_ formato, string jsonFilePath)
        {
            string separador = Formato.GetCaracterFormato(formato);

            if (separador.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es válido para esta operación.");
            }

            string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length < 2)
            {
                throw new ArgumentException("El archivo de entrada contener al menos dos líneas (encabezados y datos).");
            }

            string[] headers = lines[0].Split(separador);

            JsonOptimizado jsonOptimizado = new JsonOptimizado();
            Tabla tabla = new Tabla();
            tabla.nombre = "Tabla";

            for (int i = 0; i < headers.Length; i++)
            {
                Columna columna = new Columna();
                columna.nombre = headers[i];
                columna.tipo = "string";
                tabla.columnas.Add(columna);
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(separador);

                if (data.Length != headers.Length)
                {
                    throw new ArgumentException("El número de columnas en los datos no coincide con el número de encabezados.");
                }

                List<string> fila = new List<string>(data);
                tabla.filas.Add(fila);
            }

            jsonOptimizado.tablas.Add(tabla);


            string json = JsonConvert.SerializeObject(jsonOptimizado, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(jsonFilePath, json);
        }

        /// <summary>
        /// Convertir excel en cualquier formato. 
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="formato">Formato en el que se desea recibir la string, soporta csv y tsv</param>
        /// /// <returns>String con</returns>
        public static string ConvertExcelToAny(string excelFilePath, Formato_ formato)
        {
            string separador = Formato.GetCaracterFormato(formato);

            if (separador.Length == 0)
            {
                throw new ArgumentException("El formato especificado no es valido para esta operacion");
            }

            using (FileStream file = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(file);
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
                                string cellValue = cell.ToString();
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

        #endregion

    }
}

namespace WebApiProactivo.Modelos
{
    /// <summary>
    /// Modelo generico para manejar datos de manera similar a csv en un json. 
    /// </summary>
    public class JsonOptimizado
    {
        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        public JsonOptimizado()
        {
            this.tables = new List<Tabla>();
        }

        /// <summary>
        /// Tablas del modelo
        /// </summary>
        public List<Tabla> tables { get; set; }
    }

    /// <summary>
    /// Tabla con nombre, columnas y filas
    /// </summary>
    public class Tabla
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Tabla()
        {
            this.columns = new();
            this.rows = new();
        }

        /// <summary>
        /// Nombre de la tabla
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Columnas de la tabla
        /// </summary>
        public List<Column> columns { get; set; }
        /// <summary>
        /// Filas de la tabla
        /// </summary>
        public List<List<string>> rows { get; set; }
    }

    /// <summary>
    /// Columnas de la tabla 
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Tipo de dato de la columna
        /// </summary>
        public string type { get; set; }
    }

}


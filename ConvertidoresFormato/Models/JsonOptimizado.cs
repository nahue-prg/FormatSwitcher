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
            this.tablas = new List<Tabla>();
        }

        /// <summary>
        /// Tablas del modelo
        /// </summary>
        public List<Tabla> tablas { get; set; }
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
            this.columnas = new();
            this.filas = new();
        }

        /// <summary>
        /// Nombre de la tabla
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Columnas de la tabla
        /// </summary>
        public List<Columna> columnas { get; set; }
        /// <summary>
        /// Filas de la tabla
        /// </summary>
        public List<List<string>> filas { get; set; }
    }

    /// <summary>
    /// Columnas de la tabla 
    /// </summary>
    public class Columna
    {
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        public string nombre { get; set; }
        /// <summary>
        /// Tipo de dato de la columna
        /// </summary>
        public string tipo { get; set; }
    }

}


using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dotenv.net;


namespace pruebaSantiAPI_REST.SQL.DAO
{
    public class ConnectionBD
    {
        // no se crea ninguna instancia mientras no se tenga acceso por primera vez con Lazy<T>
        private static readonly Lazy<ConnectionBD> lazyInstance = new Lazy<ConnectionBD>(() => new ConnectionBD());
        public static ConnectionBD Instance => lazyInstance.Value;
        private MySqlConnection connection;
        private ConnectionBD()
        {
            // Cargar variables de entorno desde el archivo .env
            // Poner ruta absoluta de tu archivo .env ( Temporal hasta arreglar)
            var rutaAbsoluta = "D:\\DAM\\DAM_Segundo\\Desarrollo_De_Interfaces\\Proyectos_discoDuro\\api-rest-libreria-.net\\api-libreria-dotnet\\.env";
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { rutaAbsoluta }));


            string connectionString = GetConnectionURL();
            try
            {
                this.connection = new MySqlConnection(connectionString);
            }catch (Exception ex)
            {
                throw new Exception("Error al conectarse con la BBDD"+ ex.Message);
            }
        }

        private string GetConnectionURL()
        {
            // Coge los valores del archivo .env
            string server = Environment.GetEnvironmentVariable("DB_SERVER");
            string database = Environment.GetEnvironmentVariable("DB_DATABASE");
            string user = Environment.GetEnvironmentVariable("DB_USER");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            return $"Server={server};Database={database};Uid={user};Pwd={password};";
        }

        public MySqlConnection GetConnection()
        {
            if (this.connection.State != System.Data.ConnectionState.Open)
            {
                this.connection.Open();
            }
            return this.connection;
        }

        public void CloseConnection()
        {
            this.connection?.Close();
        }

       
    }

}
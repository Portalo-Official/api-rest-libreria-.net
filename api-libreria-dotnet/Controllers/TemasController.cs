using dotenv.net;
using pruebaSantiAPI_REST.SQL.DAO;
using pruebaSantiAPI_REST.SQL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace pruebaSantiAPI_REST.Controllers
{
    

    [RoutePrefix("api/tema")]
    public class TemaController : ApiController
    {
        private ConnectionBD Connection;
        private TemaDAO temaDAO;

        public TemaController()
        {
            this.Connection = ConnectionBD.Instance;
            this.temaDAO = new TemaDAO(this.Connection.GetConnection());
        }

        // [HttpGet]
        // [Route("tema-controller")]
        // public List<string> getTemas()
        // {
        //     var root = Directory.GetCurrentDirectory();
        //     var dotenv = Path.Combine(root, "../.env");
        //     var rutaAbsoluta = "D:\\DAM\\DAM_Segundo\\Desarrollo_De_Interfaces\\Proyectos_discoDuro\\api-rest-libreria-.net\\api-libreria-dotnet\\.env";
        //     DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {rutaAbsoluta }));
        //
        //     string server = Environment.GetEnvironmentVariable("DB_SERVER");
        //     string database = Environment.GetEnvironmentVariable("DB_DATABASE");
        //     string user = Environment.GetEnvironmentVariable("DB_USER");
        //     string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        //
        //     return new List<string> { rutaAbsoluta,dotenv, server, database, user,password };

        //return this.temaDAO.ObtenerTodosLosTemas();
        //} 

        [HttpGet]
        [Route("tema-controller")]
        public List<DTO_Tema> getTemas()
        {
            //  var root = Directory.GetCurrentDirectory();
            //  var dotenv = Path.Combine(root, "../.env");
            //  var rutaAbsoluta = "D:\\DAM\\DAM_Segundo\\Desarrollo_De_Interfaces\\Proyectos_discoDuro\\api-rest-libreria-.net\\api-libreria-dotnet\\.env";
            //  DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {rutaAbsoluta }));

            // string server = Environment.GetEnvironmentVariable("DB_SERVER");
            //  string database = Environment.GetEnvironmentVariable("DB_DATABASE");
            // string user = Environment.GetEnvironmentVariable("DB_USER");
            // string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            // return new List<string> { rutaAbsoluta,dotenv, server, database, user,password };

            return this.temaDAO.ObtenerTodosLosTemas();
        }

        [HttpPut]
        [Route("tema-controller")]
        public string putTemas()
        {
            return "Insertando Tema con su EndPoint";
        }

        [HttpPost]
        [Route("tema-controller")]
        public string postTemas()
        {
            return "Actualizar tema";
        }

        [HttpDelete]
        [Route("tema-controller")]
        public string deleteTema()
        {
            return "Borrar tema";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pruebaSantiAPI_REST.Controllers
{
    [RoutePrefix("api/autor")]
    public class AutoresController : ApiController
    {
        [HttpPost]
        [Route("autores-controller")]
        public string postAutores()
        {
            return "Actualizar autores";
        }
        [HttpGet]
        [Route("autores-controller")]
        public List<string> getAutores()
        {
            return new List<string> { "Rebecca Yarros", "JK Rowling", "Cassandra Clare" };
        }
        [HttpPut]
        [Route("autores-controller")]
        public string putAutores()
        {
            return "Insertando autores";
        }
        [HttpDelete]
        [Route("autores-controller")]
        public string deleteAutores()
        {
            return "Borrando autores";
        }
    }
}

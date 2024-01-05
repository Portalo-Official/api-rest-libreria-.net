using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pruebaSantiAPI_REST.Controllers
{
    [RoutePrefix("api/tema")]
    public class TemaController : ApiController
    {
        [HttpGet]
        [Route("tema-controller")]
        public List<string> getTemas()
        {
            return new List<string> { "Terror", "Romance", "Aventura" };
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

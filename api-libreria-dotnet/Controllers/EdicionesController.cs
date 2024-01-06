using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pruebaSantiAPI_REST.Controllers
{
    [RoutePrefix("api/edicion")]
    public class EdicionesController : ApiController
    {
        [HttpPost]
        [Route("ediciones-controller")]
        public string postEdiciones()
        {
            return "Actualizar ediciones";
        }
        [HttpGet]
        [Route("ediciones-controller")]
        public List<string> getEdiciones()
        {
            return new List<string> { "Especial", "Estandar", "Coleccionista" };
        }
        [HttpPut]
        [Route("ediciones-controller")]
        public string putEdiciones()
        {
            return "Insertando ediciones";
        }
        [HttpDelete]
        [Route("ediciones-controller")]
        public string deleteEdiciones()
        {
            return "Borrando ediciones";
        }
    }
}

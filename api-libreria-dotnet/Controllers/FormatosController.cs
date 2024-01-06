using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pruebaSantiAPI_REST.Controllers
{
    [RoutePrefix("api/formato")]
    public class FormatosController : ApiController
    {
        [HttpPost]
        [Route("formatos-controller")]
        public string postFormatos()
        {
            return "Actualizar formatos";
        }
        [HttpGet]
        [Route("formatos-controller")]
        public List<string> getFormatos()
        {
            return new List<string> { "Tapa blanda", "Tapa dura", "Edicion bolsillo" };
        }
        [HttpPut]
        [Route("formatos-controller")]
        public string putFormatos()
        {
            return "Insertando formatos";
        }
        [HttpDelete]
        [Route("formatos-controller")]
        public string deleteFormatos()
        {
            return "Borrando formatos";
        }
    }
}

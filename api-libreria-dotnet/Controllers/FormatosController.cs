using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.entity;
using pruebaSantiAPI_REST.SQL.DAO;
using pruebaSantiAPI_REST.SQL.DAO.DAOMySQL;
using pruebaSantiAPI_REST.SQL.DAO.interfaceDAO;
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

        private IFormatoDAO formatoDAO;
        private ConnectionBD connectionBD;

        public FormatosController()
        {
            this.connectionBD= ConnectionBD.Instance;
            formatoDAO = new FormatoDAOMySQL(this.connectionBD.GetConnection());
        }


        [HttpPost]
        [Route("formatos-controller")]
        public Response postFormatos(Request request)
        {
            return formatoDAO.create(new FormatoDTO { Id=request.Id, Tipo=request.Name});
        }
        [HttpGet]
        [Route("formatos-controller")]
        public List<FormatoDTO> getFormatos()
        {
            return formatoDAO.findAll();
        }

        [HttpPut]
        [Route("formatos-controller")]
        public Response putFormatos(Request request)
        {
            return formatoDAO.update(new FormatoDTO { Id=request.Id, Tipo=request.Name});
        }
        [HttpDelete]
        [Route("formatos-controller")]
        public Response deleteFormatos(Request request)
        {
            return formatoDAO.delete(request.Id);
        }
    }
}

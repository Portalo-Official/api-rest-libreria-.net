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
    [RoutePrefix("api/edicion")]
    public class EdicionesController : ApiController
    {

        private ConnectionBD connection;
        private IEdicionDAO edicionDAO;
        public EdicionesController()
        {
            connection = ConnectionBD.Instance;
            edicionDAO = new EdicionDAOMySQL(connection.GetConnection());
        }


        [HttpPost]
        [Route("ediciones-controller")]
        public Response postEdiciones(Request request)
        {
            EdicionDTO edicionNueva = new EdicionDTO()
            {
                Id = request.Id,
                Tipo = request.Name
            };
            return edicionDAO.create(edicionNueva) ;
        }


        [HttpGet]
        [Route("ediciones-controller")]
        public List<EdicionDTO> getEdiciones()
        {
            return edicionDAO.findAll();
        }

        [HttpPut]
        [Route("ediciones-controller")]
        public Response putEdiciones(Request request)
        {
           // EdicionDTO edicionActualizada = new EdicionDTO() { Id = request.Id, Tipo = request.Name };
            return edicionDAO.update(new EdicionDTO{ Id = request.Id, Tipo = request.Name });
        }

        [HttpDelete]
        [Route("ediciones-controller")]
        public Response deleteEdiciones(Request request)
        {
            return edicionDAO.delete(request.Id);
        }
    }
}

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
    [RoutePrefix("api/autor")]
    public class AutoresController : ApiController
    {
        private IAutorDAO autoresDAO;
        private ConnectionBD connection;

        public AutoresController() { 
            connection = ConnectionBD.Instance;
            autoresDAO = new AutoresDAOMySQL(connection.GetConnection());
        }

        [HttpPost]
        [Route("autores-controller")]
        public Response postAutores(Request request)
        {
            return autoresDAO.create(new AutorDTO { Id=request.Id, Nombre= request.Name});
        }
        [HttpGet]
        [Route("autores-controller")]
        public List<AutorDTO> getAutores()
        {
            return autoresDAO.findAll();
        }
        [HttpPut]
        [Route("autores-controller")]
        public Response putAutores(Request request)
        {
            return autoresDAO.update(new AutorDTO { Id=request.Id, Nombre=request.Name});
        }
        [HttpDelete]
        [Route("autores-controller")]
        public Response deleteAutores(Request request)
        {
            return autoresDAO.delete(request.Id);
        }
    }
}

using pruebaSantiAPI_REST.SQL.DAO.interfaceDAO;
using pruebaSantiAPI_REST.SQL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pruebaSantiAPI_REST.Models.entity;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.DTO;
using pruebaSantiAPI_REST.SQL.DAO.DAOMySQL;
using pruebaSantiAPI_REST.SQL.Mapper;
using System.Web.Http.Cors;

namespace pruebaSantiAPI_REST.Controllers
{
    //[EnableCors(origins:"*", headers:"*", methods:"*")]
    [RoutePrefix("api/libro")]
    public class LibroController : ApiController
    {
        private ILibroDao libroDao;
        private ConnectionBD connection;
        public LibroController() {
            connection = ConnectionBD.Instance;
            libroDao = new LibroDaoMySQL(connection.GetConnection());
        }

        [HttpPost]
        [Route("libro-controller")]
        public Response postLibro(RequestLibro request)
        {
            return libroDao.create(LibroMapper.MapFromRequest(request));
        }
        [HttpGet]
        [Route("libro-controller")]
        public List<DTO_Libro> getLibros()
        {
            return libroDao.findAll();
        }

        [HttpGet]
        [Route("libro-controller/isbn/{isbn}")]
        public Response getLibroByISBN([FromUri] string isbn)
        {
            return libroDao.read(isbn);
        }

        [HttpPut]
        [Route("libro-controller")]
        public Response putLibro(RequestLibro request)
        {
            return libroDao.update(LibroMapper.MapFromRequest(request));
        }
        [HttpDelete]
        [Route("libro-controller")]
        public Response deleteLibro(RequestLibro request)
        {
            return libroDao.delete(request.ISBN);
        }


    }
}

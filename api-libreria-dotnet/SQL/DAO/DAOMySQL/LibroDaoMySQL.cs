using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.DTO;
using pruebaSantiAPI_REST.Models.entity;
using pruebaSantiAPI_REST.SQL.DAO.interfaceDAO;
using pruebaSantiAPI_REST.SQL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.DAO.DAOMySQL
{
    public class LibroDaoMySQL : ILibroDao
    {
        private MySqlConnection connection;

        public LibroDaoMySQL(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public Response create(DTO_Libro entity)
        {
            Response response = new Response();
            try
            {

                using (MySqlCommand command = new MySqlCommand("createLibro", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    //string query = @"call createLibro()"; //TODO 
                    response.MessageSuccess("Creado con exito");
                    response.Data = entity;
                }
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }
            return response;
        }

        public Response delete(long id_entity)
        {
            throw new NotImplementedException();
        }

        public List<DTO_Libro> findAll()
        {
            List<DTO_Libro> libros = new List<DTO_Libro>();
            MySqlCommand ejecucion = new MySqlCommand("getLibros", this.connection);

            ejecucion.CommandType = System.Data.CommandType.StoredProcedure;

            MySqlDataReader resultado = ejecucion.ExecuteReader();

            while (resultado.Read())
            {
                libros.Add(new LibroMapper().MapToDto(resultado));
            }
            resultado.Close();
            return libros;
        }

        public Response read(long id_entity)
        {
            throw new NotImplementedException();
        }

        public Response update(DTO_Libro entity)
        {
            throw new NotImplementedException();
        }
    }
}
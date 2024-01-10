using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.entity;
using pruebaSantiAPI_REST.SQL.DAO.interfaceDAO;
using pruebaSantiAPI_REST.SQL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.DAO.DAOMySQL
{
    public class AutoresDAOMySQL : IAutorDAO
    {
        private readonly MySqlConnection connection;

        public AutoresDAOMySQL(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public Response create(AutorDTO entity)
        {
            Response response = new Response();
            try
            {
                MySqlCommand command = new MySqlCommand("createAutor", connection);
            
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre_autor", entity.Nombre);
                command.ExecuteNonQuery();
                response.MessageSuccess("Autor creado con exito.");
                response.Data = entity;
            }catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }
            
            return response;
        }

        public Response read(long id_entity)
        {
            Response response = new Response();
            try
            {
                MySqlCommand command = new MySqlCommand("getAutor", connection);
            
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_autor", id_entity);

                MySqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    response.Data = new AutorMapper().MapToDto(reader);
                }
                response.MessageSuccess("Autor encontrado.");
                reader.Close();
            }catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }

                
            return response;
        }

        public Response update(AutorDTO entity)
        {
            Response response= new Response();
            try
            {

                MySqlCommand command = new MySqlCommand("updateAutor", connection);
            
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_autor", entity.Id);
                command.Parameters.AddWithValue("@nombreActualizado", entity.Nombre);
                command.ExecuteNonQuery();
                response.MessageSuccess("Autor actualizado con exito.");
                response.Data = entity;
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }
            
            return response;
        }

        public Response delete(long id_entity)
        {
            Response response = new Response();
            try
            {

                MySqlCommand command = new MySqlCommand("deleteAutor", connection);
            
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_Autor", id_entity);
                command.ExecuteNonQuery();

                response.MessageSuccess("Autor eliminado con exito");
                response.Data = read(id_entity).Data;
            }catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }
            
            return response;
        }

        public List<AutorDTO> findAll()
        {
            List<AutorDTO> autores = new List<AutorDTO>();

            MySqlCommand command = new MySqlCommand("getAutores", this.connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                autores.Add(new AutorMapper().MapToDto(reader));
            }
            reader.Close();
            return autores;
        }
    }
}
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
            string query="";
            try
            {

                using (MySqlCommand command = new MySqlCommand("createLibro", connection))
                {
                    
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_isbn", entity.ISBN);
                    command.Parameters.AddWithValue("@p_titulo", entity.Titulo);
                    command.Parameters.AddWithValue("@p_precio", entity.Precio.ToString());
                    command.Parameters.AddWithValue("@p_autor", entity.Autor);
                    command.Parameters.AddWithValue("@p_edicion", entity.Edicion);
                    command.Parameters.AddWithValue("@p_tema", entity.Tema);
                    command.Parameters.AddWithValue("@p_formato", entity.Formato);
                    command.Parameters.AddWithValue("@p_stock", entity.Cantidad.ToString());
                    //query = @"call createLibro(@p_isbn, @p_titulo,@p_precio,@p_autor, @p_edicion, @p_tema, @p_formato, @p_stock)";
                    //query = query.Replace("@p_isbn", entity.ISBN);
                    //query = query.Replace("@p_titulo", entity.Titulo);
                    //query = query.Replace("@p_precio", entity.Precio.ToString());
                    //query = query.Replace("@p_autor", entity.Autor);
                    //query = query.Replace("@p_edicion", entity.Edicion);
                    //query = query.Replace("@p_tema", entity.Tema);
                    //query = query.Replace("@p_formato", entity.Formato);
                    //query = query.Replace("@p_stock", entity.Cantidad.ToString());

                    command.ExecuteNonQuery();
                    response.MessageSuccess("Creado con exito");
                    response.Data = entity;
                }
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
                //response.MessageError(query);
            }
            return response;
        }

        public Response delete(string id_entity)
        {
            Response response= new Response();

            try
            {
                MySqlCommand ejecucion = this.connection.CreateCommand();
                string query = @"call deleteLibro(@p_isbn)";
                query = query.Replace("@p_isbn", id_entity);

                ejecucion.CommandText = query;
                ejecucion.ExecuteNonQuery();
                response.MessageSuccess("Libro "+id_entity+" eliminado con exito");
            }catch(Exception ex)
            {
                response.MessageError(ex.Message);
            }
            return response;
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

        public Response read(string id_entity)
        {
            Response response = new Response();
            
            try
            {
                MySqlCommand command = new MySqlCommand("getLibrosByISBN", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_isbn", id_entity);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    response.Data = new LibroMapper().MapToDto(reader);
                }
                // Cerrar reader
                reader.Close();
                response.MessageSuccess("Libro: " + ((DTO_Libro)response.Data).Titulo + " encontrado nene");
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }

            return response;
        }

        public Response update(DTO_Libro entity)
        {
            Response response = new Response();
            try
            {

                using (MySqlCommand command = new MySqlCommand("updateLibro", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    string query = @"call updateLibro(@p_isbn
                                                      ,@p_titulo
                                                      ,@p_precio
                                                      ,@p_autor
                                                      ,@p_edicion
                                                      ,@p_tema
                                                      ,@p_formato
                                                      )";
                    query = query.Replace("@p_isbn", entity.ISBN);
                    query = query.Replace("@p_titulo", entity.Titulo);
                    query = query.Replace("@p_precio", entity.Precio.ToString());
                    query = query.Replace("@p_autor", entity.Autor);
                    query = query.Replace("@p_edicion", entity.Edicion);
                    query = query.Replace("@p_tema", entity.Tema);
                    query = query.Replace("@p_formato", entity.Formato);

                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    response.MessageSuccess("Actualizado con exito");
                    response.Data = entity;
                }
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }
            return response;
        }
    }
}
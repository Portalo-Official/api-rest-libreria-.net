using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.entity;
using pruebaSantiAPI_REST.SQL.DAO.interfaceDAO;
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
            using (MySqlCommand command = new MySqlCommand("putAutor", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nuevoAutor", entity.Nombre);
                command.ExecuteNonQuery();
            }
            return null;
        }

        public AutorDTO read(long id_entity)
        {
            using (MySqlCommand command = new MySqlCommand("getAutor", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id_entity);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AutorDTO
                        {
                            Id = reader.GetInt64("Id"),
                            Nombre = reader.GetString("Nombre")
                        };
                    }
                    return null;
                }
            }
        }

        public Response update(AutorDTO entity)
        {
            using (MySqlCommand command = new MySqlCommand("updateAutores", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@autorActualizado", entity.Nombre);
                command.ExecuteNonQuery();
            }
            return null;
        }

        public Response delete(long id_entity)
        {
            using (MySqlCommand command = new MySqlCommand("deleteAutor", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_Autor", id_entity);
                command.ExecuteNonQuery();
            }
            return null;
        }

        public List<AutorDTO> findAll()
        {
            List<AutorDTO> autores = new List<AutorDTO>();

            MySqlCommand command = new MySqlCommand("getAutores", this.connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                autores.Add(new AutorDTO
                {
                    Id = reader.GetInt64("Id"),
                    Nombre = reader.GetString("Nombre")
                });
            }

            return autores;
        }
    }
}
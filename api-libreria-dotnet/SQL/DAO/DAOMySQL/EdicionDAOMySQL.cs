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
    public class EdicionDAOMySQL : IEdicionDAO
    {
        private readonly MySqlConnection connection;

        public EdicionDAOMySQL(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public Response create(EdicionDTO entity)
        {
            using (MySqlCommand command = new MySqlCommand("putEdicion", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nuevaEdicion", entity.Tipo);
                command.ExecuteNonQuery();
            }
            return null;
        }

        public EdicionDTO read(long id_entity)
        {
            using (MySqlCommand command = new MySqlCommand("findEdicionById", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_edicion", id_entity);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new EdicionDTO
                        {
                            Id = reader.GetInt64("Id"),
                            Tipo = reader.GetString("Tipo")
                        };
                    }
                    return null;
                }
            }
        }

        public Response update(EdicionDTO entity)
        {
            using (MySqlCommand command = new MySqlCommand("updateEdiciones", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@edicionActualizada", entity.Tipo);
                command.ExecuteNonQuery();
            }
            return null;
        }

        public Response delete(long id_entity)
        {
            using (MySqlCommand command = new MySqlCommand("deleteEdicion", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_Edicion", id_entity);
                command.ExecuteNonQuery();
            }
            return new Response();
        }

        public List<EdicionDTO> findAll()
        {
            List<EdicionDTO> ediciones = new List<EdicionDTO>();

            MySqlCommand command = new MySqlCommand("getEdiciones", this.connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ediciones.Add(new EdicionDTO
                {
                    Id = reader.GetInt64("Id"),
                    Tipo = reader.GetString("Tipo")
                });
            }

            return ediciones;
        }
    }
}
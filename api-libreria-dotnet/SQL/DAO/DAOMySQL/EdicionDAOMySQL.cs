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
    public class EdicionDAOMySQL : IEdicionDAO
    {
        private readonly MySqlConnection connection;

        public EdicionDAOMySQL(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public Response create(EdicionDTO entity)
        {
            Response response = new Response();
            try
            {
                MySqlCommand command = new MySqlCommand("createEdicion", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tipo_edicion", entity.Tipo);
                command.ExecuteReader();
              

                response.MessageSuccess("Edicion "+entity.Tipo+" creada con exito");
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
                MySqlCommand command = new MySqlCommand("findEdicionById", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_edicion", id_entity);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                  response.Data = new EdicionMapper().MapToDto(reader);
                }
                reader.Close();
                response.MessageSuccess("Edicion id:"+id_entity+", Leido con exito.");
            }catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }


            return response;     
            
        }

        public Response update(EdicionDTO entity)
        {
            Response response = new Response();
            try
            {
                MySqlCommand ejecucion = new MySqlCommand("updateEdiciones", connection);

                string query = @"call updateEdicion('@id_edicion' , '@tipo_edicion')";
                // Concatendo entity.id+"" para que sea string
                query = query.Replace("@id_edicion",  entity.Id+"");
                query = query.Replace("@tipo_edicion",  entity.Tipo);
                ejecucion.CommandText = query;

                ejecucion.ExecuteNonQuery();

                response.MessageSuccess("Edicion" + entity.Tipo + " Actualizada");

            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }

            
            //MySqlCommand command = new MySqlCommand("updateEdiciones", connection);
            
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@id", entity.Id);
            //command.Parameters.AddWithValue("@edicionActualizada", entity.Tipo);
            //command.ExecuteNonQuery();
            
            return response;
        }

        public Response delete(long id_entity)
        {
            Response response = new Response();
            try
            {
                MySqlCommand command = new MySqlCommand("deleteEdicion", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_Edicion", id_entity);
                command.ExecuteNonQuery();
                response.MessageSuccess("Registro Borrado con existo.");
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
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
                ediciones.Add(new EdicionMapper().MapToDto(reader));
            }
            reader.Close();
            return ediciones;
        }
    }
}
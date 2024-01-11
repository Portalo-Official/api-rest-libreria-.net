using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.entity;
using pruebaSantiAPI_REST.SQL.DAO.interfaceDAO;
using pruebaSantiAPI_REST.SQL.DTO;
using pruebaSantiAPI_REST.SQL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.DAO.DAOMySQL
{
    public class FormatoDAOMySQL : IFormatoDAO
    {
        private MySqlConnection connection;

        public FormatoDAOMySQL(MySqlConnection conexion)
        {
            this.connection = conexion;
        }

        public Response create(FormatoDTO entity)
        {
            Response response = new Response();
            try
            {
                MySqlCommand ejecucion = this.connection.CreateCommand();

                string query = @"call createFormato('@tipo_formato')";
                
                query = query.Replace("@tipo_formato", entity.Tipo.ToString());

                ejecucion.CommandText = query;
                ejecucion.ExecuteNonQuery();

                response.MessageSuccess("Formato creado con exito");
                response.Data = entity;
            }catch(Exception ex)
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
                MySqlCommand ejecucion = this.connection.CreateCommand();
                string query = @"call deleteFormato('@id_formato')";
                query = query.Replace("@id_formato", id_entity.ToString());

                ejecucion.CommandText = query;
                ejecucion.ExecuteNonQuery();
                response.MessageSuccess("Formato eliminado con exito nene");
            }
            catch(Exception ex)
            {
                response.MessageError(ex.Message);
            }

            return response; 
        }

        public List<FormatoDTO> findAll()
        {
            List<FormatoDTO> formatos = new List<FormatoDTO>();
            MySqlCommand ejecucion = new MySqlCommand("getFormatos", this.connection);

            ejecucion.CommandType = System.Data.CommandType.StoredProcedure;

            MySqlDataReader resultado = ejecucion.ExecuteReader();

            while (resultado.Read())
            {
                formatos.Add(new FormatoMapper().MapToDto(resultado));
            }
            resultado.Close();
            return formatos;
        }

        public Response read(long id_entity)
        {
            Response response = new Response();
            FormatoDTO temaEncontrado = null;
            try
            {
                MySqlCommand command = new MySqlCommand("findFormatoById", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_formato", id_entity);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    response.Data = new FormatoMapper().MapToDto(reader);
                }
                // Cerrar reader
                reader.Close();
                response.MessageSuccess("Formato: " + temaEncontrado.Tipo + " encontrado nene");
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }

            return response;
        }

        public Response update(FormatoDTO entity)
        {
            Response response = new Response();
            try
            {
                using (MySqlCommand command = new MySqlCommand("updateFormato", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_formato", entity.Id);
                    command.Parameters.AddWithValue("@tipo_formato", entity.Tipo);

                    command.ExecuteNonQuery();
                }
                response.MessageSuccess("Formato Actualizado " + entity.Tipo + " nene");
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }

            return response;
        }
    }
}
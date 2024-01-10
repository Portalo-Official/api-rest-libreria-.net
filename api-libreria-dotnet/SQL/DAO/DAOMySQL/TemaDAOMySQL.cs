using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.SQL.DTO;
using pruebaSantiAPI_REST.SQL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.DAO
{
    // Info: https://rjcodeadvance.com/patrones-de-software-que-es-patron-de-diseno-parte-2/
    // AutoMapper: https://bravedeveloper.com/2021/12/24/aplicando-el-patron-dto-y-mapeando-objetos-con-automapper-en-un-web-api-con-net-core/
    public class TemaDAOMySQL:ITemaDAO
    {
        private readonly MySqlConnection connection;

        public TemaDAOMySQL(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public Response create(DTO_Tema entity)
        {
            Response response = new Response();
            try
            {

            using (MySqlCommand command = new MySqlCommand("createTema", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@temaNuevo", entity.Tipo);
                command.ExecuteNonQuery();
                response.MessageSuccess("Creado con exito");
                response.Data = entity;
            }
            }catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }
            return response;
        }

        public Response read(long id_entity)
        {
            Response response = new Response();
            DTO_Tema temaEncontrado=null;
            try
            {
                MySqlCommand command = new MySqlCommand("findTemaById", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_tema", id_entity);

                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    response.Data = new TemaMapper().MapToDto(reader);
                }
                // Cerrar reader
                reader.Close();
                response.MessageSuccess("Tema: " + temaEncontrado.Tipo + " encontrado nene");
            }
            catch (Exception ex)
            {
                response.MessageError(ex.Message);
            }

            return response;
        }

        public Response update(DTO_Tema entity)
        {
            Response response = new Response();
            try
            {
                using (MySqlCommand command = new MySqlCommand("updateTema", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_temaViejo", entity.Id);
                    command.Parameters.AddWithValue("@temaNuevo", entity.Tipo);

                    command.ExecuteNonQuery();
                }
                response.MessageSuccess("Tema Actualizado " + entity.Tipo + " nene");
            }catch(Exception ex)
            {
                
                response.MessageError(ex.Message);
            }

            return response;
        }

        public Response delete(long id_entity)
        {
            Response response=new Response();
            
            try
            {
                MySqlCommand ejecucion = new MySqlCommand("deleteTema()", connection);

                string query = @"call deleteTema('@temaBorrar')";
                // Concatendo entity.id+"" para que sea string -> Quitado
                query = query.Replace("@temaBorrar", id_entity.ToString());
                ejecucion.CommandText = query;
                ejecucion.ExecuteNonQuery();
                
                response.MessageSuccess("Tema eliminado con existo");
            }catch(Exception ex)
            {
                response.MessageError(ex.Message);
            }
            return response;
        }

        public List<DTO_Tema> findAll()
        {
            List<DTO_Tema> temas = new List<DTO_Tema>();

            MySqlCommand command = new MySqlCommand("getTemas", this.connection);
            // Cogemos Procedure
            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Ejecutamos Procedure
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                temas.Add( new TemaMapper().MapToDto(reader));
            }
            reader.Close();
            return temas;
        }
    }
}
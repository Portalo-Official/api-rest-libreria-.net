using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.SQL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<DTO_Tema> ObtenerTodosLosTemas()
        {
            List<DTO_Tema> temas = new List<DTO_Tema>();

            MySqlCommand command = new MySqlCommand("getTemas", this.connection);
            // Cogemos Procedure
            command.CommandType = System.Data.CommandType.StoredProcedure;
            // Ejecutamos Procedure
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                temas.Add(DTO_Tema.FromDataReader(reader));
            }



            return temas;
        }

        public void AgregarTema(string nuevoTema, int idTema)
        {
            using (MySqlCommand command = new MySqlCommand("putTema", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nuevoTema", nuevoTema);
                command.Parameters.AddWithValue("@idtema", idTema);
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarTema(int id, string temaActualizado)
        {
            using (MySqlCommand command = new MySqlCommand("updateTemas", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@temaActualizado", temaActualizado);

                command.ExecuteNonQuery();
            }
        }

        public bool EliminarTema(int id)
        {
            using (MySqlCommand command = new MySqlCommand("deleteTema", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_Tema", id);

                int rowAffected = command.ExecuteNonQuery();
                return rowAffected > 0; // Retorna -1 para cualquier otro valor no Query ok
            }
        }

        public void create(DTO_Tema entity)
        {
            throw new NotImplementedException();
        }

        public DTO_Tema read(int id_entity)
        {
            throw new NotImplementedException();
        }

        public void update(DTO_Tema entity)
        {
            throw new NotImplementedException();
        }

        public void delete(int id_entity)
        {
            throw new NotImplementedException();
        }

        public List<DTO_Tema> findAll()
        {
            throw new NotImplementedException();
        }
    }
}
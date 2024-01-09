using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.DTO
{
    public class DTO_Tema
    {
        public long Id { get; set; }
        public string Tipo { get; set; }

        public static DTO_Tema FromDataReader(MySqlDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));

            return new DTO_Tema
            {
                Id = Convert.ToInt32(reader["Id"]),
                Tipo = Convert.ToString(reader["Tema"])
            };

            // Apuntes de Adelaida
            //return new DTO_Tema
            //{
            //    Id = reader.GetFieldValue<int>(0),
            //    Tipo = reader.GetFieldValue<string>(1)
            //};
        }

    }
}
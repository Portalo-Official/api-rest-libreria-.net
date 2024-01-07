using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.DTO
{
    public class DTO_Tema
    {
        public int Id { get; set; }
        public string Tema { get; set; }

        public static DTO_Tema FromDataReader(MySqlDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));

            return new DTO_Tema
            {
                Id = Convert.ToInt32(reader["Id"]),
                Tema = Convert.ToString(reader["Tema"])
            };
        }


    }
}
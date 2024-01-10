using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.SQL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.Mapper
{
    public class TemaMapper : IMapper<DTO_Tema, MySqlDataReader>
    {
        public DTO_Tema MapToDto(MySqlDataReader reader)
        {
            return new DTO_Tema
            {
                Id = reader.GetInt64("id"),
                Tipo = reader.GetFieldValue<string>(1) //Empieza en el indice 0
            };
        }

        
    }
}
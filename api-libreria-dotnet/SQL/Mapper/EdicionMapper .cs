using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.entity;
using pruebaSantiAPI_REST.SQL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.Mapper
{
    public class EdicionMapper : IMapper<EdicionDTO, MySqlDataReader>
    {
        public EdicionDTO MapToDto(MySqlDataReader reader)
        {

            return new EdicionDTO
            {
                Id = reader.GetInt64("Id"),
                Tipo = reader.GetString("Tipo")
            };
        }
    }
}
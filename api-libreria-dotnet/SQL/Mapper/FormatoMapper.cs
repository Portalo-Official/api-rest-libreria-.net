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
    public class FormatoMapper : IMapper<FormatoDTO, MySqlDataReader>
    {
        public FormatoDTO MapToDto(MySqlDataReader reader)
        {

            return new FormatoDTO
            {
                Id = reader.GetInt64("id"),
                Tipo = reader.GetString("tipo")
            };
        }
    }
}
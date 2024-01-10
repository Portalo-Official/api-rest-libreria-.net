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
    public class AutorMapper : IMapper<AutorDTO, MySqlDataReader>
    {
        public AutorDTO MapToDto(MySqlDataReader reader)
        {

            return new AutorDTO
            {
                Id = reader.GetInt64("id"),
                Nombre = reader.GetString("nombre")
            };
        }
    }
}
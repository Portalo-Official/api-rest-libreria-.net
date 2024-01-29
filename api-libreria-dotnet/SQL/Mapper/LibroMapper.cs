using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.DTO;
using pruebaSantiAPI_REST.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.Mapper
{
    public class LibroMapper : IMapper<DTO_Libro, MySqlDataReader>
    {
        public DTO_Libro MapToDto(MySqlDataReader reader)
        {
            return new DTO_Libro
            {
                Id = reader.GetInt64("id"),
                Titulo = reader.GetString("Titulo"),
                ISBN = reader.GetString("ISBN"),
                Precio = (float)reader.GetDecimal("Precio"), //TODO no tienes el precio en la procedure guarro
                Tema = reader.GetString("Tema"),
                Autor = reader.GetString("Autor"),
                Edicion = reader.GetString("Edicion"),
                Formato = reader.GetString("Formato")
            };
        }

        public static DTO_Libro MapFromRequest(RequestLibro request)
        {
            return new DTO_Libro
            {
                Id = request.Id,
                Titulo = request.Titulo,
                ISBN = request.ISBN,
                Tema = request.Tema,
                Autor = request.Autor,
                Edicion = request.Edicion,
                Formato = request.Formato,
                Precio = float.Parse(request.Precio)
            };
        }
    }
}
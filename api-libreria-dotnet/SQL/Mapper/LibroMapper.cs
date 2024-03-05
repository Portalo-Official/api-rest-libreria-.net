using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.Models.DTO;
using pruebaSantiAPI_REST.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.Mapper
{
    public class LibroMapper : IMapper<DTO_Libro, MySqlDataReader>
    {
        public DTO_Libro MapToDto(MySqlDataReader reader)
        {
            // Es una guarreria que hice, por si por otro lado insertan en la BBDD, me aseguro que no me de null.
            string urlByDefecto = "https://i.ibb.co/mz6F1Kp/167219770-127523866011194-8434310988880472619-n.jpg";   
            return new DTO_Libro
            {
                Id = reader.GetInt64("Id"),
                Titulo = reader.GetString("Titulo"),
                ISBN = reader.GetString("ISBN"),
                Precio = (float)reader.GetDecimal("Precio"), //TODO no tienes el precio en la procedure guarro
                Tema = reader.GetString("Tema"),
                Autor = reader.GetString("Autor"),
                Edicion = reader.GetString("Edicion"),
                Formato = reader.GetString("Formato"),
                Cantidad = reader.GetInt32("Stock"),
                URL =(reader.GetString("URL")!=null)? reader.GetString("URL"): urlByDefecto,
            };
        }

        public static DTO_Libro MapFromRequest(RequestLibro request)
        {
            // Es una guarreria que hice, por si por otro lado insertan en la BBDD, me aseguro que no me de null.
            string urlByDefecto = "https://i.ibb.co/mz6F1Kp/167219770-127523866011194-8434310988880472619-n.jpg";
            return new DTO_Libro
            {
                Id = request.Id,
                Titulo = request.Titulo,
                ISBN = request.ISBN,
                Tema = request.Tema,
                Autor = request.Autor,
                Edicion = request.Edicion,
                Formato = request.Formato,
                Precio = request.Precio,
                Cantidad = request.Cantidad,
                URL = (request.URL != null && request.URL != "") ? request.URL : urlByDefecto,
            };
        }
    }
}
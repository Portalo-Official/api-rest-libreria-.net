using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.Models.entity
{
    public class AutorDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }

        public AutorDTO()
        {
        }

        public AutorDTO(long id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }

}
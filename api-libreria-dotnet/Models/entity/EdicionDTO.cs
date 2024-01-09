using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.Models.entity
{
    public class EdicionDTO
    {
        public long Id { get; set; }
        public string Tipo { get; set; }

        public EdicionDTO()
        {
        }

        public EdicionDTO(long id, string tipo)
        {
            Id = id;
            Tipo = tipo;
        }
    }

}
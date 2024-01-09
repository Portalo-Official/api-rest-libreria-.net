using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.Models.entity
{
    public class FormatoDTO
    {
        public long Id { get; set; }
        public string Tipo { get; set; }

        public FormatoDTO()
        {
        }

        public FormatoDTO(long id, string tipo)
        {
            Id = id;
            Tipo = tipo;
        }
    }

}
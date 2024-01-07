using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.Models.DTO
{
    public class DTO_Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public Tema Tema { get; set; }

    }
}
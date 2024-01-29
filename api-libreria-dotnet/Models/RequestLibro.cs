using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.Models
{
   
    public class RequestLibro
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Precio { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }
        public string Edicion { get; set; }
        public string Formato { get; set; }
        
        public int Cantidad { get; set; }

        public RequestLibro() { }

    }
}
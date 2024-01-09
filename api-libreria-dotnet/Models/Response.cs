using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.Models
{
    public class Response
    {
        public string OK { get; set; }
        public string Error { get; set; }
        public Object Data { get; set; }

        public Response() { 
            this.OK = null;
            this.Error = null;
            this.Data = null;
        }

        public void MessageError(string Mensaje)
        {
            this.Error = "Ocurrio un error -" + Mensaje;
        }
         public void MessageSuccess(string Mensaje)
        {
            this.OK = "Exito en la operación: "+Mensaje;
        }

    }
}
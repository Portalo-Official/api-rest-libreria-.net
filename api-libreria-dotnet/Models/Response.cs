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
    }
}